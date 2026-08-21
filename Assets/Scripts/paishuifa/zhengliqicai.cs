using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeStage.AntiCheat.ObscuredTypes;
using System;

public class zhengliqicai : MonoBehaviour
{
    public Button zlqc,jssy;
    public GameObject hd;
    public InputField wenti;
    public int caozuokaishi = 0, firebj = 0,dgtbj=0,koufen=0;
    public String jyjg = "";
    private void Start()
    {
        zlqc.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (caozuokaishi == 1&&jyjg.Length!=2)
        {
            if(fire.fireflag==0&& firebj==0)
            {
                jyjg = jyjg + "2";
                firebj = 1;
            }
            if (dgtpd.dgtflag == 0 && dgtbj == 0)
            {
                jyjg = jyjg + "3";
                dgtbj = 1;
            }
        }
        if (jyjg.Length == 2&&koufen==0)
        {
            if (jyjg != "32")
            {
                pfxt.fenshu = pfxt.fenshu - PlayerPrefs.GetInt("sysxcw");
                hd.gameObject.SetActive(true);
                wenti.text = wenti.text + "\r\n仪器整理顺序有误！";
                koufen = 1;
                zlqc.gameObject.SetActive(false);
                jssy.gameObject.SetActive(true);
            }
            if (jyjg != "23")
            {
                zlqc.gameObject.SetActive(false);
                jssy.gameObject.SetActive(true);
            }
        }
    }
    public void zlqccz()
    {
        caozuokaishi = 1;
        zlqc.transform.Find("Text").GetComponent<Text>().text = "请开始整理";
    }
}
