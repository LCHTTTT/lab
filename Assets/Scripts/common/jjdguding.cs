using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jjdguding : MonoBehaviour
{
	public GameObject LuoGan04;
	//public GameObject mubiao;
	Vector3 LuoGan04Aim = new Vector3();
	Quaternion LuoGan04Qua = new Quaternion(0f, 0f, 0.0f, 0.0f);


	// Use this for initialization
	void Start()
	{


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
		//mkguding mkflag = new mkguding();
		if (mkguding.mkflag == 0)
		{
			LuoGan04Aim.x = 47.1f;
			LuoGan04Aim.y = 1.011735f;
			LuoGan04Aim.z = 49.204f;
		}
		if(mkguding.mkflag == 1)
        {
			LuoGan04Aim.x = 47.1f;
			LuoGan04Aim.y = 1.175f;
			LuoGan04Aim.z = 49.204f;
		}
		if (Mathf.Sqrt((LuoGan04.transform.localPosition - LuoGan04Aim).magnitude) < 0.4)
		{
			LuoGan04.transform.localPosition = LuoGan04Aim;
			LuoGan04.transform.localRotation = LuoGan04Qua;

		}




	}
}