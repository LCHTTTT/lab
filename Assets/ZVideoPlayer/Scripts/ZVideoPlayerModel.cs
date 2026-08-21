/*
 **  视频播放器 -- by JacobKay 20220323
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;
using System;

namespace ZTools
{
    public class ZVideoPlayerModel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        [Header("触屏模式")]
        private bool InTouch = false;
        [SerializeField]
        [Header("自适应模式")]
        private bool selfAdaption = false;
        [SerializeField]
        [Header("操作UI显示时间(s)")]
        [Range(1, 10)]
        private int stateShowTime;
        [SerializeField]
        [Header("是否循环播放")]
        private bool loop;
        [Header("------------------------------------------------------------------------")]
        [SerializeField]
        private VideoPlayer videoPlayer;
        [SerializeField]
        private RenderTexture renderTexture;
        [SerializeField]
        private Image btnPlay;
        [SerializeField]
        private Sprite spritePlay;
        [SerializeField]
        private Sprite spritePause;
        [SerializeField]
        private Slider sliderTime;
        [SerializeField]
        private Text txtTime;
        [SerializeField]
        private Text txtLength;
        [SerializeField]
        private Image btnSound;
        [SerializeField]
        private Sprite spriteSound;
        [SerializeField]
        private Sprite spriteMute;
        [SerializeField]
        private GameObject sliderSoundBox;
        [SerializeField]
        private Slider sliderSound;
        [SerializeField]
        private Text txtSound;
        [SerializeField]
        private Image btnFull;
        [SerializeField]
        private Sprite spriteFull;
        [SerializeField]
        private Sprite spriteNonFull;
        [SerializeField]
        private RectTransform funBox;
        private GameObject funBoxMask;
        [SerializeField]
        private Button ShowFunBoxBtn;
        public Image stateBtn;
        public Sprite stateSpritePlay;
        public Sprite stateSpriteStop;

        public string TxtLength
        {
            set { txtLength.text = value; }
        }
        public double PlayTime
        {
            set
            {
                videoPlayer.time = value;
                sliderTime.value = (float)(value / VideoLength);
            }
            get { return videoPlayer.time; }
        }
        public VideoSource Source
        {
            set { videoPlayer.source = value; }
            get { return videoPlayer.source; }
        }
        public string Url
        {
            set { videoPlayer.url = value; }
            get { return videoPlayer.url; }
        }
        public VideoClip Clip
        {
            set { videoPlayer.clip = value; }
            get { return videoPlayer.clip; }
        }
        public bool IsVideoPlaying
        {
            get { return videoPlayer.isPlaying; }
        }
        public float VideoVolum
        {
            set
            {
                audioSource.volume = value / 100;
                txtSound.text = value.ToString();
                sliderSound.value = value / 100;
            }
        }
        public double VideoLength
        {
            get
            {
                return (isClip ? videoPlayer.clip.length : videoPlayer.length);
            }
        }
        public bool Loop
        {
            set
            {
                videoPlayer.isLooping = value;
            }
            get
            {
                return videoPlayer.isLooping;
            }
        }

        private RectTransform rectTransform;

        private Vector2 oriSize;
        private Vector3 oriPostion;
        private int screenWidth;
        private int screenHeight;
        private AudioSource audioSource;
        private bool isVideoPlayEnd = false;
        private bool isClip = false;
        private bool isFull = false;
        private float funBoxHeight;
        private CanvasGroup funBoxGroup;
        private bool stateShowType = false;
        private long showStartTime = 0;
        int cullMask;
        Canvas parent;

        private void Awake()
        {
            Init();
            if (videoPlayer.playOnAwake)
            {
                AutoPlay();
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            Loop = loop;
            parent = transform.GetComponentInParent<Canvas>();
            funBoxHeight = funBox.sizeDelta.y;
            funBoxMask = funBox.Find("Mask").gameObject;
            funBoxGroup = funBox.GetComponent<CanvasGroup>();
            rectTransform = this.GetComponent<RectTransform>();
            screenWidth = Screen.width;
            screenHeight = Screen.height;
            oriSize = rectTransform.sizeDelta;
            oriPostion = rectTransform.localPosition;
            renderTexture.width = selfAdaption ? screenWidth - (int)oriSize.x : (int)oriSize.x;
            renderTexture.height = selfAdaption ? screenHeight - (int)oriSize.y : (int)oriSize.y;
            audioSource = videoPlayer.GetComponent<AudioSource>();
            if (videoPlayer.playOnAwake)
            {
                btnPlay.sprite = spritePause;
                if (InTouch)
                {
                    stateBtn.sprite = stateSpriteStop;
                }
            }
            else
            {
                btnPlay.sprite = spritePlay;
                if (InTouch)
                {
                    stateBtn.sprite = stateSpritePlay;
                }
            }
            ShowFunBox();
            // 播放按钮事件
            btnPlay.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (IsVideoPlaying)
                    Pause();
                else
                    Play();
            });
            // 声音调节按钮事件
            btnSound.GetComponent<Button>().onClick.AddListener(() =>
            {
                sliderSoundBox.SetActive(!sliderSoundBox.activeInHierarchy);
            });
            // 声音滑块事件
            sliderSound.onValueChanged.AddListener((float idx) =>
            {
                if (idx == 0)
                    btnSound.sprite = spriteMute;
                else
                {
                    if (btnSound.sprite != spriteSound)
                    {
                        btnSound.sprite = spriteSound;
                    }
                }
                audioSource.volume = idx;
                txtSound.text = ((int)(idx * 100)).ToString();
            });
            // 全屏按钮事件
            btnFull.GetComponent<Button>().onClick.AddListener(() =>
            {
                FullScreen(!isFull);
            });
            ShowFunBoxBtn.onClick.AddListener(() =>
            {
                if (sliderSoundBox.activeInHierarchy)
                {
                    sliderSoundBox.SetActive(false);
                }
                if (stateShowType)
                {
                    HideFunBox();
                }
                else
                {
                    ShowFunBox();
                }
            });
            stateBtn.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (IsVideoPlaying)
                    Pause();
                else
                {
                    Play();
                    HideFunBox();
                }
            });
        }
        /// <summary>
        /// 如果初始有视频资源，走正常流程播放
        /// </summary>
        void AutoPlay()
        {
            videoPlayer.Stop();
            if (videoPlayer.source == UnityEngine.Video.VideoSource.Url)
            {
                if (!string.IsNullOrEmpty(videoPlayer.url))
                {
                    VideoSource(videoPlayer.url);
                }
            }
            else
            {
                if (null != videoPlayer.clip)
                {
                    VideoSource(videoPlayer.clip);
                }
            }
        }
        /// <summary>
        /// 全屏
        /// </summary>
        public void FullScreen(bool full)
        {
            if (full)
            {
                //全屏
                if (selfAdaption)
                {
                    rectTransform.sizeDelta = Vector2.zero;
                }
                else
                {
                    rectTransform.sizeDelta = new Vector2(screenWidth, screenHeight);
                }
                parent.enabled = false;
                rectTransform.localPosition = Vector3.zero;
                btnFull.sprite = spriteNonFull;
                Canvas can = this.gameObject.AddComponent<Canvas>();
                can.overrideSorting = true;
                can.sortingOrder = 20;
                this.gameObject.AddComponent<GraphicRaycaster>();
                isFull = true;
                if (null != Camera.main)
                {
                    cullMask = Camera.main.cullingMask;
                    Camera.main.cullingMask = 0;
                }
            }
            else
            {
                //非全屏
                rectTransform.sizeDelta = oriSize;
                rectTransform.localPosition = oriPostion;
                btnFull.sprite = spriteFull;
                parent.enabled = true;
                Destroy(this.gameObject.GetComponent<GraphicRaycaster>());
                Destroy(this.gameObject.GetComponent<Canvas>());
                isFull = false;
                if (null != Camera.main)
                {
                    Camera.main.cullingMask = cullMask;
                }
            }
        }

        /// <summary>
        /// 视频播放
        /// </summary>
        public void Play()
        {
            videoPlayer.Play();
            isVideoPlayEnd = false;
            btnPlay.sprite = spritePause;
            if (InTouch)
            {
                stateBtn.sprite = stateSpriteStop;
            }
        }
        /// <summary>
        /// 视频暂停
        /// </summary>
        public void Pause()
        {
            videoPlayer.Pause();
            btnPlay.sprite = spritePlay;
            if (InTouch)
            {
                stateBtn.sprite = stateSpritePlay;
            }
        }
        /// <summary>
        /// 视频停止
        /// </summary>
        public void Stop()
        {
            videoPlayer.Stop();
            ShowFunBox();
            isVideoPlayEnd = true;
            PlayTime = 0;
            btnPlay.sprite = spritePlay;
            if (InTouch)
            {
                stateBtn.sprite = stateSpritePlay;
            }
        }
        /// <summary>
        /// 设置视频链接
        /// </summary>
        /// <param name="url"></param>
        public void VideoSource(string url)
        {
            if (IsVideoPlaying)
            {
                Stop();
            }
            Source = UnityEngine.Video.VideoSource.Url;
            Url = url;
            videoPlayer.Prepare();
            videoPlayer.prepareCompleted += VideoComplete;
        }
        /// <summary>
        /// 设置视频资源
        /// </summary>
        /// <param name="clip"></param>
        public void VideoSource(VideoClip clip)
        {
            if (IsVideoPlaying)
            {
                Stop();
            }
            Source = UnityEngine.Video.VideoSource.VideoClip;
            Clip = clip;
            videoPlayer.Prepare();
            videoPlayer.prepareCompleted += VideoComplete;
        }
        void VideoComplete(VideoPlayer video)
        {
            isVideoPlayEnd = false;
            TxtLength = GetVideoTime(VideoLength);
            Play();
        }
        /// <summary>
        /// 更新进度条和时间
        /// </summary>
        private void FixedUpdate()
        {
            if (IsVideoPlaying)
            {
                if (GetTimeMillion() - showStartTime >= (stateShowTime * 1000) && stateShowType)
                {
                    stateShowType = false;
                    HideFunBox();
                }
                txtTime.text = GetVideoTime(PlayTime);
                sliderTime.value = (float)(PlayTime / VideoLength);
                if (VideoLength - PlayTime < 0.1f)
                {
                    if (!Loop)
                    {
                        Stop();
                    }
                }
            }
        }

        /// <summary>
        /// 手动调节进度，按下时暂停播放
        /// </summary>
        public void SliderPointerDown()
        {
            Pause();
        }
        /// <summary>
        /// 手动调节进度，抬起时继续播放
        /// </summary>
        public void SliderPointerUp()
        {
            videoPlayer.time = sliderTime.value * VideoLength;
            isVideoPlayEnd = false;
            Play();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!isFull && !InTouch)
            {
                ShowFunBox();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!isFull && !InTouch)
            {
                HideFunBox();
            }
        }
        void ShowFunBox()
        {
            funBoxGroup.alpha = 1;
            funBoxMask.SetActive(false);
            stateShowType = true;
            showStartTime = GetTimeMillion();
            if (InTouch)
            {
                stateBtn.gameObject.SetActive(true);
                stateBtn.sprite = (IsVideoPlaying) ? stateSpriteStop : stateSpritePlay;
            }
        }
        void HideFunBox()
        {
            stateShowType = false;
            if (sliderSoundBox.activeInHierarchy)
            {
                sliderSoundBox.SetActive(false);
            }
            funBoxGroup.alpha = 0;
            funBoxMask.SetActive(true);
            if (InTouch)
            {
                stateBtn.gameObject.SetActive(false);
            }
        }
        /// <summary>
        /// 格式化播放时间
        /// </summary>
        public string GetVideoTime(double playTime)
        {
            if (VideoLength >= 3600)
            {
                int clipHour = (int)(playTime) / 3600;
                int clipMinute = (int)(playTime - clipHour * 3600) / 60;
                int clipSecond = (int)(playTime - clipHour * 3600 - clipMinute * 60);
                return string.Format("{0:D2}:{1:D2}:{2:D2}", clipHour, clipMinute, clipSecond);
            }
            else
            {
                int clipMinute = (int)(playTime) / 60;
                int clipSecond = (int)(playTime - clipMinute * 60);
                return string.Format("{0:D2}:{1:D2}", clipMinute, clipSecond);
            }
        }
        private void OnDisable()
        {
            sliderTime.value = 0;
            txtTime.text = "00:00";
            renderTexture.Release();
            videoPlayer.prepareCompleted -= VideoComplete;
        }
        private void OnDestroy()
        {
            sliderTime.value = 0;
            txtTime.text = "00:00";
            renderTexture.Release();
            videoPlayer.prepareCompleted -= VideoComplete;
        }
        private static long unixBaseMillis = new DateTime(1970, 1, 1, 0, 0, 0).ToFileTimeUtc() / 10000;
        long GetTimeMillion()
        {
            return (DateTime.Now.ToFileTimeUtc() / 10000) - unixBaseMillis;
        }
    }
}
