using UnityEngine;
using UnityEngine.Events;

class BasicInteractable : MonoBehaviour {

    public BasicActivator activator;

    public void Interact() {

        activator.Press();

    }

}