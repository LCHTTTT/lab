using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qmxsaizi : MonoBehaviour
{
    public GameObject saizi,shiguan;
    public static int szflag = 0;
    void Update()
    {
        if (szflag==0&&Mathf.Sqrt((saizi.transform.localPosition - shiguan.transform.localPosition).magnitude) < 0.4)
        {
            saizi.transform.localRotation = Quaternion.Euler(90, 0, 0);
            saizi.transform.localPosition = shiguan.transform.localPosition + new Vector3(0f, 0.35f, 0f)/*new Vector3(0f, 0.335f, 0f)*/;
            szflag = 1;
            saizi.transform.parent = shiguan.transform;
            Destroy(saizi.GetComponent<Cooperation>());
        }
        if(Vector3.Equals(saizi.transform.localPosition, new Vector3(0f, 0.35f, 0f)))
        {
            szflag = 0;
        }
    }
}
