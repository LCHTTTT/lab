using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jscsxg : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider hk;
    public InputField csz;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void hkgengxin()
    {
        try
        {
            csz.text = hk.value.ToString();
        }
        catch
        {
            csz.text = "0";
        }

    }
    public void txtgengxin()
    {
        try
        {
            hk.value = Convert.ToInt32(csz.text);
        }
        catch
        {
            hk.value = 0;
        }
    }
}
