using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guanbiyichu : MonoBehaviour
{
    public GameObject ycqt;
    // Start is called before the first frame update
    public void guanbi()
    {
        ycqt.GetComponent<ParticleSystem>().Stop();
        ycqt.gameObject.SetActive(false);
    }
}
