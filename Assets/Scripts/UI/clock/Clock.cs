using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    int hour = 0;    //小时
    int minute = 0;  //分钟
    int second = 0;  //秒
    float timer = 0f;
    string timeStr = string.Empty;
    public Text timexs;
    bool flag = false;
    public Button ks, zt, cz;


    void Update()
    {
        if (flag == true)
        {

            timer += Time.deltaTime;

            if (timer >= 1f)
            {
                second++;
                timer = 0;
            }
            if (second >= 60)
            {
                minute++;
                second = 0;
            }
            if (minute >= 60)
            {
                hour++;
                minute = 0;
            }
            if (hour >= 99)
            {
                hour = 0;
            }
        }
    }

    void OnGUI()
    {
        timeStr = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
        timexs.text = timeStr;
        //GUI.Label(new Rect(10, 10, 100, 200), timeStr);
    }
    public void biaoks()
    {
        flag = true;
    }
    public void biaozt()
    {
        flag = false;
    }
    public void biaocz()
    {
        hour = 0;    //小时
        minute = 0;  //分钟
        second = 0;  //秒
    }
}

