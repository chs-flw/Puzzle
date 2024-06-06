using UnityEngine;
using UnityEngine.UI;

class ComplexMechanismDecorator : BasicComplexMechanism {

    [SerializeField]
    private Text amountDisplay;

    private void Display() {

        amountDisplay.text = AmountToActivate.ToString();

        if(AmountToActivate == 0) {

            amountDisplay.color = Color.green;

        } else {

            amountDisplay.color = Color.magenta;

        }

    }

    private void Start() {

        Display();

    }

    public override void DoMagic() {
        
        base.DoMagic();

        Display();

    }

    public override void UndoMagic() {
        
        base.UndoMagic();

        Display();

    }

}