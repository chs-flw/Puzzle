using UnityEngine;
using UnityEngine.Events;

public class RaycastInteractable : MonoBehaviour, IInteractable {

    [SerializeField]
    private RaycastHandler handler;
    
    [SerializeField]
    private AbstractInteractable interactable;

    public void Interact(PlayerInfo info) {

        if(handler.CheckRaycast()) {

            interactable.Interact(info);

        }

    }


}