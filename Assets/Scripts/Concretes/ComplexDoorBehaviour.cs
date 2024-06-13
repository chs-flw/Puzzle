using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

class ComplexDoorBehaviour:MonoBehaviour {

    [SerializeField]
    private Text shower;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private int state = 0;

    private void Start() {

        StateChanged();

    }
    public void ChangeState(int index) {
        if ((state & 1 << index) == 0) {

            state += 1 << index;

        } else {

            state -= 1 << index;

        }
        StateChanged();
    }

    private void StateChanged() {

        animator.SetBool("Openned", state == 0);

        int total = 0;

        for (int i = 0; i < 32; i++) {

            if ((state & 1 << i) != 0) {

                total += 1;

            }

        }

        shower.text = total.ToString();

    }

}