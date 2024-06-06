using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicComplexMechanism : BasicMechanism {
    
    [SerializeField]
    [Range(0,5)]
    private int _AmountToActivate;

    protected int AmountToActivate {

        get {

            return _AmountToActivate;

        }

        private set {

            if (value == 0) {
                mechanize.Invoke();
            } else if (value > 0 && _AmountToActivate == 0) {
                unmechanize.Invoke();
            }

            _AmountToActivate = value;

        }

    }

    [SerializeField]
    private UnityEvent mechanize;

    [SerializeField]
    private UnityEvent unmechanize;

    public override void DoMagic() {

        AmountToActivate--;

    }

    public override void UndoMagic() {

        AmountToActivate++;

    }

}
