using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{

    public Button bf,zt;//存放按钮组件
    public VideoPlayer Myvideo;//存放视频播放组件
    bool isPlaying = false;
    void Start()
    {
        Myvideo.Stop();
        bf.onClick.AddListener(delegate
        {
            Myvideo.Play();
        });
        zt.onClick.AddListener(delegate
        {
            Myvideo.Stop();
        });
    }


    void PlayVideoMoth()
    {
        //播放视频
        if (!Myvideo.isPlaying)
        {
            Myvideo.Play();
            isPlaying = true;
        }
        else if (Myvideo.isPlaying)
        {
            //Myvideo.Stop(); // 停止播放视频（视频回到起点）
            Myvideo.Pause();//视频暂停
        }
    }
}