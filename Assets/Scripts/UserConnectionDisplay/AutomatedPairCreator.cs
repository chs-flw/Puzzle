using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class AutomatedPairCreator : MonoBehaviour {

    [SerializeField]
    private bool raycastDependent = false;

    [SerializeField]
    private bool countDownOverride;

    [SerializeField,Range(1,30)]
    private int timer = 5;

    [SerializeField]
    private AbstractActivator activator;

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

            VisualAspectOfPair visualAspectOfAnotherPair;            
            
            if (!raycastDependent)
                visualAspectOfAnotherPair = VisualAspectOfPair.CreateVisualPair<VisualAspectOfPair>(anotherPair,
                                                                                                    connectionType,
                                                                                                    gameObject,
                                                                                                    hostDeviation,
                                                                                                    mechanism.gameObject,
                                                                                                    connectedMechanismDeviation
                                                                                                    );
            else 
                visualAspectOfAnotherPair = VisualAspectOfPair.CreateVisualPair<RaycastDependentAspectOfPair>(
                    anotherPair,
                    connectionType,
                    gameObject,
                    hostDeviation,
                    mechanism.gameObject,
                    connectedMechanismDeviation
                );


            if (explanationPrefab == null) continue;

            ExplanationBehaviour anotherExplanation = Instantiate(explanationPrefab, Vector3.zero, Quaternion.identity);

            anotherExplanation.explanation = simpleExplanation;
            
            anotherExplanation.countDownOverride = countDownOverride;

            anotherExplanation.onDeactivatedDefaultUpdate();

            anotherExplanation.holder.SetFollowRangeAndMakeParallelTo(visualAspectOfAnotherPair.firstPosition, visualAspectOfAnotherPair.secondPosition, offset);


            activator.OnActivated  .AddListener(anotherExplanation.onActivatedUpdate);
            activator.OnActivated  .AddListener(() => anotherExplanation.whileActivatedUpdate(timer));
            activator.OnDeactivated.AddListener(anotherExplanation.onDeactivatedDefaultUpdate);

        }

    }


}
