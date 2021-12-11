using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewLabel : MonoBehaviour
{
    public GameObject marker;
    Collider markerCollider;
    public GameObject label;
    [SerializeField] Label labelInfo;
    public LineRenderer line;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    private InformationPanel infoPanel;



    // Start is called before the first frame update
    void Awake()
    {
        markerCollider = marker.GetComponent<Collider>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        /*
        if (iCanSeeObject(markerCollider))
        {
            label.SetActive(true);
        }
        else
        {
            label.SetActive(false);
        }
        */

        label.SetActive(isFacingCamera() || labelInfo._IsPressed);
        //print(isItemVisible());
    }

    bool isItemVisible()
    {
        RaycastHit hit;
        Transform target = Camera.main.transform;
        float distToTarget = Vector3.Distance(marker.transform.position, target.position);
        Vector3 dirToTarget = (target.position - marker.transform.position).normalized;

        if(Physics.Raycast(marker.transform.position, dirToTarget, out hit, distToTarget))
        {
            print(hit.transform.gameObject.layer);
        }

        return Physics.Raycast(marker.transform.position, dirToTarget, out hit, distToTarget, obstacleMask);
    }

    private bool isFacingCamera()
    {
        float dotProdWithCamera = Vector3.Dot(-label.transform.forward, Vector3.forward);
        //print($"{label} dot prouduct is {dotProdWithCamera}");

        return dotProdWithCamera < -0.8;

    }

    /*private void OnDrawGizmos()
    {
        Transform target = Camera.main.transform;
        float distToTarget = Vector3.Distance(marker.transform.position, target.position);
        Vector3 dirToTarget = (target.position - marker.transform.position).normalized;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(marker.transform.position, dirToTarget * distToTarget);
    }*/

    /*private void OnBecameVisible()
    {
        label.SetActive(true);
    }

    private void OnBecameInvisible()
    {
        label.SetActive(false);
    }*/
}
