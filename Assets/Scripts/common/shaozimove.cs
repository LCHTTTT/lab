using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaozimove : MonoBehaviour
{
    float tempX = 0f;
    float tempY = 0f;
    float tempZ = 0f;
    IEnumerator OnMouseDown()    //使用协程
    {
        Vector3 targetScreenPos = Camera.main.WorldToScreenPoint(transform.position);//三维物体坐标转屏幕坐标
        //将鼠标屏幕坐标转为三维坐标，再计算物体位置与鼠标之间的距离
        var offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPos.z));

        while (Input.GetMouseButton(0))
        {
            //将鼠标位置二维坐标转为三维坐标
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPos.z);
            //将鼠标转换的三维坐标再转换成世界坐标+物体与鼠标位置的偏移量
            var targetPos = Camera.main.ScreenToWorldPoint(mousePos) + offset;
            transform.position = targetPos;
            yield return new WaitForFixedUpdate();//循环执行
        }
        tempY = Mathf.Clamp(transform.position.y, 1.359f, 1.359f);
        transform.position = new Vector3(transform.position.x, tempY, transform.position.z);
        tempX = Mathf.Clamp(transform.position.x, 46.9624f, 46.9624f);
        transform.position = new Vector3(tempX, transform.position.y, transform.position.z);
        tempZ = Mathf.Clamp(transform.position.z, 48.576f, 48.7888f);
        transform.position = new Vector3(transform.position.x, transform.position.y, tempZ);

    }
}
