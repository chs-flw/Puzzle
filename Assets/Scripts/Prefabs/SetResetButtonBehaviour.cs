using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SetResetButtonBehaviour : AbstractButton {

    [ReadOnly]
    [SerializeField]
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

    private Coroutine pushAndRelease;
    private bool running = false;

    private void ChangeState() {

        Activated = !Activated;
        if (pushAndRelease == null || !running) {
            pushAndRelease = StartCoroutine(PushAndRelease());
        } 

    }

    public override void Activate() {

        if (Activated) OnDeactivated.Invoke();
        else OnActivated.Invoke();
    
    }

    private SetResetButtonBehaviour() {

        _onActivated = new UnityEvent();
        _onDeactivated = new UnityEvent();

        _onActivated.AddListener(ChangeState);
        _onDeactivated.AddListener(ChangeState);
        
    }

    private IEnumerator PushAndRelease() {

        animationController.SetBool("Pressed",true);
        running = true;
        yield return new WaitForSeconds(0.3f);
        animationController.SetBool("Pressed",false);
        running = false;

    }

}