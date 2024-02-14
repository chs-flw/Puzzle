using UnityEngine;
using UnityEngine.Events;

public class BasicActivator : AbstractActivator {


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
    [SerializeField]
    private UnityEvent _onDeactivated;

    public override UnityEvent OnActivated   {

        get {
            return _onActivated;
        }
        
        set {
            _onActivated = value;
        }

    }
    public override UnityEvent OnDeactivated   {

        get {
            return _onDeactivated;
        }
        
        set {
            _onDeactivated = value;
        }

    }

    private void ChangeStatus() {

        Activated = !Activated;
    
    }

    public UnityEvent AvailableAction {

        get {

            if (Activated) return OnDeactivated;
            return OnActivated;

        }

    }

    public override void Activate() {

        AvailableAction.Invoke();

    }

    protected BasicActivator() {

        OnActivated = new UnityEvent();
        OnDeactivated = new UnityEvent();

        OnActivated.AddListener(ChangeStatus);
        OnDeactivated.AddListener(ChangeStatus);

    }

}
