using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SampleMechanism : BasicMechanism {

    Coroutine routine;

    [SerializeField]
    private float velocity;

    [ReadOnly]
    [SerializeField]
    private Vector3 A;
    [SerializeField]
    private Vector3 B;
    private Vector3 Direction;

    [SerializeField]
    private float minimalDistance = 0.009f;

    void Start() {
        
        A = transform.position;

        Direction = (B - A).normalized;

    }

    public override void DoMagic() {

        if (routine != null) {
            StopCoroutine(routine);
        }
        routine = StartCoroutine(GoB());

    }

    public override void UndoMagic() {

        if (routine != null) {
            StopCoroutine(routine);
        }
        routine = StartCoroutine(GoA());

    }

    IEnumerator GoB() {

        while (Vector3.Distance(transform.position,B) >= minimalDistance) {
            transform.position += Direction * velocity * Time.deltaTime;
            yield return null;
        }

    }

    IEnumerator GoA() {

        while (Vector3.Distance(transform.position,A) >= minimalDistance) {
            transform.position -= Direction * velocity * Time.deltaTime;
            yield return null;
        }

    }

}
