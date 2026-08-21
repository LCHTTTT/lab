using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Imdork.Mysql;

public class shiyanfenshu : MonoBehaviour
{
    // Start is called before the first frame update
    public string ziduan;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void shiyanfenshusc()
    {
        try
        {
            string yhm = GameObject.Find("chuanzhi").GetComponent<chuanzhi>().yhmtxt;
            //Debug.Log(zscj);
            //创建数据库类                   IP地址       端口    用户名   密码     数据库项目名称
            var mySqlTools = new SqlHelper(sjkcs.server, sjkcs.port, sjkcs.dbUser, sjkcs.dbPassword, "lab");
            //打开数据库
            mySqlTools.Open();
            //  更新方法                      表名         更新字段名    判断符号         更新数据          查询条件字段        条件成立字段
            mySqlTools.UpdateIntoSpecific("students", new[] { "number" }, new[] { "=" }, new[] { yhm }, new[] { ziduan }, new[] { pfxt.fenshu.ToString() });
            //关闭数据库
            mySqlTools.Close();
        }
        catch
        {
            string yhm = "12";
        }
    }
}
