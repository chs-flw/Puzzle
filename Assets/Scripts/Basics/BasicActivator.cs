using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

class BasicActivator : MonoBehaviour {

    public List<Relation> relations;

    public virtual void Press() {

        foreach (Relation relation in relations) {

            relation.Use();

        }

    }

}