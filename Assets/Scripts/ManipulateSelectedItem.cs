using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManipulateSelectedItem : MonoBehaviour
{
    //Setup interaction controls;
    public InputActionReference AxisMovementY = null;
    public InputActionReference AxisMovementX = null;

    public InputActionReference displacementX = null;
    public InputActionReference displacementY = null;

    public InputActionReference zoomIn = null;
    public InputActionReference zoomOut = null;

    float speed = 0.1f;
    float zoomSpeed = 0.05f;

    GlobalSettings settings;

    private void Awake()
    {
        settings = GameObject.Find("MenuPanel").GetComponent<GlobalSettings>();
    }

    // Update is called once per frame
    void Update()
    {

            float valueY = AxisMovementY.action.ReadValue<float>();
            float valueX = AxisMovementX.action.ReadValue<float>();

            float valueYDisplacement = displacementY.action.ReadValue<float>();
            float valueXDisplacement = displacementX.action.ReadValue<float>();

            float zoomInValue = zoomIn.action.ReadValue<float>();
            float zoomOutValue = zoomOut.action.ReadValue<float>();

            if (valueY != 0)
            {
                valueY *= invertedAxis(settings._invertY);
                gameObject.transform.Rotate(Vector3.right, valueY, Space.World);
            }

            if (valueX != 0)
            {
                valueX *= invertedAxis(settings._invertX);
                gameObject.transform.Rotate(Vector3.up, valueX, Space.World);
            }

            if (Mathf.Abs(valueYDisplacement) >= 0.5f)
            {
                Vector3 pos = gameObject.transform.position;
                pos.y += valueYDisplacement * speed;
                gameObject.transform.position = pos;
            }

            if (Mathf.Abs(valueXDisplacement) >= 0.5f)
            {
                Vector3 pos = gameObject.transform.position;
                pos.x += valueXDisplacement * speed;
                gameObject.transform.position = pos;
            }

            if (zoomInValue != 0)
            {
                Vector3 pos = gameObject.transform.position;
                pos.z += -zoomInValue * zoomSpeed;
                gameObject.transform.position = pos;
            }

            if (zoomOutValue != 0)
            {
                Vector3 pos = gameObject.transform.position;
                pos.z += zoomOutValue * zoomSpeed;
                gameObject.transform.position = pos;
            }
        
    }

    public int invertedAxis(bool axisBool)
    {
        if (axisBool)
        {
            return 1;
        }

        return -1; 
    }
}
