using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class szpz : MonoBehaviour
{
    public GameObject saizi;
    public static int szflag = 0;
    public Vector3 szjbwz;
    //Quaternion LuoGan04Qua = new Quaternion(0f, 0f, 0f, 0.0f);
    private void Start()
    {
        GameObject sgj = GameObject.Find("jiaziweizhi");
        sgj.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
    void Update()
    {
        GameObject sgwz = GameObject.Find("TestTube");
        GameObject sgj = GameObject.Find("jiaziweizhi");
        if (yaopin.shigaunflag==1&& Mathf.Sqrt((saizi.transform.localPosition - sgwz.transform.localPosition).magnitude) < 0.6)
        {
            saizi.transform.localRotation = Quaternion.Euler(0, 0, 0);
            saizi.transform.localPosition = sgwz.transform.localPosition +new Vector3(0f,0f, -0.34f)/*new Vector3(0f, 0.335f, 0f)*/;
            saizi.transform.parent = sgwz.transform;
            if (szflag == 0)
            {
                szjbwz = saizi.transform.localPosition;
            }
            szflag = 1;
        }
        //Debug.Log(Mathf.Sqrt((saizi.transform.localPosition - sgwz.transform.localPosition).magnitude));
        if (szflag == 1 && saizi.transform.localPosition!=szjbwz)
        {
            saizi.transform.parent = null;
            szflag = 0;
        }
    }
}
