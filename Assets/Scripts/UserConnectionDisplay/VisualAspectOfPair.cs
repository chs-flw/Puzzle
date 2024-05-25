using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;


public enum ConnectionType {

    Absolute,
    On,
    Off

}

public class VisualAspectOfPair : MonoBehaviour {



    [SerializeField]
    protected ConnectionType _connectionType;

    public ConnectionType connectionType {

        get {

            return _connectionType;

        }

        protected set {

            _connectionType = value;
            UpdateColor();

        }

    }


    [Space]
    [Header("Positions of connected objects and their deviation from origin points")]

    [SerializeField]
    protected GameObject firstObject;

    [SerializeField]
    protected Vector3 firstDeviation;

    [SerializeField]
    protected GameObject secondObject;

    [SerializeField]
    protected Vector3 secondDeviation;



    public Vector3 firstPosition { get { return firstObject.transform.position + firstDeviation; } }

    public Vector3 secondPosition { get { return secondObject.transform.position + secondDeviation; } }




    [SerializeField]
    protected LineRenderer lineRenderer;
    [SerializeField]
    protected Color lineColor;

    public virtual void UpdateColor() {

        switch(connectionType) {

            case ConnectionType.Absolute:
                lineColor = Color.blue;
            break;
            case ConnectionType.On:
                lineColor = Color.green;
            break;
            case ConnectionType.Off:
                lineColor = Color.red;
            break;

        }

        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;

    }
    /*
    public void ChangeState(GameObject caller, ConnectionType newType) {

        switch(connectionType) {

            case ConnectionType.Absolute:
                Debug.LogWarning($"Object {caller.name} is trying to change an absolute type of connection of {name}. No action will be applied");
            break;

            case ConnectionType.On: 
            case ConnectionType.Off:

                if (newType == ConnectionType.Absolute) {
                    Debug.LogWarning($"Object {caller.name} is trying to set a relative connection to absolute type of {name}. No action will be applied");
                } else if (newType == connectionType) {
                    Debug.LogWarning($"Object {caller.name} sets the connection type to the same value");
                } else {
                    connectionType = newType;
                }

            break;

            default:
                Debug.LogError($"Unpredictable behaviour caused by {caller.name} in VisualAspectOfPair of {name}");
            break;

        }

    }
    */
    protected virtual void Start() {

        UpdateColor();

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0,firstPosition);
        lineRenderer.SetPosition(1,secondPosition);

    }

    public static T CreateVisualPair<T>(                GameObject      handler,
                                                        ConnectionType  connectionType,
                                                        GameObject      firstObject,
                                                        Vector3         firstDeviation,
                                                        GameObject      secondObject,
                                                        Vector3         secondDeviation 
                                                        ) where T:VisualAspectOfPair {

        LineRenderer lineRenderer = handler.AddComponent<LineRenderer>();
        
        lineRenderer.material = MaterialDefaults.instance.defaultLineMaterial;
        
        //lineRenderer.startWidth = 0.021f;
        //lineRenderer.endWidth = 0.021f;

        T result = handler.AddComponent<T>();

        result.lineRenderer = lineRenderer;

        result.connectionType   = connectionType;
        
        result.firstObject      = firstObject;
        result.firstDeviation   = firstDeviation;

        result.secondObject     = secondObject;
        result.secondDeviation  = secondDeviation;

        return result;

    }    

}
