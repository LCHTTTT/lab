using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pkqfire : MonoBehaviour
{
    ParticleSystem fe;
    public GameObject fie,hd;
    public InputField wenti;
    public Button fireann;
    public int fireflag = 0;
    void Start()
    {
        fie.GetComponent<ParticleSystem>().Stop(); //停止
    }
    public void openfire()
    {
        if (fireflag == 0 && pkqsaomiao.gzflag == 1)
        {
            fie.GetComponent<ParticleSystem>().Play(); //播放
            if ((Convert.ToDouble(GameObject.Find("qx").GetComponent<Text>().text) < 33 || Convert.ToDouble(GameObject.Find("qx").GetComponent<Text>().text) > 41))
            {
                pfxt.fenshu = pfxt.fenshu - PlayerPrefs.GetInt("sgqx");
                wenti.text = wenti.text + "\r\n试管倾斜角度有误！";
                hd.gameObject.SetActive(true);
            }
            if (mhguding.mhflag == 0)
            {
                pfxt.fenshu = pfxt.fenshu - PlayerPrefs.GetInt("zrmh");
                hd.gameObject.SetActive(true);
                wenti.text = wenti.text + "\r\n未装入棉花！";
            }
            if (pkqdgt.pkqdgtflag == 0)
            {
                pfxt.fenshu = pfxt.fenshu - PlayerPrefs.GetInt("sjqt");
                hd.gameObject.SetActive(true);
                wenti.text = wenti.text + "\r\n导管深入位置错误！";
            }
            fireflag = 1;
            //Debug.Log("1");
        }
        else
        {
            fie.GetComponent<ParticleSystem>().Stop(); //停止
            fireflag = 0;
            //Debug.Log("0");
        }
        if (fireflag == 0)
        {
            fireann.transform.Find("Text").GetComponent<Text>().text = "点燃酒精灯";
        }
        if (fireflag == 1)
        {
            fireann.transform.Find("Text").GetComponent<Text>().text = "吹灭酒精灯";
        }
        //gameObject.GetCompoment<ParticleSystem>().Pause(); 暂停   
    }
}
