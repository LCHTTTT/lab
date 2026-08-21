using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dgtpd : MonoBehaviour
{
    public GameObject p;
    public static int dgtflag=0;
    // Update is called once per frame
    void Update()
    {
        if (!Vector3.Equals(p.transform.localPosition,new Vector3(-0.4492378f,-0.2991766f,0.5579262f)))
        {
            dgtflag = 0;
        }
        //Debug.Log(dgtflag);
    }
}
