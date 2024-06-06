using UnityEngine;

public abstract class BasicMechanism:MonoBehaviour, IMechanism {

    public abstract void DoMagic();
    public abstract void UndoMagic();

}