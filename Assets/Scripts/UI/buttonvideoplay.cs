using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System;


public class buttonvideoplay : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer p;
    public Button btn;
    public VideoClip vo;
    void Start()
    {
        btn.onClick.AddListener(delegate
        {
            p.GetComponent<VideoPlayer>().clip = vo;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
