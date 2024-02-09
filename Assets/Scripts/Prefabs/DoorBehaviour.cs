using UnityEngine;

public class DoorBehaviour:MonoBehaviour,IMechanism {

    [SerializeField]
    private Animator animationController;

    public void DoMagic() {

        animationController.SetBool("Openned",true);

    }

    public void UndoMagic() {

        animationController.SetBool("Openned",false);

    }

}