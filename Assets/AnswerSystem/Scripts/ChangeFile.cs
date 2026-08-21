using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System;

public class ChangeFile : MonoBehaviour
{
    public Button OpenFile;
    public InputField tm;
    public static String lj;
    private void Start()
    {
        OpenFile.onClick.AddListener(delegate () { OnOpenFile();sctm.gszq = 0; });
    }

    void OnOpenFile()
    {
        OpenFileName openFileName = new OpenFileName();
        openFileName.structSize = Marshal.SizeOf(openFileName);
        openFileName.filter = "TXT文件(*.txt)\0*.txt"; //xlsx
        openFileName.file = new string(new char[256]);
        openFileName.maxFile = openFileName.file.Length;
        openFileName.fileTitle = new string(new char[64]);
        openFileName.maxFileTitle = openFileName.fileTitle.Length;
        openFileName.initialDir = Application.streamingAssetsPath.Replace('/', '\\');//默认路径
        openFileName.title = "文件选择";//窗口标题
        openFileName.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000008;


        if (LocalDialog.GetSaveFileName(openFileName))
        {
            Debug.Log("打开的文件路径：" + openFileName.file);
            Debug.Log("文件名：" + openFileName.fileTitle);
        }
        lj = openFileName.file;
        StartCoroutine(WWWRead());
    }
    private IEnumerator WWWRead()
    {
        WWW www = new WWW("file:///" + lj);
        if (www.error != null)
        {
            Debug.Log("error while reading files : " + lj);
        }
        while (!www.isDone) { }
        Debug.Log("打印读取txt：" + www.text);
        tm.text = www.text;
        yield return null;
    }
}