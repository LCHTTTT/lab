using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class yaopin : MonoBehaviour
{
	public GameObject LuoGan04,shiguan,yaoping,saizi;
	public InputField yaopinInput,wenti;
	public Button jiaBtn, jianBtn, sureBtn,dryaopin,wcbtn;
	public Text dw,syfs;
	public float x;
	public float y;
	public float z;
	public static float yp=0;
	public float a = 0.1f;
	public static int shigaunflag=0;
	Vector3 LuoGan04Aim = new Vector3();
	Quaternion LuoGan04Qua = new Quaternion(0f, 1f, 0f, 0.0f);
	public Image hd;


	// Use this for initialization
	void Start()
	{
		GameObject szyp = GameObject.Find("勺子药品");
		GameObject saozi = GameObject.Find("saozi");
		szyp.gameObject.SetActive(false);
		yaopinInput.gameObject.SetActive(false);
		jiaBtn.gameObject.SetActive(false);
		jianBtn.gameObject.SetActive(false);
		sureBtn.gameObject.SetActive(false);
		dryaopin.gameObject.SetActive(false);
		wcbtn.gameObject.SetActive(false);
		dw.gameObject.SetActive(false);
		Destroy(saozi.GetComponent<shaozimove>());
		LuoGan04Aim.x = x;
		LuoGan04Aim.y = y;
		LuoGan04Aim.z = z;
		yaopinInput.text = "0.0";
		//Sequence quence = DOTween.Sequence();
		//LuoGan04 = GameObject.Find("BottleSmall");
		//print(LuoGan04.name);
		//LuoGan04.GetComponent<Renderer>().enabled = false;
		wcbtn.onClick.AddListener(delegate
		{
			if (szpz.szflag==1)
			{
				shiguan.AddComponent<Cooperation>();
				//shiguan.transform.localRotation = Quaternion.Euler(0, 0, 0);
				DGRotation(new Vector3(0, 0, 0), 1);
				wcbtn.gameObject.SetActive(false);
				shigaunflag = 0;
				//yaoping.transform.localPosition = new Vector3(47.07f,0.9319f,47.446f);
			}
			else
            {
				Debug.Log("请塞好试管塞！");
            }
			
		});
		dryaopin.onClick.AddListener(delegate
		{
			//动画
			Sequence dryp = DOTween.Sequence();
			//dryp.Append(shiguan.transform.DOLocalRotate(new Vector3(90, 0, 0), 1f));
			szyp.transform.parent = null;
			dryp.Append(saozi.transform.DOLocalRotate(new Vector3(180, -90, 0), 1f));
			szyp.transform.localPosition = shiguan.transform.localPosition + new Vector3(0f, -0.01f, -0.0283f);
			dryp.Append(saozi.transform.DOLocalRotate(new Vector3(0, -90, 0), 1f));
			dryp.Append(shiguan.transform.DOLocalRotate(new Vector3(-90, 0, 0),1f));
			dryaopin.gameObject.SetActive(false);
			wcbtn.gameObject.SetActive(true);
			if (Convert.ToDouble(saozi.transform.localPosition.z) <= 48.755f)
			{
				pfxt.fenshu = pfxt.fenshu - PlayerPrefs.GetInt("zyp");
				hd.gameObject.SetActive(true);
				wenti.text = wenti.text + "勺子未深入试管底部！";
			}
			szyp.transform.parent = shiguan.transform;
			dryp.Append(saozi.transform.DOLocalMove(new Vector3(46.9624f, 1.359f, 48f), 1f, false));
			dryp.Append(saozi.transform.DOLocalRotate(new Vector3(0,0,0),1f));
			dryp.Append(saozi.transform.DOLocalMove(new Vector3(47.112f, 0.9787f, 47.2518f), 1f, false));
			Destroy(saozi.GetComponent<shaozimove>());
			saozi.AddComponent<Cooperation>();



			/*
			//Debug.Log(saozi.transform.localPosition.z);
			shiguan.transform.localRotation = Quaternion.Euler(90, 0, 0);
			szyp.transform.parent = null;
			szyp.transform.localPosition = shiguan.transform.localPosition+new Vector3(0f,-0.01f,-0.0283f);
			//szyp.transform.parent = shiguan.transform;
			shiguan.transform.localRotation = Quaternion.Euler(-90,0 , 0);
			dryaopin.gameObject.SetActive(false);
			wcbtn.gameObject.SetActive(true);
			if (Convert.ToDouble(saozi.transform.localPosition.z) <= 48.755f)
			{
				pfxt.fenshu = pfxt.fenshu - PlayerPrefs.GetInt("zyp");
				hd.gameObject.SetActive(true);
				wenti.text = wenti.text + "勺子未深入试管底部！";
			}
			szyp.transform.parent = shiguan.transform;
			saozi.transform.localRotation = Quaternion.Euler(0, 0, 0);
			saozi.transform.localPosition = new Vector3(47.112f, 0.9787f, 47.2518f);
			Destroy(saozi.GetComponent<shaozimove>());
			saozi.AddComponent<Cooperation>();
			*/

			
		});
		sureBtn.onClick.AddListener(delegate
		{
			Sequence sure = DOTween.Sequence();
			ypnum();
			if(yaopinInput.text=="0.0")
            {
				Debug.Log("请加入药品!");
            }
			else
            {
				if (shiguan.transform.parent != null)
				{
					Debug.Log("请从试管架取出试管!");
				}
				else
				{
					//shiguan.transform.parent = null;
					sure.Append(yaoping.transform.DOLocalMove(new Vector3(47.07f, 0.9319f, 47.446f),1f,false));
					sure.Append(shiguan.transform.DOLocalMove(new Vector3(46.946f, 1.369f, 48.876f), 1f,false));
					sure.Append(shiguan.transform.DOLocalRotate(new Vector3(-90, 0, 0), 1f));
					sure.Append(saozi.transform.DOLocalRotate(new Vector3(0, -90, 0), 1f));
					sure.Append(saozi.transform.DOLocalMove(shiguan.transform.localPosition /*+ new Vector3(0f, 0f, -0.3f)*/, 1f, false));
					Destroy(saozi.GetComponent<Cooperation>());
					Destroy(shiguan.GetComponent<Cooperation>());
					saozi.AddComponent<shaozimove>();
					dryaopin.gameObject.SetActive(true);
					shigaunflag = 1;
					yp = (float)Convert.ToDecimal(yaopinInput.text);
					/*shiguan.transform.localPosition = new Vector3(46.946f, 1.369f, 48.876f);
					shiguan.transform.localRotation = Quaternion.Euler(-90, 0, 0);
					saozi.transform.localRotation = Quaternion.Euler(0, -90, 0);
					saozi.transform.localPosition = shiguan.transform.localPosition + new Vector3(0f, 0f, -0.3f);
					Destroy(saozi.GetComponent<Cooperation>());
					Destroy(shiguan.GetComponent<Cooperation>());
					saozi.AddComponent<shaozimove>();
					dryaopin.gameObject.SetActive(true);
					shigaunflag = 1;
					yp = (float)Convert.ToDecimal(yaopinInput.text);*/
					//Debug.Log(yp);
				}
			}
		});
        jiaBtn.onClick.AddListener(delegate
		{
			ypjia();
			szyp.gameObject.SetActive(true);
		});
		jianBtn.onClick.AddListener(delegate
		{
			if(Convert.ToDouble(yaopinInput.text) > 0.0)
            {
				ypjian();
				szyp.gameObject.SetActive(true);
				if (Convert.ToDouble(yaopinInput.text) == 0.0)
                {
					Debug.Log("已无药品");
					szyp.gameObject.SetActive(false);
				}
				
			}

			/*if (Convert.ToDouble(yaopinInput.text) <= 0.0)
			{
				Debug.Log("已无药品");
				szyp.gameObject.SetActive(false);
			}
			else 
			{
				ypjian();
				szyp.gameObject.SetActive(true);
			}*/

		});
	}

	// Update is called once per frame
	void Update()
	{
		GameObject saozi = GameObject.Find("saozi");
		//Debug.Log(saozi.transform.localPosition.z);
		if(LuoGan04.transform.localPosition!= LuoGan04Aim + new Vector3(0f, 0.3f, 0f))
        {
			yaopinInput.gameObject.SetActive(false);
			jiaBtn.gameObject.SetActive(false);
			jianBtn.gameObject.SetActive(false);
			sureBtn.gameObject.SetActive(false);
			dw.gameObject.SetActive(false);
		}
		
		if (yaoping.transform.localPosition==new Vector3(46.923f,0.893f,48.663f)&&Mathf.Sqrt((LuoGan04.transform.localPosition - LuoGan04Aim).magnitude) < 0.4)
		{
			LuoGan04.transform.localPosition = LuoGan04Aim+new Vector3(0f,0.3f,0f);
			LuoGan04.transform.localRotation = LuoGan04Qua;
			yaopinInput.gameObject.SetActive(true);
			jiaBtn.gameObject.SetActive(true);
			jianBtn.gameObject.SetActive(true);
			sureBtn.gameObject.SetActive(true);
			dw.gameObject.SetActive(true);
		}
	}

	public void ypnum()
    {
		string aaa = yaopinInput.text;
		string amount = string.Empty;
		if (!string.IsNullOrEmpty(aaa) && (Regex.IsMatch(aaa, @"^[1-9]\d*|0$") || Regex.IsMatch(aaa, @"^[1-9]\d*\.\d*|0\.\d*[1-9]\d*$")))
			amount = Convert.ToDecimal(aaa).ToString("F2");
		/*else
		{
			amount = "0.00";

		}*/
		//Debug.Log(amount);
		//yp = float.Parse(yaopinInput.text.ToString("#0.00"));
	}
	public void ypjia()
    {
		//Debug.Log(Convert.ToDouble(yaopinInput.text) + Convert.ToDouble(a));
		yaopinInput.text = (Convert.ToDecimal(yaopinInput.text) + Convert.ToDecimal(a)).ToString();
		//Debug.Log(yaopinInput.text);
		/*a += .10f;
		yaopinInput.text = a.ToString();*/
	}
	public void ypjian()
    {
		yaopinInput.text = (Convert.ToDecimal(yaopinInput.text) - Convert.ToDecimal(a)).ToString();
		Debug.Log(yaopinInput.text);
;    }
	void DGRotation(Vector3 angle, float time)
	{
		shiguan.transform.DOLocalRotate(angle, time, RotateMode.Fast);
	}
}