using UnityEngine;

public class DoorBehaviour:BasicMechanism {

    [SerializeField]
    private Animator animationController;

    [SerializeField]
    private bool initialState = false;

    private void Start() {

        animationController.SetBool("Openned", initialState);

    }

    public override void DoMagic() {

        animationController.SetBool("Openned",true);

    }

    public override void UndoMagic() {

        animationController.SetBool("Openned",false);

    }

}