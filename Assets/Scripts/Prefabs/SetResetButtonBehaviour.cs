using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SetResetButtonBehaviour : AbstractButton {

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

    protected SetResetButtonBehaviour() {

        OnActivated = new UnityEvent();
        OnDeactivated = new UnityEvent();

        OnActivated.AddListener(ChangeState);
        OnDeactivated.AddListener(ChangeState);
        
    }

    protected virtual IEnumerator PushAndRelease() {

        animationController.SetBool("Pressed",true);
        running = true;
        yield return new WaitForSeconds(0.3f);
        animationController.SetBool("Pressed",false);
        running = false;

    }

}