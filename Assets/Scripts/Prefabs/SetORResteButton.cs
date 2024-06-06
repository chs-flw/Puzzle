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

    protected override void OnStart() {

        anotherButton.OnActivated.AddListener(ChangeState);

        if (function == ButtonsFunction.Reset) ChangeState();

    }

}