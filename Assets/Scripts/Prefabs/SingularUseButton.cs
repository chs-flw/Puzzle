using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SingularUseButton : AbstractButton {

    [ReadOnly]
    [SerializeField]
    protected bool _activated;

    public override bool Activated {

        get {

            return _activated;

        }

        protected set {

            _activated = value;

        }

    }

    [SerializeField]
    protected UnityEvent _onActivated;

    public override UnityEvent OnActivated {

        get {

            return _onActivated;

        }

        set {

            _onActivated = value;

        }

    }

    [SerializeField]
    protected UnityEvent _onDeactivated;

    public override UnityEvent OnDeactivated {

        get {

            return _onDeactivated;

        }

        set {

            _onDeactivated = value;

        }

    }

    public override void Activate() {

        if (!Activated) OnActivated.Invoke();

    }

    protected void ChangeState() {

        Activated = !Activated;
        ChangeControllerState(Activated);

    }

    private void ChangeControllerState(bool state) {

        animationController.SetBool("Pressed",state);

    }

    public SingularUseButton () {

        OnActivated   = new UnityEvent();
        OnDeactivated = new UnityEvent();

        OnActivated  .AddListener(ChangeState);
        OnDeactivated.AddListener(ChangeState);

    }

}
