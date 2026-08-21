using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fire : MonoBehaviour
{
    ParticleSystem fe;
    public Button fireann;
    public GameObject fie;
    public InputField wenti;
    public static int fireflag=0;
    public Image hd;

    void Start()
    {
        fie.GetComponent<ParticleSystem>().Stop(); //Í£Ö¹
    }
    public void openfire()
    {
        if(fireflag==0&&ScreenPointToRay_ts.gzflag==1)
        {
            fie.GetComponent<ParticleSystem>().Play(); //²¥·Å
            if ((Convert.ToDouble(GameObject.Find("qx").GetComponent<Text>().text) < 33 || Convert.ToDouble(GameObject.Find("qx").GetComponent<Text>().text) > 41))
            {
                if (xuanniu.xnflag==1)
                {
                    pfxt.fenshu = pfxt.fenshu - PlayerPrefs.GetInt("sgqx");
                    hd.gameObject.SetActive(true);
                    wenti.text = wenti.text + "\r\nÊÔ¹ÜÇãÐ±½Ç¶ÈÓÐÎó£¡";
                }
            }
            if (mhguding.mhflag == 0)
            {
                if (xuanniu.xnflag == 1)
                {
                    pfxt.fenshu = pfxt.fenshu - PlayerPrefs.GetInt("zrmh");
                    hd.gameObject.SetActive(true);
                    wenti.text = wenti.text + "\r\nÎ´×°ÈëÃÞ»¨£¡";
                }
            }
            fireflag = 1;
            //Debug.Log("1");

        }
        else
        {
            fie.GetComponent<ParticleSystem>().Stop(); //Í£Ö¹
            fireflag = 0;
            Debug.Log("0");
            
            overshiyan.oversy = overshiyan.oversy + "0";
        }
        if (fireflag == 0)
        {
            fireann.transform.Find("Text").GetComponent<Text>().text = "µãÈ¼¾Æ¾«µÆ";
        }
        if (fireflag == 1)
        {
            fireann.transform.Find("Text").GetComponent<Text>().text = "´µÃð¾Æ¾«µÆ";
        }
        //gameObject.GetCompoment<ParticleSystem>().Pause(); ÔÝÍ£   
    }
}
