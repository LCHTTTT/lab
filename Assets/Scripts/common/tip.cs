using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tip : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject tiplocal;
    void Start()
    {
        tiplocal = GameObject.Find("tiptran");
        //tiplocal.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
