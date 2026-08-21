using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UserLogIn : MonoBehaviour
{
    public InputField userNameInput;
    public InputField passwordInput;
    public Image mes;
    public string host;//IP地址
    public string port;//端口号
    public string userName;//用户名
    public string password;//密码
    public string databaseName;//数据库名称
    protected MySqlAccess mysql;//封装好的数据库类
    public GameObject cz;
    protected readonly String key = Environment.GetEnvironmentVariable("LAB_PASSWORD_KEY") ?? "";
    // Start is called before the first frame update
    void Start()
    {
        string dbUser = Environment.GetEnvironmentVariable("LAB_DB_USER") ?? "";
        string dbPassword = Environment.GetEnvironmentVariable("LAB_DB_PASSWORD") ?? "";
        mysql = new MySqlAccess(sjkcs.server, sjkcs.port, dbUser, dbPassword, "lab");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLogInBtnClick() {
        mysql.OpenSql();
        //获取数据
        DataSet ds = mysql.Select("students", new string[] { "CONVERT(password USING latin1) AS password", "id" }, new string[] { "number"}, new string[] { "="}, new string[] { userNameInput.text,});
        if (ds != null) {
            DataTable table = ds.Tables[0];
            List<string>data=new List<string>();
            foreach (DataRow row in table.Rows) {
                foreach (DataColumn col in table.Columns) {
                    data.Add(row[col].ToString());
                }
            }
            //Debug.Log(DES.DecryptDES(data[0], key));
            if (DES.DecryptDES(data[0], key)== passwordInput.text) {
                Debug.Log("登陆成功");
                mes.color = Color.green;
                cz.GetComponent<chuanzhi>().yhmtxt = userNameInput.text;
                SceneManager.LoadScene(1);
            }
            else {
                Debug.Log("登陆失败");
                mes.color = Color.red;
            }
        }
        else {
            Debug.Log("登陆失败");
            mes.color = Color.red;
        }
        mysql.CloseSql();
    }
}
