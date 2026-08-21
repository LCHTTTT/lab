using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movieplus : MonoBehaviour
{
    private GameObject panel;
    // Use this for initialization
    void Start()
    {
        panel = GameObject.Find("Canvas/Panel");
        GameObject obj = Instantiate(Resources.Load<GameObject>("Assets/ZVideoPlayer/Prefabs/VideoPlayer.prefab"));
        obj.transform.SetParent(panel.transform);
        obj.transform.position = new Vector3(10, Screen.height - 10, 0);
    }
}
