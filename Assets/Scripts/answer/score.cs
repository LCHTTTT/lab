using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Imdork.Mysql;
using System;
using CodeStage.AntiCheat.ObscuredTypes;

public class score : MonoBehaviour
{
    // Start is called before the first frame update
    ObscuredDouble zscj;
    int flag = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sc()
    {
        string yhm = GameObject.Find("chuanzhi").GetComponent<chuanzhi>().yhmtxt;
        string score = GameObject.Find("score").GetComponent<Text>().text;
        zscj = Convert.ToDouble(score) / Convert.ToDouble(Answer.topicMax)*100.0;
        //Debug.Log(zscj);
        //创建数据库类                   IP地址       端口    用户名   密码     数据库项目名称
        var mySqlTools = new SqlHelper(sjkcs.server, sjkcs.port, sjkcs.dbUser, sjkcs.dbPassword, "lab");
        //打开数据库
        mySqlTools.Open();
        if (flag == 0)
        {
            //  更新方法                      表名         更新字段名    判断符号         更新数据          查询条件字段        条件成立字段
            mySqlTools.UpdateIntoSpecific("students", new[] { "number" }, new[] { "=" }, new[] { yhm }, new[] { "score" }, new[] { zscj.ToString() });
            flag = 1;
        }
        //关闭数据库
        mySqlTools.Close();

    }
}
