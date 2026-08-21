using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jinrushiyan : MonoBehaviour
{
    private Ray ra;
    private RaycastHit hit;
    public GameObject dmtip,mb;
    public Button wxh;
    // Start is called before the first frame update
    private void Start()
    {
        dmtip.gameObject.SetActive(false);
        mb.gameObject.SetActive(true);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ra = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ra, out hit) && hit.collider.name == "Door 1")
            {
                dmtip.gameObject.SetActive(true);
            }
        }
    }
    public void hwxh()
    {
        dmtip.gameObject.SetActive(false);
    }
}
