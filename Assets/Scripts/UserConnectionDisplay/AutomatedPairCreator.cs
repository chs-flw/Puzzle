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

    [SerializeField]
    private ExplanationBehaviour explanationPrefab;

    [SerializeField]
    private SimpleExplanation simpleExplanation;

    [SerializeField]
    private Vector3 offset = new Vector3(0f,0.5f,0f);

    void Start() {

        if (mechanisms == null) return;
        foreach(IMechanism mechanism in mechanisms) {

            GameObject anotherPair = new GameObject();
            
            VisualAspectOfPair visualAspectOfAnotherPair = VisualAspectOfPair.CreateVisualPair( anotherPair,
                                                                                                connectionType,
                                                                                                gameObject,
                                                                                                hostDeviation,
                                                                                                mechanism.gameObject,
                                                                                                connectedMechanismDeviation
                                                                                                );


            if (explanationPrefab == null) return;

            Vector3 medianOfAnotherPair = (visualAspectOfAnotherPair.firstPosition + visualAspectOfAnotherPair.secondPosition)/2 + offset;
            Vector3 directionToBeParallelTo = visualAspectOfAnotherPair.secondPosition - visualAspectOfAnotherPair.firstPosition;

            ExplanationBehaviour anotherExplanation = Instantiate(explanationPrefab, medianOfAnotherPair, Quaternion.identity);

            anotherExplanation.explanation = simpleExplanation;

            anotherExplanation.holder.MakeParrallelTo(directionToBeParallelTo);

        }

    }


}
