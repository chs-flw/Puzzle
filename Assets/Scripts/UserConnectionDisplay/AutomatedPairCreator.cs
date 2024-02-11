using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class AutomatedPairCreator : MonoBehaviour {

    [SerializeField]
    private ConnectionType connectionType;

    private IMechanism[] _mechanisms;

    public IMechanism[] mechanisms {
        
        private get {

            return _mechanisms;

        }

        set {

            _mechanisms = value;

        }

    }

    [SerializeField]
    private Vector3 connectedMechanismDeviation;

    [SerializeField]
    private Vector3 hostDeviation;

    void Start() {

        if (mechanisms == null) return;
        foreach(IMechanism mechanism in mechanisms) {

            GameObject anotherPair = new GameObject();
            
            VisualAspectOfPair.CreateVisualPair(anotherPair,
                                                connectionType,
                                                gameObject,
                                                hostDeviation,
                                                mechanism.gameObject,
                                                connectedMechanismDeviation
                                                );

                                                                                

        }

    }


}
