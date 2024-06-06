using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeSpanButton : AbstractButton {

    [SerializeField,Range(1,30)]
    private int activeTime;
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
