using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Label : MonoBehaviour
{
    public TextMeshProUGUI label;
    public string labelText;
    Transform userPlane;
    public float turnSpeed = 100f;
    private Vector3 originalGlobalPos;
    [SerializeField] GameObject background;
    public bool _IsPressed = false;

    [TextArea(15, 20)]
    public string Description = "";


    [SerializeField] GameObject shaderObject;
    private InformationPanel infoPanel;

    private void Awake()
    {
        infoPanel = GameObject.Find("InformationPanel").GetComponent<InformationPanel>();
    }

    // Start is called before the first frame update
    void Start()
    {
        label.text = labelText;
        userPlane = Camera.main.transform;
        originalGlobalPos = this.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        //We wamt the object to always be facing the camera of the viewer, or at least the parallel plane
        turnLabelToCamera();

        if (!(infoPanel.header.text == labelText) && _IsPressed)
        {
            background.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            _IsPressed = false;
            showHighlightArea(false);
        }

    }

    void turnLabelToCamera()
    {
        //get the vector between the two items
        Vector3 LookAtDirection = -(userPlane.transform.position - this.transform.position).normalized;
        //Set the look at direction in the y and x axis to 0 so that it doesnt turn in those directions;
        LookAtDirection.y = 0;
        LookAtDirection.x = 0;
        //get the equivalent quaternion
        Quaternion to = Quaternion.LookRotation(LookAtDirection, Vector3.up);
        //rotate the object.
        Vector3 pos = this.transform.position;
        //pos.y = originalGlobalPos.y;
        //this.transform.position = originalGlobalPos;
        this.transform.position = pos;
        
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, to, turnSpeed);

       
    }

    public void showInfoPanel()
    {
        infoPanel.ShowWindow();
        infoPanel.header.text = labelText;
        infoPanel.information.text = Description;

        background.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        _IsPressed = true;
        showHighlightArea(true);
    }

    public void showHighlightArea(bool isSelected)
    {
        if(shaderObject) shaderObject.SetActive(isSelected);
    }
}
