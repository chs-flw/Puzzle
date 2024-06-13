using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class ProperDisplay : MonoBehaviour {

    [SerializeField]
    public Text explanationDisplay;

    [SerializeField]
    private Vector3 upDirection = Vector3.up;

    private Vector3 normalizedDifference;
    private float differenceLength;
    private Vector3 start;
    private Vector3 end;
    private Vector3 offset;

    private void MakeParrallelTo() {


        Vector3 directionToBeParallelTo = normalizedDifference;             //.   upDirection we are looking for    .   .   .   .   .
                                                                            //. .   .   |   .   .  Vector3.up   .   .   .   .   .   .
                                                                            //. .   .   |   .   /   .   .   .   .   .   .   .   .   .
                                                                            //. .   .   |   .  / |  .   .   .   .   .   .   .   .   .
                                                                            //. .   .   |   . / .   .   .   .   .   .   .   .   .   .
        directionToBeParallelTo *= Mathf.Sign(directionToBeParallelTo.y);   //. .   .   |   ./  .|  Vector3.up - a*DTBPT    .   .   .
                                                                            //. .   .   |   /   .   .   .   .   .   .   .   .   .   .
                                                                            //. .   .   |  /.   .|  .   .   .   .   .   .   .   .   .
                                                                            //. .   .   | / .   .   .   .   .   .   .   .   .   .   .
        float alpha = Vector3.Dot(directionToBeParallelTo,Vector3.up);      //. .   .   |/_______|____________ directionToBeParallelTo
                                                                            //. .   .   .   .   alpha
        upDirection = (Vector3.up - alpha * directionToBeParallelTo).normalized;

    }

    public void SetFollowRangeAndMakeParallelTo(Vector3 _start, Vector3 _end, Vector3 _offset) {

        start = _start;
        end   = _end;
        normalizedDifference = (end - start).normalized;
        offset = _offset;

        start = start + normalizedDifference;
        end   = end   - normalizedDifference;

        differenceLength = (end - start).magnitude;

        MakeParrallelTo();


    }

    private Transform player;

    void Awake() {
        
        player = Camera.main.transform;

    }
    
    void Update() {

        transform.position = Vector3.Lerp(
            start, 
            end, 
            Mathf.Clamp(Vector3.Dot(normalizedDifference,player.position - start)/differenceLength,0f, 1f)
        ) + offset;
        transform.LookAt(player,upDirection);

    }

    /*

        if (Mathf.Abs(upDirection.magnitude - 1f) > 0.05f) {

            Debug.LogWarning("Up direction was less or more than 1! Restored to just Vector3.up");

            upDirection = Vector3.up;

        }

    */

    //transform.position = Vector3.Lerp(start,end, Mathf.Min(1f, Mathf.Max(0f, Vector3.Dot(normalizedDifference,player.position - start)/differenceLength))) + offset;

}
