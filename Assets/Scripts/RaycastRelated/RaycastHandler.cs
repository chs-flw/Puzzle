using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaycastHandler : MonoBehaviour {

    public const int ResponsiveLayer = 7;

    [SerializeField]
    RaycastHandler target;

    public Vector3 position {

        get {
            
            return transform.position;
        
        }

    }

    private Vector3 direction;

    void Start() {

        direction = (target.position - position).normalized;
        //StartCoroutine(routine());

    }

    RaycastHit hit;

    public bool CheckRaycast() {

        bool status = false;

        if (Physics.Raycast(position,direction,out hit,100f,(1 << InteractionPart.InteractionLayer) + (1 << ResponsiveLayer))){

            status = Vector3.Distance(hit.transform.position,target.position) < 0.05f;

        }

        print(gameObject.name + " " + status.ToString() + ". Because of " + hit.transform.name);

        return status;
    }


    //DEBUG PURPOSES

    /*
        IEnumerator routine() {

            while (true) {

                print(gameObject.name + " " + CheckRaycast().ToString());
                yield return new WaitForSeconds(0.5f);

            }

        }
    */

}
