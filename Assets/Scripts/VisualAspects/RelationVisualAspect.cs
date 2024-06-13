using UnityEngine;

class RelationVisualAspect:MonoBehaviour {

    [SerializeField]
    protected Transform from;

    [SerializeField]
    protected Transform to;

    [SerializeField]
    private Vector3 explanationOffset;    

    [SerializeField]
    protected Vector3 fromDeviation;

    [SerializeField]
    protected Vector3 toDeviation;

    [SerializeField]
    protected ExplanationBehaviour prefab;

    [SerializeField]
    protected SimpleExplanation explanation;

    [SerializeField]
    protected Relation relation;

    protected virtual VisualAspectOfPair createVAOP() {

        VisualAspectOfPair aspectOfPair = VisualAspectOfPair.CreateVisualPair<VisualAspectOfPair>(
            gameObject,
            from, fromDeviation,
            to, toDeviation
        );

        return aspectOfPair;

    }

    protected virtual void Tie(VisualAspectOfPair aspectOfPair, ExplanationBehaviour explanation) {

        relation.Handler.AddListener(explanation.ChangeState);

    }

    protected void Start() {

        ExplanationBehaviour newExplanation = Instantiate(prefab);
        newExplanation.explanation = explanation;

        VisualAspectOfPair aspectOfPair = createVAOP();

        newExplanation.holder.SetFollowRangeAndMakeParallelTo(aspectOfPair.fromPosition, aspectOfPair.toPosition, explanationOffset);

        Tie(aspectOfPair, newExplanation);
        
    }

}