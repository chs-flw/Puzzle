using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DemandingButton : SetResetButtonBehaviour {

    protected override IEnumerator PushAndRelease() {

        animationController.SetBool("Inserted",Activated);
        yield break;

    }

}