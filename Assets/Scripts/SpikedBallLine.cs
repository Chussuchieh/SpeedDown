using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBallLine : MonoBehaviour
{
    LineRenderer lineRenderer;
    public Transform startPoint;
    public Transform endPoint;
    private void Awake() 
    {
        lineRenderer=GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lineRenderer.SetPosition(0,startPoint.position);
        lineRenderer.SetPosition(1,endPoint.position);
    }
}
