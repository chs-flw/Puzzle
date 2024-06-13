using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaycastUpdater : MonoBehaviour { 
    public const int ResponsiveLayer = 7;
    private static RaycastUpdater _instance;
    public static RaycastUpdater instance {
        get {
            return _instance;     
        }
        private set {
            _instance = value;
        }
    }
    private UnityEvent _raycastUpdate;
    public void Subscribe(UnityAction raycastUpdate) {
        _raycastUpdate.AddListener(raycastUpdate);
    }
    public void ChangeRaycastState() {
        _raycastUpdate.Invoke();
    }
    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
        _raycastUpdate = new UnityEvent();
    }

}
