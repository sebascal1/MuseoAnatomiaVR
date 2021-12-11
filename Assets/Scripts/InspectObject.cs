using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectObject : MonoBehaviour
{
    [SerializeField] CanvasManager canvasPanel;


    // Start is called before the first frame update
    void Start()
    {
        canvasPanel.inViewMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !canvasPanel.inViewMode)
        {
            Debug.Log(canvasPanel.inViewMode);
            SendRayCast();
        }

    }
    private void SendRayCast()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            //If the hit object is a museum item then activate the canvas
            if (hit.transform.gameObject.tag == "MuseumItem")
            {
                string prefabName = hit.transform.gameObject.name;
                Debug.Log("Hit a museum item!");
                canvasPanel.inViewMode = true;
                canvasPanel.ShowCanvas(prefabName);
            }

        }
    }
}
