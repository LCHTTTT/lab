using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shigaun : MonoBehaviour
{
    public GameObject shiguan;
    public GameObject shiguanjia;
    Vector3 sgj = new Vector3(-0.407f, -0.422f, 1.047f);
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collisionr)
    {
        if(collisionr.gameObject.name== "TubeSupport")
        {
            Debug.Log(collisionr.gameObject.name);
            Debug.Log(shiguanjia.transform.localPosition);
            shiguan.transform.localPosition = sgj;
            Debug.Log(shiguan.transform.localPosition);
        }
    }
}
