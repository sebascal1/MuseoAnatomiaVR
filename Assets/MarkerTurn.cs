using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerTurn : MonoBehaviour
{

    float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        turnLabelToCamera();
    }

    void turnLabelToCamera()
    {
        //get the vector between the two items
        Vector3 LookAtDirection = -(Camera.main.transform.position - gameObject.transform.position).normalized;
        //Set the look at direction in the y and x axis to 0 so that it doesnt turn in those directions;
        LookAtDirection.y = 0;
        LookAtDirection.z = 0;
        //get the equivalent quaternion
        Quaternion to = Quaternion.LookRotation(LookAtDirection, Vector3.right);
        //rotate the object.
        gameObject.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, to, turnSpeed);
    }
}
