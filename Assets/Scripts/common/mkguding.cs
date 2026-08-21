using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mkguding : MonoBehaviour
{
	public GameObject LuoGan04;
	//public GameObject mubiao;
	public float x;
	public float y;
	public float z;
	public static int mkflag = 0;
	Vector3 LuoGan04Aim = new Vector3();
	Quaternion LuoGan04Qua = new Quaternion(0f, 1f, 0.0f, 0.0f);


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
		if (Mathf.Sqrt((LuoGan04.transform.localPosition - LuoGan04Aim).magnitude) < 0.4)
		{
			LuoGan04.transform.localPosition = LuoGan04Aim;
			LuoGan04.transform.localRotation = LuoGan04Qua;
			mkflag = 1;
		}
        else
        {
			mkflag = 0;
        }




	}
}