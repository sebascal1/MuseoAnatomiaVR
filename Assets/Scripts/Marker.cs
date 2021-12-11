using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Marker : MonoBehaviour
{
    public TextMeshProUGUI title;
    [SerializeField] Vector3 canvasRotationOffset;
    public Transform userLocation;
    public Canvas canvas;
    float turnSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        title.enabled = false;
        userLocation = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //canvas.transform.LookAt(Camera.main.transform, Vector3.up);
        Vector3 LookAtDirection = -(userLocation.transform.position - canvas.transform.position).normalized;
        LookAtDirection.y = 0;
        Quaternion to = Quaternion.LookRotation(LookAtDirection, Vector3.up);
        canvas.transform.rotation = Quaternion.RotateTowards(canvas.transform.rotation, to, turnSpeed);

    }

    private void OnMouseOver()
    {
        Debug.Log("Its over the marker");
        title.enabled = true;
        //Get the title to be looking at the camera at all times

    }

    private void OnMouseExit()
    {
        Debug.Log("It just left the marker");
        title.enabled = false;
    }
}
