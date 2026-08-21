using Obi;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Exploder.Utils;

public class pkqlzpz : MonoBehaviour
{
    public static int js = 0;
    public static float pzjs = 0;
    public static int jg = 0;
    public InputField yp,wenti;
    public Button jssybtn,frhcbtn;
    public GameObject frhc;
    public GameObject TagerObject;
    int baozha;
    void OnParticleCollision(GameObject other)
    {
        if (other.name == "TestTube")
        {
            if(js< Convert.ToDouble(yp.text)*2000)
            {
                js++;
                pzjs += 1;
                //Debug.Log(js);
            }
            frhcbtn.gameObject.SetActive(true);
            if (pkqdgt.pkqdgtflag==1&&pkqjyjg.flag == 1 && mhguding.mhflag == 1 && js >= 150 && js <= Convert.ToDouble(yp.text) * 2000)
            {
                frhc.GetComponent<ParticleSystem>().Play();
                jssybtn.gameObject.SetActive(true);
                pzjs -= 1f;
                if((Convert.ToDouble(GameObject.Find("qx").GetComponent<Text>().text)<33|| Convert.ToDouble(GameObject.Find("qx").GetComponent<Text>().text) > 41)&&js>150&& baozha > 5)
                {
                    ExploderSingleton.Instance.ExplodeObject(TagerObject);
                }
            }
            if (pkqdgt.pkqdgtflag == 1 && pkqjyjg.flag == 1 && mhguding.mhflag == 0 && js >= 150 && js <= Convert.ToDouble(yp.text) * 2000)
            {
                frhc.GetComponent<ParticleSystem>().Play();
                jssybtn.gameObject.SetActive(true);
                pzjs -= 1f;
                if ((Convert.ToDouble(GameObject.Find("qx").GetComponent<Text>().text) < 33 || Convert.ToDouble(GameObject.Find("qx").GetComponent<Text>().text) > 41) && js > 150&&baozha>5)
                {
                    ExploderSingleton.Instance.ExplodeObject(TagerObject);
                }

            }
            if (pzjs <= 0.0f)
            {
                frhc.GetComponent<ParticleSystem>().Stop();
                jssybtn.gameObject.SetActive(true);
            }
            if(pkqdgt.pkqdgtflag == 0)
            {
                frhc.GetComponent<ParticleSystem>().Stop();
            }
        }

        //Debug.Log(pzjs);
    }
    public void Update()
    {
        
    }
    public void Start()
    {
        System.Random random = new System.Random();
        baozha = random.Next(1, 11);
        Debug.Log(baozha);
        //ca.GetComponent<ObiFluidRenderer>().enabled = false;
        frhc.GetComponent<ParticleSystem>().Stop();
    }
}
