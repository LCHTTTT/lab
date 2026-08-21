using UnityEngine;
using UnityEngine.UI;
using System.Text;
using DG.Tweening;

public class DebugMsge : MonoBehaviour
{
    public Text logText;
    public RectTransform content;
    public Scrollbar bar;//竖向滚动条

    private int count = 0;
    StringBuilder MyStrBulder;
    private bool isUpdate = false;


    public void AddText(string str)
    {
        isUpdate = true;
        MyStrBulder.AppendFormat("{0}:{1}\n", count, str);
        count++;
        isUpdate = false;
    }

    void Awake()
    {
        MyStrBulder = new StringBuilder();

        //核心方法就是Application.logMessageReceived这个事件
        Application.logMessageReceived += HandleLog;
    }

    void HandleLog(string message, string stackTrace, LogType type)
    {
        switch (type)
        {
            case LogType.Error:
                message = "<color=#FF0000>" + message + "</color>";
                break;
            case LogType.Assert:
                message = "<color=#0000ff>" + message + "</color>";
                break;
            case LogType.Warning:
                message = "<color=#EEEE00>" + message + "</color>";
                break;
            case LogType.Log:
                message = "<color=#000000>" + message + "</color>";
                break;
            case LogType.Exception:
                break;
            default:
                break;
        }

        AddText(message);
        onSkipToBottomShow();
    }

    // Update is called once per frame
    void Update()
    {
        logText.text = MyStrBulder.ToString();
    }

    /// <summary>
    /// 跳转至底部显示（使竖向滚动条的value保持为0即可）
    /// </summary>
    private void onSkipToBottomShow()
    {
        DOTween.To(() => bar.value = 0, v => bar.value = v, 0, 0.1f).SetEase(Ease.InElastic);
    }

}