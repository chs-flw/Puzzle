using UnityEngine;
using UnityEngine.Events;

enum ButtonsFunction {
    Set,
    Reset
}

public class SetORResetButton : SingularUseButton {

    [SerializeField]
    private SetORResetButton anotherButton;

    [SerializeField]
    private ButtonsFunction function;

    private void Awake() {

        anotherButton.OnActivated.AddListener(ChangeState);

        if (function == ButtonsFunction.Reset) ChangeState();

    }

}