using UnityEngine;

class RaycastRelationVisualAspect:RelationVisualAspect {

    protected override VisualAspectOfPair createVAOP() {
        
        VisualAspectOfPair aspectOfPair = VisualAspectOfPair.CreateVisualPair<RaycastDependentAspectOfPair>(
            gameObject,
            from, fromDeviation,
            to, toDeviation
        );

        return aspectOfPair;

    }

}