using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joinwater : MonoBehaviour
{
    public int flag = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void jwater()
    {
        if (flag == 0) 
        { 
            GameObject blg = GameObject.Find("boligai");
            GameObject jqp = GameObject.Find("BottleSmall");
            blg.transform.parent = null;
            blg.transform.localPosition = jqp.transform.localPosition + new Vector3(0f, 0.25f, 0f);
            blg.transform.parent = jqp.transform;
            jqpguding.jqpwater = 1;
            Debug.Log("¼ÓË®Íê±Ï");
            flag = 1;
        }
    }
}
