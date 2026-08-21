using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pkqdgt : MonoBehaviour
{
    public GameObject p;
    public static int pkqdgtflag = 0;
    // Update is called once per frame
    void Update()
    {
        if (!Vector3.Equals(p.transform.localPosition, new Vector3(-0.421f, -0.332f, 0.356f)))
        {
            pkqdgtflag = 0;
        }
        //Debug.Log(pkqdgtflag);
    }
}
