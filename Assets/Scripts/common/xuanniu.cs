using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class xuanniu : MonoBehaviour
{
    public static int xnflag = 0;
    public GameObject Circlelider;
    public Image handle;
    public Text text;
    public Button huoyananniu;
    void Start()
    {
        xnflag = 0;
        Circlelider.SetActive(false);
        handle.enabled = false;
        text.enabled = false;
    }
    public void openjiazi()
    {
        GameObject sg = GameObject.Find("TestTube");
        GameObject jz = GameObject.Find("jiaziweizhi");
        GameObject jiaziweizhi = GameObject.Find("tiejiataiganzi");
        //Rotate rotate = new Rotate();
        if (xnflag == 0&&sg.transform.localPosition== jiaziweizhi.transform.localPosition + new Vector3(-0.04f, 0.2f, 0.06f))
        {
            sg.transform.parent = jz.transform;
            xnflag = 1;
            Destroy(sg.GetComponent<Cooperation>());
            Circlelider.SetActive(true);
            handle.enabled = true;
            text.enabled = true;
            //sg.GetComponent<Cooperation>().enabled = false;
            //Debug.Log("1");
        }
        else
        {
            sg.transform.parent = null;
            xnflag = 0;
            sg.AddComponent<Cooperation>();
            Circlelider.SetActive(false);
            handle.enabled = false;
            text.enabled = false;
            //sg.GetComponent<Cooperation>().enabled = true;
            //rotate.RotateStatic(0f, -90f, 0f);
            //Debug.Log("0");
        }
        if (xnflag == 0)
        {
            huoyananniu.transform.Find("Text").GetComponent<Text>().text = "Ðý½ôÐýÅ¥";
        }
        if (xnflag == 1)
        {
            huoyananniu.transform.Find("Text").GetComponent<Text>().text = "ÐýËÉ°´Å¥";
        }
        //gameObject.GetCompoment<ParticleSystem>().Pause(); ÔÝÍ£   
    }
}
