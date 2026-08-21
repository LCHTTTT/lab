using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ypqtlzpz : MonoBehaviour
{
    public static int ypqt = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnParticleCollision(GameObject other)
    {
        //Debug.Log(ypqt);
        if (other.name == "BottleSmall")
        {
            ypqt += 1;
        }
    }
}
