using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chuanzhi : MonoBehaviour
{
    // Start is called before the first frame update
    public string yhmtxt;

    public void Awake()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }
    /* public void zhi()
     {
         GameObject.DontDestroyOnLoad(gameObject);
     }*/


}
