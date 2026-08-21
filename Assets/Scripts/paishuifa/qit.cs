using Obi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class qit : MonoBehaviour
{
    public GameObject fr;
    public Button hcbtn,jqbtn,jssybtn,zlqcbtn;
    public GameObject hc,jqp,blg,ypqt,ycqt;
    public Vector3 ys;
    public InputField wenti;
    public Text fenshu;
    public static int flag = 0;
    public Image hd;
    // Start is called before the first frame update
    void Start()
    {
        //jqp.GetComponent<Cooperation>().enabled = true;
        fr.GetComponent<ParticleSystem>().Stop(); //ֹͣ
        hcbtn.gameObject.SetActive(false);
        jqbtn.gameObject.SetActive(false);
        jssybtn.gameObject.SetActive(false);
        zlqcbtn.gameObject.SetActive(false);
        hcbtn.onClick.AddListener(delegate
        {
            hc.transform.position = new Vector3(46.89299f, 1.208f, 48.521f);
            flag = 1;
            /*-----------------------------*/

        });
        jqbtn.onClick.AddListener(delegate
        {
            jqp.transform.localPosition = new Vector3(46.89299f, 0.908f, 48.68859f);
            jqp.transform.localRotation = Quaternion.Euler(0, 0, 0);
            hcbtn.gameObject.SetActive(true);
            blg.transform.parent = null;
            ys = blg.transform.localPosition;
            jqbtn.gameObject.SetActive(false);
            if (!lzpz.CollectionCompleted)
            {
                pfxt.fenshu = pfxt.fenshu - PlayerPrefs.GetInt("wsjm");
                wenti.text = wenti.text + "\r\n未收集满一瓶氧气！";
                hd.gameObject.SetActive(true);
            }
            ycqt.GetComponent<ParticleSystem>().Stop();
            lzpz.ypqtgb = 0;
            zlqcbtn.gameObject.SetActive(true);
            Destroy(jqp.GetComponent<Cooperation>());
        });
    }
    public void Update()
    {
        if (flag==1&&Vector3.Equals(blg.transform.localPosition, ys)&&lzpz.CollectionCompleted)
        {
            fr.GetComponent<ParticleSystem>().Play();
            zlqcbtn.gameObject.SetActive(true);
        }
    }
}
