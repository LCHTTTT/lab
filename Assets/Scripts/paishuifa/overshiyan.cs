using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overshiyan : MonoBehaviour
{
    private Ray ra;
    public GameObject fie;
    private RaycastHit hit;
    public GameObject gaizi,jiujingdeng;
    public static String oversy="";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ra = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ra, out hit) && hit.collider.name == "Sphere001")
            {
                gaizi.transform.localPosition = jiujingdeng.transform.localPosition + new Vector3(0f, 0.08f, 0.01f);
                gaizi.transform.parent = jiujingdeng.transform;
                ScreenPointToRay_ts.gzflag = 0;
                fie.GetComponent<ParticleSystem>().Stop(); //ֹͣ
                fire.fireflag = 0;
                if (qit.flag==1)
                {
                    overshiyan.oversy = overshiyan.oversy + "1";
                }
            }
        }
    }
}
