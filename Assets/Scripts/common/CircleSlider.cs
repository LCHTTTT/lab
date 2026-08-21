using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleSlider : MonoBehaviour
{
    [SerializeField] Transform handle;
    [SerializeField] Image fill;
    [SerializeField] Text valTxt;
    public GameObject shuigang;
    Vector3 mousePos;

    public void onHandleDrag()
    {
        mousePos = Input.mousePosition;
        Vector2 dir = mousePos - handle.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle = (angle <= 0) ? (360 + angle) : angle;

        if (angle <= 225 || angle >= 315)
        {
            Quaternion r = Quaternion.AngleAxis(angle + 135f, Vector3.forward);
            Quaternion r1=Quaternion.AngleAxis(angle+135f , Vector3.right);
            handle.rotation = r;
            angle = ((angle >= 315) ? (angle - 360) : angle) + 45;
            fill.fillAmount = 0.75f - (angle / 360f);
            shuigang.transform.localRotation = Quaternion.Euler(0, 0, 0);
            //Debug.Log(r1);
            shuigang.transform.rotation = r1;
            
            valTxt.text = Mathf.Round((fill.fillAmount * 100) / 0.75f).ToString();
        }
    }
}
