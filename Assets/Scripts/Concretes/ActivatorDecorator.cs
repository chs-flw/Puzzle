using UnityEngine;

class ActivatorDecorator:BasicActivator {


    public BasicActivator activator;

    public Animator animator;

    public override void Press() {
        animator.SetTrigger("Pressed");
        activator.Press();
    }

} 