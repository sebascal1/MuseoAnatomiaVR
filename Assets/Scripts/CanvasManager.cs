using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    GameObject prefabInstance;
    public Canvas parentCanvas;
    string prefabDirectory = "Prefabs/";
    public bool inViewMode;
    public TextMeshProUGUI title;
    [SerializeField] InformationPanel infoPanel;


    // Start is called before the first frame update
    void Awake()
    {
        inViewMode = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateViewableObject(string prefabName)
    {
        Debug.Log(prefabName);
        if (prefabInstance == null)
        {
            prefabInstance = Instantiate(Resources.Load(prefabDirectory + prefabName)) as GameObject;
            //prefabInstance.transform.parent = Camera.main.transform;
            Vector3 initialPosition = Camera.main.transform.position;
            initialPosition += new Vector3(0f, -0.75f, 5f);
            prefabInstance.transform.localPosition = initialPosition;
            prefabInstance.AddComponent<ViewItem>();

        }

    }

    public void ShowCanvas(string prefabName)
    {
        Vector3 initialPosition = Camera.main.transform.position;
        initialPosition += new Vector3(0f, -0.66f, 5f);

        parentCanvas.transform.position = initialPosition;
        gameObject.SetActive(true);
        CreateViewableObject(prefabName);
        Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("MuseumItem")); //Turns on the culling mask for the museum items;
        title.text = prefabName;
    }

    public void HideCanvas()
    {
        inViewMode = false;
        Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("MuseumItem"); //Turns off the culling mask for the museum items;
        gameObject.SetActive(false);
        Destroy(prefabInstance);
        
    }
}
