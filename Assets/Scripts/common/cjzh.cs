using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cjzh : MonoBehaviour
{

   public void jrsy()
    {
        SceneManager.LoadScene(2);
    }
    public void fhsp()
    {
        SceneManager.LoadScene(1);
    }
    public void zx()
    {
        SceneManager.LoadScene(0);
        Destroy(GameObject.Find("chuanzhi"));
    }
    public void czcj()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void jssy()
    {
        SceneManager.LoadScene(5);
    }
    public void xspkq()
    {
        SceneManager.LoadScene(4);
    }
    public void psf()
    {
        SceneManager.LoadScene(3);
    }


    public void Start()
    {
        try
        {
            string yhm = GameObject.Find("chuanzhi").GetComponent<chuanzhi>().yhmtxt;
            GameObject.Find("id").GetComponent<Text>().text = "欢迎" + yhm + "同学";
        }
        catch
        {
            GameObject.Find("id").GetComponent<Text>().text = "欢迎同学";
        }

    }
}
