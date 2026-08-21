using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pkqjyjg : MonoBehaviour
{
    public Button hcbtn, jssybtn;
    public GameObject hc, jqp,p3;
    public static int flag = 0;
    // Start is called before the first frame update
    void Start()
    {

        hcbtn.gameObject.SetActive(false);
        jssybtn.gameObject.SetActive(false);
        hcbtn.onClick.AddListener(delegate
        {
            //Debug.Log(pkqjqpguding.jqpflag);
            if (pkqjqpguding.jqpflag == 1)
            {
                hc.transform.localPosition = jqp.transform.localPosition+ new Vector3(0.013f, 0.28f, -0.20f);
            }
            if (pkqjqpguding.jqpflag == 0)
            {
                hc.transform.localPosition =transform.localToWorldMatrix.MultiplyPoint(p3.transform.localPosition)+new Vector3(0.32692f, 0.146f,0f);
            }
            flag = 1;
            /*-----------------------------*/

        });
    }
    private void Update()
    {
        //Debug.Log(flag);
    }
}
