using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlmove : MonoBehaviour
{
    public static int z = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("z")&&z==0)
        {
            GameObject.Find("Camera").GetComponent<RotateMoveCamera>().enabled = false;
            z = 1;
        }
        else if(Input.GetKeyUp("z") && z == 1)
        {
            GameObject.Find("Camera").GetComponent<RotateMoveCamera>().enabled = true;
            z = 0;
        }
        
    }
}
