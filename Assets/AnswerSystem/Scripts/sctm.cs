using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Imdork.Mysql;

public class sctm : MonoBehaviour
{
    public Button sc;
    public InputField tm;
    public static int gszq=0;
    public Text tip;
    // Start is called before the first frame update
    void Start()
    {
        //创建数据库类                 IP地址       端口    用户名   密码     数据库项目名称
        var mySqlTools = new SqlHelper(sjkcs.server, sjkcs.port, sjkcs.dbUser, sjkcs.dbPassword, "lab");
        //打开数据库

        sc.onClick.AddListener(delegate
        {
            if(gszq==1)
            {
                mySqlTools.Open();
                //  更新方法                      表名         更新字段名    判断符号         更新数据          查询条件字段        条件成立字段
                mySqlTools.UpdateIntoSpecific("dati", new[] { "id" }, new[] { "=" }, new[] { "1" }, new[] { "timu" }, new[] { tm.text });
                mySqlTools.Close();
                tip.text = "题目上传成功！";
            }
            else
            {
                tip.text = "请先检验格式或未检查题目！";
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
