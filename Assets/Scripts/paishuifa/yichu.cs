using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yichu : MonoBehaviour
{
    public GameObject ycqt,ypqt;
    public static int ycqtgb=0;

    void Start()
    {
        ycqt.GetComponent<ParticleSystem>().Stop();
    }
}