using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MuseumItem : MonoBehaviour
{
    [SerializeField] CanvasManager canvasPanel;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectItem()
    {
        string prefabName = gameObject.name;
        Debug.Log("Hit a museum item!");
        if (!canvasPanel.inViewMode)
        {
             canvasPanel.inViewMode = true;
             canvasPanel.ShowCanvas(prefabName);
        }
    }
}
