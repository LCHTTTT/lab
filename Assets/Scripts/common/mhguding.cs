using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mhguding : MonoBehaviour
{
	public GameObject LuoGan04,shiguanmubiao;
	public static int mhflag = 0;
	public static int move = 0;
	//public GameObject mubiao;
	public float x;
	public float y;
	public float z;
	Vector3 LuoGan04Aim = new Vector3();
	Quaternion LuoGan04Qua = new Quaternion(0f, 1f, 0f, 0.0f);


	// Use this for initialization
	void Start()
	{
		LuoGan04Aim.x = x;
		LuoGan04Aim.y = y;
		LuoGan04Aim.z = z;
		//LuoGan04 = GameObject.Find("BottleSmall");
		//print(LuoGan04.name);
		//LuoGan04.GetComponent<Renderer>().enabled = false;
	}

	// Update is called once per frame
	void Update()
	{

		/*print("000000000p" + LuoGan04.transform.localPosition);
		print("1111111111111p" + LuoGan04Aim);

		print("2222222222222p" + (LuoGan04.transform.localPosition - LuoGan04Aim).magnitude);*/
		if (mhflag==0&& yaopin.shigaunflag==1&&Mathf.Sqrt((LuoGan04.transform.localPosition - LuoGan04Aim).magnitude) < 0.6)
		{
			LuoGan04.transform.localPosition = LuoGan04Aim;
			LuoGan04.transform.localRotation = LuoGan04Qua;
			LuoGan04.transform.parent = shiguanmubiao.transform;
			Destroy(LuoGan04.GetComponent<Cooperation>());
			move = 0;
			mhflag = 1;
		}
		if (mhflag == 0 && yaopin.shigaunflag == 0 && Mathf.Sqrt((LuoGan04.transform.localPosition - shiguanmubiao.transform.localPosition).magnitude) < 0.6)
		{
			LuoGan04.transform.localPosition = shiguanmubiao.transform.localPosition+new Vector3(0f, 0.2745f,0f);
			LuoGan04.transform.localRotation = LuoGan04Qua;
			LuoGan04.transform.parent = shiguanmubiao.transform;
			Destroy(LuoGan04.GetComponent<Cooperation>());
			move = 0;
			mhflag = 1;
		}
		if (mhflag == 1 && move == 0)
        {
			LuoGan04.AddComponent<Cooperation>();
			move = 1;
		}
		if (LuoGan04.transform.localPosition== new Vector3(47.034f, 0.967f, 47.609f))
        {
			mhflag = 0;
        }
		//Debug.Log(mhflag);
	}
}