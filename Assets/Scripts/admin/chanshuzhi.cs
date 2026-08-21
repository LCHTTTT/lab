using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class chanshuzhi : MonoBehaviour
{
    public int zyp;
    public int zrmh;
    public int sgqx;
    public int jqpcw;
    public int sjqt;
    public int wsjm;
    public int sysxcw;
    public int zf;
    public InputField zyptxt;
    public InputField zrmhtxt;
    public InputField sgqxtxt;
    public InputField jqpcwtxt;
    public InputField sjqttxt;
    public InputField wsjmtxt;
    public InputField sysxcwtxt;
    public InputField zftxt;
    public Slider zypsl;
    public Slider zrmhsl;
    public Slider sgqxsl;
    public Slider jqpcwsl;
    public Slider sjqtsl;
    public Slider wsjmsl;
    public Slider sysxcwsl;
    public Slider zfsl;
    // Start is called before the first frame update
    void Start()
    {
        zyptxt.text = "0";
        zrmhtxt.text = "0";
        sgqxtxt.text = "0";
        jqpcwtxt.text = "0";
        sjqttxt.text = "0";
        wsjmtxt.text = "0";
        sysxcwtxt.text = "0";
        zftxt.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            zyp = Convert.ToInt32(zyptxt.text);//装药品
            zrmh = Convert.ToInt32(zrmhtxt.text);//棉花
            sgqx = Convert.ToInt32(sgqxtxt.text);//倾斜试管
            jqpcw = Convert.ToInt32(jqpcwtxt.text);//集气瓶位置收集错误
            sjqt = Convert.ToInt32(sjqttxt.text);//收集气体
            wsjm = Convert.ToInt32(wsjmtxt.text);//未收集满
            sysxcw = Convert.ToInt32(sysxcwtxt.text);//仪器使用顺序错误
            zf = Convert.ToInt32(zftxt.text);//总分
            zypsl.maxValue = zf - zrmh - sgqx - jqpcw - sjqt - wsjm - sysxcw;
            zrmhsl.maxValue = zf - zyp - sgqx - jqpcw - sjqt - wsjm - sysxcw;
            sgqxsl.maxValue = zf - zyp - zrmh - jqpcw - sjqt - wsjm - sysxcw;
            jqpcwsl.maxValue = zf - zyp - zrmh - sgqx - sjqt - wsjm - sysxcw;
            sjqtsl.maxValue = zf - zyp - zrmh - sgqx - jqpcw - wsjm - sysxcw;
            wsjmsl.maxValue = zf - zyp - zrmh - sgqx - jqpcw - sjqt - sysxcw;
            sysxcwsl.maxValue = zf - zyp - zrmh - sgqx - jqpcw - sjqt - wsjm;
        }
        catch
        {
            zyptxt.text = "0";
            zrmhtxt.text = "0";
            sgqxtxt.text = "0";
            jqpcwtxt.text = "0";
            sjqttxt.text = "0";
            wsjmtxt.text = "0";
            sysxcwtxt.text = "0";
            zftxt.text = "0";
        }
        PlayerPrefs.SetInt("zyp", zyp);
        PlayerPrefs.SetInt("zrmh", zrmh);
        PlayerPrefs.SetInt("sgqx", sgqx);
        PlayerPrefs.SetInt("jqpcw", jqpcw);
        PlayerPrefs.SetInt("sjqt", sjqt);
        PlayerPrefs.SetInt("wsjm", wsjm);
        PlayerPrefs.SetInt("sysxcw", sysxcw);
        PlayerPrefs.SetInt("zf", zf);
        PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetInt("zyp")); Debug.Log(PlayerPrefs.GetInt("zrmh"));
    }
    public void yc()
    {
        zyptxt.text = "0";
        zrmhtxt.text = "0";
        sgqxtxt.text = "0";
        jqpcwtxt.text = "0";
        sjqttxt.text = "0";
        wsjmtxt.text = "0";
        sysxcwtxt.text = "0";

    }

}
