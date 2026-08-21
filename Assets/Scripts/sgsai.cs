using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sgsai : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "TestTube")
        {
            GameObject sg = GameObject.Find("TestTube");
            GameObject sz = GameObject.Find("saizi");
            //gz.active = false;
            //sg.transform.parent = null;
            sz.transform.localPosition = Vector3.MoveTowards(GameObject.Find("saizi").transform.localPosition, sg.transform.localPosition, 5);
            sg.transform.parent = sg.transform;
            //sg.transform.localPosition = Vector3.MoveTowards(GameObject.Find("TestTube").transform.localPosition, new Vector3(-0.04130172f, 0.6097f, -0.1029358f), 5);
        }
    }
}
