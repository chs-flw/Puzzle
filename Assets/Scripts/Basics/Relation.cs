using UnityEngine;
using UnityEngine.Events;

class Relation : MonoBehaviour {

    public UnityEvent Handler;

    public virtual void Use() {

        Handler.Invoke();

    }

}