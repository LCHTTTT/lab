using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class fuzhuzhuanchang : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject a,b,c,d,e,f,g,h,i;
    void Start()
    {
        a.gameObject.SetActive(false);
        b.gameObject.SetActive(false);
        c.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cstzmb()
    {
        a.gameObject.SetActive(true);
        b.gameObject.SetActive(true);
        c.gameObject.SetActive(true);
        d.gameObject.SetActive(false);
        e.gameObject.SetActive(false);
        f.gameObject.SetActive(false);
        g.gameObject.SetActive(false);
        h.gameObject.SetActive(false);
        i.gameObject.SetActive(false);

    }
}
