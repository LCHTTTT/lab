using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeStage.AntiCheat.ObscuredTypes;

public class pfxt : MonoBehaviour
{
    // Start is called before the first frame update
    public Text zfs;
    public static ObscuredInt fenshu;
    void Start()
    {
        fenshu = PlayerPrefs.GetInt("zf");
    }

    // Update is called once per frame
    void Update()
    {
        zfs.text = "·ÖÊý:"+fenshu.ToString();
    }
}
