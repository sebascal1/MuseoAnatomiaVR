using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ViewItem : MonoBehaviour
{
    protected Vector3 posLastFrame;
    public float scale = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        posLastFrame = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            posLastFrame = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            TurnItem();
        }

        if (Input.mouseScrollDelta.y != 0)
        {
            ZoomItem();
        }*/
    }

    private void TurnItem()
    {
        var delta = Input.mousePosition - posLastFrame;
        posLastFrame = Input.mousePosition;

        var axis = Quaternion.AngleAxis(-90f, Vector3.forward) * delta;
        transform.rotation = Quaternion.AngleAxis(delta.magnitude * 0.1f, axis) * transform.rotation;
    }

    private void ZoomItem()
    {
        Vector3 pos = transform.position;
        pos.z += Input.mouseScrollDelta.y * scale;
        transform.position = pos;
    }
}
