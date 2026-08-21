using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class raymove : MonoBehaviour
{
    //参数hit 为out类型，可得到碰撞检测的返回值；
    private Ray ra;
    private RaycastHit hit;
    private bool is_element = false;
    private int flag = 0;
    private GameObject Element;
    public GameObject point02;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ra = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ra, out hit) && hit.collider.name == "2")
            {
                Debug.Log("广口瓶");
                is_element = true;
                Element = point02;
                if (flag == 0)
                {
                    flag = 1;
                }
                else
                {
                    flag = 0;
                }
            }
            if (Physics.Raycast(ra, out hit) && hit.collider.name == "Cylinder")
            {
                Debug.Log("圆柱体");

                /* Element = GameObject.Find("Cube");
                 Element.GetComponent<Renderer>().enabled = true;*/
            }
        }

        if (flag == 1 && is_element)
        {
            Vector3 targetScreenPos = Camera.main.WorldToScreenPoint(Element.transform.position);
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPos.z);
            Element.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        }
    }
}

