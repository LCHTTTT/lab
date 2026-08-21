using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hongdian : MonoBehaviour
{
    public Image hd;
    public Button wtan;
    // Start is called before the first frame update
    void Start()
    {
        hd.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (wentibaogao.hdstep==0)
        {
            hd.gameObject.SetActive(false);
        }
    }
}
