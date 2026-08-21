using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sgpz : MonoBehaviour
{
    public GameObject LuoGan04;
    public Button njxn;
    //public GameObject mubiao;
    //Quaternion LuoGan04Qua = new Quaternion(0f, 0f, 0f, 0.0f);
    // Update is called once per frame
    private void Start()
    {
        try
        {
        njxn.gameObject.SetActive(false);
        }
        catch
        {

        }
    }
    void Update()
	{
        GameObject jiaziweizhi = GameObject.Find("tiejiataiganzi");
        //GameObject jiaziweizhi = GameObject.Find("zx");
        //jiaziweizhi.active = false;
        //Debug.Log(jiaziweizhi.transform.localPosition);
        //sjzb = transform.TransformPoint(jiaziweizhi.transform.localPosition);
        //sjzb = transform.localToWorldMatrix.MultiplyPoint(jiaziweizhi.transform.localPosition);
        //Debug.Log(Vector3.Distance(LuoGan04.transform.localPosition, sjzb));
        //Debug.Log(sjzb);
        //Debug.Log(Mathf.Sqrt((transform.localToWorldMatrix.MultiplyPoint(LuoGan04.transform.localPosition) - sjzb).magnitude*100000));
        /*if (Vector3.Distance(LuoGan04.transform.localPosition, sjzb) < 0.4)
        {
            //向量的加法运算
            //transform.position = transform.position + normal * 0.1f;
            LuoGan04.transform.position = sjzb;
        }*/
        //Debug.Log(Mathf.Sqrt((LuoGan04.transform.localPosition - jiaziweizhi.transform.localPosition).magnitude));
        /*if (Mathf.Sqrt((LuoGan04.transform.localPosition - transform.localToWorldMatrix.MultiplyPoint(jiaziweizhi.transform.localPosition)).magnitude) < 0.4)
        {
            LuoGan04.transform.localPosition = transform.localToWorldMatrix.MultiplyPoint(jiaziweizhi.transform.localPosition);
            Debug.Log("1");
            //LuoGan04.transform.parent = tjt.transform;
            //LuoGan04.transform.localRotation = LuoGan04Qua;
        }*/



        if (Mathf.Sqrt((LuoGan04.transform.localPosition - jiaziweizhi.transform.localPosition).magnitude) <0.6)
		{
			LuoGan04.transform.localPosition = jiaziweizhi.transform.localPosition+new Vector3(-0.04f,0.2f,0.06f);
            njxn.gameObject.SetActive(true);
            //LuoGan04.transform.parent = tjt.transform;
            //LuoGan04.transform.localRotation = LuoGan04Qua;
        }
        else
        {
            //njxn.gameObject.SetActive(false);
        }



	}
    /*private void Start()
    {
        Debug.Log(transform.localToWorldMatrix.MultiplyPoint(GameObject.Find("jiaziweizhi").transform.localPosition));
    }
    private void OnCollisionStay(Collision collision)
    {
        
        if (collision.gameObject.name == "tiejiataiganzi")
        {
            GameObject sg = GameObject.Find("TestTube");
            GameObject tjt = GameObject.Find("jiaziweizhi");
            //gz.active = false;
            //sg.transform.parent = null;
            Debug.Log(transform.localToWorldMatrix.MultiplyPoint(tjt.transform.localPosition));
            Debug.Log(transform.localToWorldMatrix.MultiplyPoint(tjt.transform.localPosition));
            Vector3.Distance(sg.transform.localPosition, transform.localToWorldMatrix.MultiplyPoint(tjt.transform.localPosition));
            {
                //向量的加法运算
                transform.position = transform.position + normal * 0.1f;
            }
            else
            {
                transform.position = target;
            }
            sg.transform.localPosition = transform.localToWorldMatrix.MultiplyPoint(tjt.transform.localPosition);
            //sg.transform.localPosition = Vector3.MoveTowards(GameObject.Find("TestTube").transform.localPosition, transform.localToWorldMatrix.MultiplyPoint(tjt.transform.localPosition)+new Vector3(0.1f,-0.44f,1.4f), 5);
            //sg.transform.parent = tjt.transform;
            //sg.transform.localPosition = Vector3.MoveTowards(GameObject.Find("TestTube").transform.localPosition, new Vector3(-0.04130172f, 0.6097f, -0.1029358f), 5);
        }
    }*/
}
