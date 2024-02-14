using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeSpanButton : AbstractButton {

    [SerializeField,Range(1,30)]
    private int activeTime;

    [SerializeField,ReadOnly]
    private bool _activated;

    public override bool Activated {

        get {

            return _activated;

        }

        protected set {

            _activated = value;

        }

    }

    [SerializeField]
    private UnityEvent _onActivated;

    public override UnityEvent OnActivated {

        get {

            return _onActivated;

        }

        set {

            _onActivated = value;

        }

    }

    [SerializeField]
    private UnityEvent _onDeactivated;

    public override UnityEvent OnDeactivated { 

        get {
            
            return _onDeactivated;

        }

        set {

            _onDeactivated = value;

        }
        
    }

    private Coroutine activeTimer;
    private bool isOnTimer = false;

    public override void Activate() {
        
        if (activeTimer == null || !isOnTimer) {
            activeTimer = StartCoroutine(ActivateTimer());
        }

    }

    private IEnumerator ActivateTimer () {

        OnActivated.Invoke();

        animationController.SetBool("Pressed",true);
        isOnTimer = true;
        yield return new WaitForSeconds(activeTime);
        animationController.SetBool("Pressed",false);
        isOnTimer = false;

        OnDeactivated.Invoke();

    }

}
