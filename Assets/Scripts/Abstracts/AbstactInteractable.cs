using UnityEngine;

public abstract class AbstractInteractable : MonoBehaviour, IInteractable {

    public abstract void Interact(PlayerInfo playerInfo);

}