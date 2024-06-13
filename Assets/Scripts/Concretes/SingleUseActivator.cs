using UnityEngine;

class SingleUseActivator:BasicActivator {

    private bool activated = false;

    public override void Press() {
        
        if (!activated) {

            activated = true;
            base.Press();

        }

    }

}