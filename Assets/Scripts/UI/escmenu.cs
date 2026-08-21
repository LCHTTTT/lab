using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class escmenu : MonoBehaviour
{
    //不用细看，有一些是因为其他效果实现而创建的
    public GameObject MenueCanvas;
    public bool IsShow;
    private bool IsCounting;
    public Text LifeText;
    public Text CountText;
    public Text EndText;

    void Start()
    {
        MenueCanvas.SetActive(false);
        IsShow = false;
        Time.timeScale = (1);
    }

    public void jxsy()
    {
        MenueCanvas.SetActive(false);
        IsShow = false;
        Time.timeScale = (1);
    }


    void Update()
    {
        //判断是否按下Esc键
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //如果面板正在显示，关掉面板并让游戏继续运行
            if (IsShow)
            {
                MenueCanvas.SetActive(false);
                IsShow = false;
                Time.timeScale = (1);
            }
            //否则开启面板并暂停游戏
            else
            {
                MenueCanvas.SetActive(true);
                IsShow = true;
                Time.timeScale = (0);
            }
        }
    }
}