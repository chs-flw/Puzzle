using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConnectionType {

    Absolute,
    On,
    Off

}

public class ConnectedPairBehaviour : MonoBehaviour {


    [SerializeField]
    private GameObject firstConnectedObject;

    [SerializeField]
    private Vector3 firstDeviation;


    [SerializeField]
    private GameObject secondConnectedObject;
    [SerializeField]
    private Vector3 secondDeviation;


    [SerializeField]
    private ConnectionType _connectionType;

    public Vector3 firstPosition {

        get {

            return firstConnectedObject.transform.position + firstDeviation;

        }

    }

    public Vector3 secondPosition {

        get {

            return secondConnectedObject.transform.position + secondDeviation;

        }

    }

    public ConnectionType connectionType {

        get {

            return _connectionType;

        }
        private set {

            _connectionType = value;

        }

    }

    public ConnectedPairBehaviour(  
                                    GameObject firstConnectedObject, 
                                    Vector3 firstDeviation, 

                                    GameObject secondConnectedObject,
                                    Vector3 secondDeviation,
                                    
                                    ConnectionType connectionType) {

        this.firstConnectedObject  = firstConnectedObject;
        this.firstDeviation        = firstDeviation;

        this.secondConnectedObject = secondConnectedObject;
        this.secondDeviation       = secondDeviation;

        this.connectionType        = connectionType;

    }

    public void ChangeState(GameObject caller) {

        switch(connectionType) {

            case ConnectionType.Absolute:
                Debug.Log($"{caller} is trying to set the absolute value of the connection of {this}. No action will be applied.");
            break;
            case ConnectionType.On:
                connectionType = ConnectionType.Off;            
            break;
            case ConnectionType.Off:
                connectionType = ConnectionType.On;
            break;

        }

    }

}
