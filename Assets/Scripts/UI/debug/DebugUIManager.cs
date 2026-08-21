using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class DebugUIManager : MonoBehaviour
{
    [SerializeField] private Text fpsText;//fps
    [SerializeField] private Text heapSizeText;//堆内存
    [SerializeField] private Text usedSizeText;//使用大小
    [SerializeField] private Text allocatedMemoryText;//Unity分配
    [SerializeField] private Text reservedMemoryText;//总内存
    [SerializeField] private Text unusedReservedMemoryText;//未使用内存

    private int _index = 1;
    private int _indexCount = 100;//更新间隔

    private const long Kb = 1024;
    private const long Mb = 1024 * 1024;

    private float updateInterval = 1f;//更新间隔
    private int frames;
    private float fps;
    private float lastInterval;
    private float timeNow;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
        fps = 0.0f;
    }

    private void Update()
    {
        if (!gameObject.activeSelf) return;

        _index++;
        if (_index == _indexCount)
        {
            ShowProfilerMsg();
        }

        frames++;
        timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            ShowFPSMsg();
        }

    }

    private void ShowProfilerMsg()
    {
        _index = 0;
        //堆内存
        if (heapSizeText)
        {
            heapSizeText.text = "堆内存 : " + Profiler.GetMonoHeapSizeLong() / Mb + " Mb";
        }

        //使用的
        if (usedSizeText)
        {
            usedSizeText.text = "使用大小 : " + Profiler.GetMonoUsedSizeLong() / Mb + " Mb";
        }

        // unity分配
        if (allocatedMemoryText)
        {
            allocatedMemoryText.text = "Unity分配 : " + Profiler.GetTotalAllocatedMemoryLong() / Mb + " Mb";
        }

        // 总内存
        if (reservedMemoryText)
        {
            reservedMemoryText.text = "总内存 : " + Profiler.GetTotalReservedMemoryLong() / Mb + " Mb";
        }

        // 未使用内存
        if (unusedReservedMemoryText)
        {
            unusedReservedMemoryText.text = "未使用内存 : " + Profiler.GetTotalUnusedReservedMemoryLong() / Mb + " Mb";
        }
    }

    /// <summary>
    /// 显示FPS信息
    /// </summary>
    private void ShowFPSMsg()
    {
        if (!fpsText) return;
        fps = frames / (timeNow - lastInterval);
        fpsText.text = fps.ToString("F2");
        frames = 0;
        lastInterval = timeNow;
    }

    /// <summary>
    /// 页面开关
    /// </summary>
    public void ShowAndHide()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }


}