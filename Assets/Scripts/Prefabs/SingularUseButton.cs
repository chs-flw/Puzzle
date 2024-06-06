using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SingularUseButton : AbstractButton {

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
