using UnityEngine;

class Relation:MonoBehaviour {

    [SerializeField]
    protected AbstractActivator activator;

    [SerializeField]
    protected BasicMechanism mechanism;

    [SerializeField]
    private SimpleExplanation explanation;

    [SerializeField]
    private ExplanationBehaviour prefab;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private bool countDownOverride;

    [SerializeField]
    protected Vector3 mechDeviation;

    [SerializeField]
    protected Vector3 actiDeviation;

    [SerializeField]
    protected ConnectionType connectionType; 

    protected virtual VisualAspectOfPair createVAOP() {

        VisualAspectOfPair aspectOfPair = VisualAspectOfPair.CreateVisualPair<VisualAspectOfPair>(
            gameObject,
            connectionType,
            activator.gameObject, actiDeviation,
            mechanism.gameObject, mechDeviation
        );

        return aspectOfPair;

    }

    private void Start() {

        ExplanationBehaviour newRelation = Instantiate(prefab);
        newRelation.explanation = explanation;

        VisualAspectOfPair aspectOfPair = createVAOP();

        newRelation.holder.SetFollowRangeAndMakeParallelTo(aspectOfPair.firstPosition, aspectOfPair.secondPosition, offset);
        newRelation.countDownOverride = countDownOverride;

        activator.OnActivated.AddListener(newRelation.onActivatedUpdate);
        activator.OnActivated.AddListener(() => newRelation.whileActivatedUpdate(5));
        activator.OnDeactivated.AddListener(newRelation.onDeactivatedDefaultUpdate);

        newRelation.onDeactivatedDefaultUpdate();

    }

}