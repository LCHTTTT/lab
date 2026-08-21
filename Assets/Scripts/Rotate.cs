using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 90度平滑转动
 * 由点击触发
 * 转动所需时间为t
 * 则转动所需要的帧数为fps*t
 * 每一帧转动一次
 * 每次转动的角度为(sin((n/(fps*t))*(PI/2))-sin((n-1)/(fps*t)*(PI/2)))*angle,这里设置angle为90度
 */

public class Rotate : MonoBehaviour
{
    float fps;          //帧率
    float t;            //旋转所需的时间
    float PI;           //π
    float currentFrame; //当前帧n
    bool rot;           //是否在旋转的标识
    // Start is called before the first frame update
    void Start()
    {
        fps = 60.0f;
        t = 1f;
        PI = 3.14159f;
        currentFrame = 0.0f;
        rot = false;
    }

    // Update is called once per frame
    void Update()
    {
        //示例:绕y轴转动
        if (rot)
        {
            if(xuanniu.xnflag==0)
            { 
                currentFrame += 1.0f;
                transform.Rotate(0
                    , (Mathf.Sin(currentFrame / (fps * t) * (PI / 2.0f)) - Mathf.Sin((currentFrame - 1) / (fps * t) * (PI / 2.0f))) * 120
                    , 0);
                if (currentFrame > fps * t)
                {
                    rot = false;
                    currentFrame = 0.0f;
                }
                //print(currentFrame);
            }
            if (xuanniu.xnflag == 1)
            {
                currentFrame += 1.0f;
                transform.Rotate(0
                    , (Mathf.Sin(currentFrame / (fps * t) * (PI / 2.0f)) - Mathf.Sin((currentFrame - 1) / (fps * t) * (PI / 2.0f))) * -120
                    , 0);
                if (currentFrame > fps * t)
                {
                    rot = false;
                    currentFrame = 0.0f;
                }
                //print(currentFrame);
            }
        }
    }

    public void OnMouseUp()
    {
        //鼠标点击时若未在旋转则将标识置为真
        if (!rot)
        {
            rot = true;
        }
    }
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;     //关闭垂直同步
        Application.targetFrameRate = (int)fps; //设置帧率
    }
}

