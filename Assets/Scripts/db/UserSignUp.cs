using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class UserSignUp : UserLogIn {
    // Start is called before the first frame update
    String result;
    void Start() {
        string dbUser = Environment.GetEnvironmentVariable("LAB_DB_USER") ?? "";
        string dbPassword = Environment.GetEnvironmentVariable("LAB_DB_PASSWORD") ?? "";
        mysql = new MySqlAccess(sjkcs.server, sjkcs.port, dbUser, dbPassword, "lab");
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnSignUpBtnClick() {
        mysql.OpenSql();
        //插入数据
        result = DES.EncryptDES(passwordInput.text, key);
        bool succ = mysql.Insert("students", new[] { "number", "password" }, new[] { userNameInput.text, result });
        Debug.Log(succ ? "注册成功,请重新登录" : "注册失败,用户名已存在,请重新注册");
    }
}
