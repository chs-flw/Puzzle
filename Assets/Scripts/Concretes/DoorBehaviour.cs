using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorBehaviour:MonoBehaviour {

    [SerializeField]
    private Animator animationController;

    [SerializeField]
    private bool initialState = false;

    private void Start() {

        StateChanged();

    }

    public void ChangeState() { 

        initialState = !initialState;
        StateChanged();

    }

    private void StateChanged() {

        animationController.SetBool("Openned",initialState);

    }

}