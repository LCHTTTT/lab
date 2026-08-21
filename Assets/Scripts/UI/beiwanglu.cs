using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class beiwanglu : MonoBehaviour
{
    public GameObject a;
    public Button b;
    public int step = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Moveve()
    {
        //在1秒内将transform移动到位置（1,2,3）
        if (step == 0)
        {
            a.transform.DOLocalMove(a.transform.localPosition + new Vector3(-295f, 0f, 0f), 0.5f).OnComplete(() => { step = 1; });
            b.transform.DOLocalMove(b.transform.localPosition + new Vector3(-295f, 0f, 0f), 0.5f).OnComplete(() => { step = 1; });
        }
        if (step == 1)
        {
            a.transform.DOLocalMove(a.transform.localPosition + new Vector3(+295f, 0f, 0f), 0.5f).OnComplete(() => { step = 0; });
            b.transform.DOLocalMove(b.transform.localPosition + new Vector3(+295f, 0f, 0f), 0.5f).OnComplete(() => { step = 0; });
        }

    }
}
