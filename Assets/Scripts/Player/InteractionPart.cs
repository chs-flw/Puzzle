using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPart : MonoBehaviour {
    public const int InteractionLayer = 6;

    [SerializeField]
    private float interactionDistance = 5f;

    void RaycastHandler(GameObject gameObject) {

        BasicInteractable interactable = gameObject.GetComponent<BasicInteractable>();
        
        if (interactable != null) {

            interactable.Interact();
        
        }

    } 
    void Update() {

        if (Input.GetKeyDown(KeyCode.E)) {

            RaycastHit raycastHit;

            if(Physics.Raycast(transform.position,transform.forward,out raycastHit,interactionDistance,1 << InteractionLayer)) {

                RaycastHandler(raycastHit.transform.gameObject);

            }
        }
    }

}
