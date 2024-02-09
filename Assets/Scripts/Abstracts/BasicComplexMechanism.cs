using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicComplexMechanism : MonoBehaviour, IMechanism {
    
    [SerializeField]
    [Range(0,5)]
    private int _AmountToActivate;

    private int AmountToActivate {

        get {

            return _AmountToActivate;

        }

        set {

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

    public void DoMagic() {

        AmountToActivate--;

    }

    public void UndoMagic() {

        AmountToActivate++;

    }

}
