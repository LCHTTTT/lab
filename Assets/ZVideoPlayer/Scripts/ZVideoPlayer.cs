/*
 **  视频播放器 -- by JacobKay 20220323
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace ZTools
{
    [RequireComponent(typeof(ZVideoPlayerModel))]
    public class ZVideoPlayer : MonoBehaviour
    {
        ZVideoPlayerModel model;
        /// <summary>
        /// 当前播放器是否在播放
        /// </summary>
        public bool IsVideoPlaying
        {
            get { return model.IsVideoPlaying; }
        }
        /// <summary>
        /// 获取视频播放时间
        /// </summary>
        public double PlayTime
        {
            set
            {
                model.PlayTime = value;
                if (!IsVideoPlaying)
                {
                    Play();
                }
            }
            get
            {
                return Mathf.Floor((float)model.PlayTime);
            }
        }
        /// <summary>
        /// 全屏
        /// </summary>
        public bool FullScreen
        {
            set { model.FullScreen(value); }
        }
        /// <summary>
        /// 设置视频url
        /// </summary>
        public string VideoUrl
        {
            set { model.VideoSource(value); }
        }
        public int VideoVolum
        {
            set { model.VideoVolum = value; }
        }
        /// <summary>
        /// 设置视频资源，VideoClip
        /// </summary>
        public VideoClip VideoClip
        {
            set { model.VideoSource(value); }
        }
        /// <summary>
        /// 设置视频是否为循环播放
        /// </summary>
        public bool Loop
        {
            set
            {
                model.Loop = value;
            }
            get
            {
                return model.Loop;
            }
        }
        private void Awake()
        {
            model = this.GetComponent<ZVideoPlayerModel>();
        }
        /// <summary>
        /// 控制视频播放
        /// </summary>
        public void Play()
        {
            model.Play();
        }
        /// <summary>
        /// 控制视频暂停
        /// </summary>
        public void Pause()
        {
            model.Pause();
        }
        /// <summary>
        /// 控制视频暂停
        /// </summary>
        public void Stop()
        {
            model.Stop();
        }
    }
}
