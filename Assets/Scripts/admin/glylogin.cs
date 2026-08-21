using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class glylogin : MonoBehaviour
{
    public InputField user, pwd;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void admin()
    {
        string adminUser = Environment.GetEnvironmentVariable("LAB_ADMIN_USER");
        string adminPassword = Environment.GetEnvironmentVariable("LAB_ADMIN_PASSWORD");
        if (!string.IsNullOrEmpty(adminUser) &&
            !string.IsNullOrEmpty(adminPassword) &&
            user.text == adminUser && pwd.text == adminPassword)
        {

            SceneManager.LoadScene(7);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
