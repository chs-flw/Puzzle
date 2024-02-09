using UnityEngine;

public interface IMechanism {

    public GameObject gameObject { get; }

    void DoMagic()  ;
    void UndoMagic();

}