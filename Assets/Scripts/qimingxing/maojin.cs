using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maojin : MonoBehaviour
{
    public GameObject remaojin, shiguan;
    public static int mjflag = 0;
    public Mesh mj;
    void Start()
    {
        remaojin.GetComponent<MeshFilter>().mesh = mj;
        
    }
    void Update()
    {
        if (mjflag == 0&& qmxsaizi.szflag==1&&dgtpd.dgtflag==1 && Mathf.Sqrt((remaojin.transform.localPosition - shiguan.transform.localPosition).magnitude) < 0.4)
        {
            remaojin.transform.localRotation = Quaternion.Euler(0f, 94.013f, 273.361f);
            remaojin.transform.localPosition = shiguan.transform.localPosition + new Vector3(0f, 0.1f, 0f)/*new Vector3(0f, 0.335f, 0f)*/;
            mjflag = 1;
            remaojin.transform.parent = shiguan.transform;
            Destroy(remaojin.GetComponent<Cooperation>());
        }
        if (Vector3.Equals(remaojin.transform.localPosition, new Vector3(0f, 0.35f, 0f)))
        {
            mjflag = 0;
        }
    }
}
