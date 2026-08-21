using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class zongjie : MonoBehaviour
{
    public GameObject mianban;
    public InputField wenti;
    public Button jrsy, fhsy;
    public Text syzname, fs, wt,sj,clock;
    private bool timeflag = false;
    // Start is called before the first frame update
    void Start()
    {
        mianban.gameObject.SetActive(false);
        timeflag = false;
    }

    // Update is called once per frame
    public void zjmb()
    {
        mianban.gameObject.SetActive(true);
        try
        {
            string yhm = GameObject.Find("chuanzhi").GetComponent<chuanzhi>().yhmtxt;
            syzname.text = yhm;
            fs.text = pfxt.fenshu.ToString();
            if (timeflag == false)
            {
                if (clock.text == "00:00:00")
                {
                    sj.text = "未记录时间";
                }
                else
                {
                    sj.text = clock.text;
                }
                timeflag = true;
            }
            
        }
        catch
        {
            syzname.text= "未登录";
            fs.text = pfxt.fenshu.ToString();
            if (timeflag == false)
            {
                if (clock.text == "00:00:00")
                {
                    sj.text = "未记录时间";
                }
                else
                {
                    sj.text = clock.text;
                }
                timeflag = true;
            }
        }
        if (wenti.text == "")
        {
            wt.text = "本次实验成功，请牢记实验步骤,温故而知新！";
        }
        else
        {
            wt.text = wenti.text;
        }
    }
    public void jrsybtn()
    {
        SceneManager.LoadScene(5);
    }
    public void fhsybtn()
    {
        mianban.gameObject.SetActive(false);
    }
}
