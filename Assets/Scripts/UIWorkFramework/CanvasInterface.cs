using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class CanvasInterface : MonoBehaviour {

    [SerializeField]
    private Text _explanationDisplay;

    public Text explanationDisplay {

        get {

            return _explanationDisplay;

        }

    }

    [SerializeField]
    private Vector3 upDirection = Vector3.up;

    public void MakeParrallelTo(Vector3 _directionToBeParallelTo) {


        Vector3 directionToBeParallelTo = _directionToBeParallelTo;         //.   upDirection we are looking for    .   .   .   .   .
                                                                            //. .   .   |   .   .  Vector3.up   .   .   .   .   .   .
                                                                            //. .   .   |   .   /   .   .   .   .   .   .   .   .   .
        directionToBeParallelTo = directionToBeParallelTo.normalized;       //. .   .   |   .  / |  .   .   .   .   .   .   .   .   .
                                                                            //. .   .   |   . / .   .   .   .   .   .   .   .   .   .
        directionToBeParallelTo *= Mathf.Sign(directionToBeParallelTo.y);   //. .   .   |   ./  .|  Vector3.up - a*DTBPT    .   .   .
                                                                            //. .   .   |   /   .   .   .   .   .   .   .   .   .   .
                                                                            //. .   .   |  /.   .|  .   .   .   .   .   .   .   .   .
                                                                            //. .   .   | / .   .   .   .   .   .   .   .   .   .   .
        float alpha = Vector3.Dot(directionToBeParallelTo,Vector3.up);      //. .   .   |/_______|____________ directionToBeParallelTo
                                                                            //. .   .   .   .   alpha
        upDirection = (Vector3.up - alpha * directionToBeParallelTo).normalized;



    }

    [SerializeField]
    private Transform player;

    void Awake() {

        if (Mathf.Abs(upDirection.magnitude - 1f) > 0.05f) {

            Debug.LogWarning("Up direction was less or more than 1! Restored to just Vector3.up");

            upDirection = Vector3.up;

        }

    }
    
    void Update() {

        transform.LookAt(player,upDirection);

    }

}
