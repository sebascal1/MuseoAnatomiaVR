using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lr;
    [SerializeField] private Transform[] points;
    public bool leftSideLabel = false;

    // Start is called before the first frame update
    void Start()
    {
       SetUpLine(points);
    }

    private void Awake()
    {
       lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i< points.Length; i++)
        {
            if(leftSideLabel && i == 1)
            {
                Vector3 pos = points[1].position;
                pos.x += 2.5f;
                lr.SetPosition(i, pos);
            } else
            {
                lr.SetPosition(i, points[i].position);
            }
            
        }
    }

    public void SetUpLine(Transform[] points)
    {
        lr.positionCount = points.Length;
        this.points = points;
    }
}
