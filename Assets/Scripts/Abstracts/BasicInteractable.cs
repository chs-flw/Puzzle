using UnityEngine;
using UnityEngine.Events;

public class BasicInteractable : AbstractInteractable {

    [SerializeField]
    private UnityEvent interactable;

    public override void Interact(PlayerInfo playerInfo) {

        interactable.Invoke();

    }

}