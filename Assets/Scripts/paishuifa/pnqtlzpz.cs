using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pnqtlzpz : MonoBehaviour
{
    public static float pnqt = 0;
    public InputField wenti;
    public Text fenshu;
    public int koufen = 0;
    // Start is called before the first frame update
    void Start()
    {
        koufen = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnParticleCollision(GameObject other)
    {
        //Debug.Log(pnqt);
        if (other.name == "BottleSmall" && koufen == 0)
        {
            pnqt += 0.5f;
            pfxt.fenshu = pfxt.fenshu - PlayerPrefs.GetInt("sjqt");
            wenti.text = wenti.text + "\r\n集气瓶收集时机错误，收集到了试管中的空气！";
            koufen = 1;
        }
        else if (other.name == "BottleSmall")
        {
            pnqt += 0.5f;
        }

    }
}
