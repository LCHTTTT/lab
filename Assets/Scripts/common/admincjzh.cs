using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class admincjzh : MonoBehaviour
{
    // Start is called before the first frame update
    public void houtai()
    {
        SceneManager.LoadScene(7);
    }
    public void sctm()
    {
        SceneManager.LoadScene(8);
    }
    public void cjck()
    {
        SceneManager.LoadScene(6);
    }
    public void zx()
    {
        SceneManager.LoadScene(0);
        Destroy(GameObject.Find("chuanzhi"));
    }
}
