using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using System;

public class ScreenPointToRay_ts : MonoBehaviour
{
    //参数hit 为out类型，可得到碰撞检测的返回值；
    private Ray ra;
    private RaycastHit hit;
	private bool is_element = false;
	public int mutaiflag = 0;
	private GameObject Element;
    public GameObject point02;
    public float Speed = 5f;
    public static int gzflag =0;

    void Update()
    {
            if (Input.GetMouseButtonDown(0))
            {
                ra = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ra, out hit) && hit.collider.name == "TubeSupport")
            {
                Debug.Log("试管架");
                GameObject.Find("tiptran1").transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(47.1f, 0.8938647f, 49.692f), 2);
                GameObject.Find("tiptran1").GetComponent<Renderer>().enabled = true;
                GameObject.Find("tiptran").transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(47.1f, 1.21f, 49.692f), 2);
                GameObject.Find("tiptran").GetComponent<Renderer>().enabled = true;
            }
            if (Physics.Raycast(ra, out hit) && hit.collider.name == "jiujingdeng")
            {
                Debug.Log("酒精灯");
                GameObject.Find("tiptran1").transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(47.1f, 0.8938647f, 49.203f), 2);
                GameObject.Find("tiptran1").GetComponent<Renderer>().enabled = true;
                GameObject.Find("tiptran").transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(47.1f, 1.21f, 49.203f), 2);
                GameObject.Find("tiptran").GetComponent<Renderer>().enabled = true;
            }
            if (Physics.Raycast(ra, out hit) && hit.collider.name == "BottleTiny")
            {
                Debug.Log("高锰酸钾药瓶");
                GameObject.Find("tiptran1").transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(46.923f, 0.8938647f, 48.663f), 2);
                GameObject.Find("tiptran1").GetComponent<Renderer>().enabled = true;
                GameObject.Find("tiptran").transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(46.923f, 1.21f, 48.663f), 2);
                GameObject.Find("tiptran").GetComponent<Renderer>().enabled = true;
            }
            if (Physics.Raycast(ra, out hit) && hit.collider.name == "tiejiataiganzi")
            {
                Debug.Log("铁架台");
                GameObject.Find("tiptran1").transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(47.1326f, 0.8938647f, 48.92056f), 2);
                GameObject.Find("tiptran1").GetComponent<Renderer>().enabled = true;
                GameObject.Find("tiptran").transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(47.1326f, 1.21f, 48.92056f), 2);
                GameObject.Find("tiptran").GetComponent<Renderer>().enabled = true;
            }
            if (Physics.Raycast(ra, out hit) && hit.collider.name == "mutai")
            {
                Debug.Log("木垫块");
                GameObject.Find("tiptran1").transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(47.1f, 0.8938647f, 49.204f), 2);
                GameObject.Find("tiptran1").GetComponent<Renderer>().enabled = true;
                GameObject.Find("tiptran").transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(47.1f, 1.21f, 49.204f), 2);
                GameObject.Find("tiptran").GetComponent<Renderer>().enabled = true;
            }
            if (Physics.Raycast(ra, out hit) && hit.collider.name == "BottleSmall")
            {
                Debug.Log("集气瓶");
                GameObject.Find("tiptran1").transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(47.077f, 0.8938647f, 47.949f), 2);
                GameObject.Find("tiptran1").GetComponent<Renderer>().enabled = true;
                GameObject.Find("tiptran").transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(47.077f, 1.21f, 47.949f), 2);
                GameObject.Find("tiptran").GetComponent<Renderer>().enabled = true;
            }
            if (jqpguding.jqpwater == 1 && Physics.Raycast(ra, out hit) && hit.collider.name == "BottleSmall")
                {
                Debug.Log("已装满水的集气瓶");
                }
            /*if (Physics.Raycast(ra, out hit) && hit.collider.name == "shuigang")
                {
                Debug.Log("水缸");
                GameObject.Find("tiptran").transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(47.1f, 0.8938647f, 48.378f), 2);
                GameObject.Find("tiptran").GetComponent<Renderer>().enabled = true;
                }*/
                if (Physics.Raycast(ra,out hit)&&hit.collider.name== "jiujingdeng")
                {
                RaycastHit[] hit = Physics.RaycastAll(ra, Mathf.Infinity, 1 << LayerMask.NameToLayer("gaizi"));
                    if (hit.Length > 0)
                    {
                        for (int i = 0; i < hit.Length; i++)
                        {
                            if (hit[i].collider.name=="Sphere001")
                            {
                            //将某个物体的本地坐标移动到(0, 0, 100)位置，速度为2
                            //GameObject.Find("Sphere001").transform.localPosition = new Vector3(Mathf.Lerp(gameObject.transform.localPosition.x, 5.72e-12f, Speed * Time.deltaTime), Mathf.Lerp(gameObject.transform.localPosition.y, -0.1431f, Speed * Time.deltaTime), 0);
                            GameObject gz = GameObject.Find("Sphere001");
                            GameObject zu = GameObject.Find("003");
                            //gz.active = false;
                            gz.transform.parent = null;
                            Debug.Log("酒精灯盖子");
                            gz.transform.localPosition = Vector3.MoveTowards(GameObject.Find("Sphere001").transform.localPosition, new Vector3(46.861f, 0.972f, 49.379f), Speed);
                            gzflag = 1;
                            }
                            
                        //Debug.Log("酒精灯盖子");
                        
                        }
                    Array.Clear(hit, 0, hit.Length);
                    }
                }
            if (Physics.Raycast(ra, out hit) && hit.collider.name == "TubeSupport")
            {
                RaycastHit[] hit = Physics.RaycastAll(ra, Mathf.Infinity, 1 << LayerMask.NameToLayer("shiguan"));
                if (hit.Length > 0)
                {
                    for (int i = 0; i < hit.Length; i++)
                    {
                        if (hit[i].collider.name == "TestTube")
                        {
                            //将某个物体的本地坐标移动到(0, 0, 100)位置，速度为2
                            //GameObject.Find("Sphere001").transform.localPosition = new Vector3(Mathf.Lerp(gameObject.transform.localPosition.x, 5.72e-12f, Speed * Time.deltaTime), Mathf.Lerp(gameObject.transform.localPosition.y, -0.1431f, Speed * Time.deltaTime), 0);
                            GameObject sg = GameObject.Find("TestTube");
                            //gz.active = false;
                            sg.transform.parent = null;
                            Debug.Log("试管");
                            //gz.transform.localPosition = Vector3.MoveTowards(GameObject.Find("TestTube").transform.localPosition, new Vector3(47.364f, 0.972f, 49.563f), Speed);
                            //gzflag = 1;
                        }

                        //Debug.Log("酒精灯盖子");

                    }
                    Array.Clear(hit, 0, hit.Length);
                }
            }
            if (Physics.Raycast(ra, out hit) && hit.collider.name == "TestTube")
            {
                RaycastHit[] hit = Physics.RaycastAll(ra, Mathf.Infinity, 1 << LayerMask.NameToLayer("shiguan"));
                if (hit.Length > 0)
                {
                    for (int i = 0; i < hit.Length; i++)
                    {
                        if (hit[i].collider.name == "mh")
                        {
                            //将某个物体的本地坐标移动到(0, 0, 100)位置，速度为2
                            //GameObject.Find("Sphere001").transform.localPosition = new Vector3(Mathf.Lerp(gameObject.transform.localPosition.x, 5.72e-12f, Speed * Time.deltaTime), Mathf.Lerp(gameObject.transform.localPosition.y, -0.1431f, Speed * Time.deltaTime), 0);
                            GameObject mh = GameObject.Find("mh");
                            //gz.active = false;
                            mh.transform.parent = null;
                            mhguding.mhflag = 1;
                            mh.transform.localPosition= new Vector3(47.034f, 0.967f, 47.609f);
                            Debug.Log("棉花");
                            //gz.transform.localPosition = Vector3.MoveTowards(GameObject.Find("TestTube").transform.localPosition, new Vector3(47.364f, 0.972f, 49.563f), Speed);
                            //gzflag = 1;
                        }

                        //Debug.Log("酒精灯盖子");

                    }
                    Array.Clear(hit, 0, hit.Length);
                }
            }
            if (Physics.Raycast(ra, out hit) && hit.collider.name == "TestTube"&&xuanniu.xnflag==0)
            {
                Debug.Log("试管");
                //GameObject.Find("tiptran").transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, new Vector3(47.1f, 0.8938647f, 49.692f), 2);
                GameObject.Find("TestTube").transform.parent = null;
            }
        }
            if (Input.GetMouseButtonUp(0)){ 

                GameObject.Find("tiptran").GetComponent<Renderer>().enabled = false;
                GameObject.Find("tiptran1").GetComponent<Renderer>().enabled = false;
        }
            /* if (Physics.Raycast(ra, out hit) && hit.collider.name == "Cylinder")
             {
                 Debug.Log("圆柱体");

            /* Element = GameObject.Find("Cube");
             Element.GetComponent<Renderer>().enabled = true;*/
            }
        }

