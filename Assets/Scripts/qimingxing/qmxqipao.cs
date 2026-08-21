using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class qmxqipao : MonoBehaviour
{
    // Update is called once per frame
    public GameObject qipaodian;
    public Button overpqf,overpsf;
    public Text text;
    public int a = 0;
    void Start()
    {
        maojin.mjflag =0;
        qmxsaizi.szflag = 0;
        dgtpd.dgtflag = 0;
        qipaodian.GetComponent<ParticleSystem>().Stop();
        overpqf.gameObject.SetActive(false);
        overpsf.gameObject.SetActive(false);
    }
    void Update()
    {
        //Debug.Log(maojin.mjflag.ToString()+qmxsaizi.szflag.ToString()+dgtpd.dgtflag.ToString());
        if(maojin.mjflag==1&&qmxsaizi.szflag==1&&dgtpd.dgtflag==1)
        {
            a++;
            if (a==500)
            {
                qipaodian.GetComponent<ParticleSystem>().Play();
                overpqf.gameObject.SetActive(true);
                overpsf.gameObject.SetActive(true);
                Debug.Log("∆¯√‹–‘¡º∫√");
            }
        }
        else
        {
            qipaodian.GetComponent<ParticleSystem>().Stop();
        }
    }
}
