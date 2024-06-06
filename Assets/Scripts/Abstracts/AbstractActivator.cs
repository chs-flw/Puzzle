using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class AbstractActivator : MonoBehaviour, IActivator {

    protected virtual void OnStart() {

    }

    protected void Start() {
        
        OnStart();

    }

    [ReadOnly,SerializeField]
    private bool _activated;

    public virtual bool Activated {
        
        get {

            return _activated;

        }

        protected set {

            _activated = value;

        }
    
    }

    [SerializeField]
    private UnityEvent _onActivated;

    public virtual UnityEvent OnActivated { 
        
        get {

            return _onActivated;

        }
        
        set {

            _onActivated = value;

        }
        
    }

    [SerializeField]
    private UnityEvent _onDeactivated;

    public virtual UnityEvent OnDeactivated { 

        get {

            return _onDeactivated;

        }
        
        set {

            _onDeactivated = value;

        }
        
    }

    public abstract void Activate();

}