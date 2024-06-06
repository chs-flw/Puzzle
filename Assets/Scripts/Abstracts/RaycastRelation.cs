using UnityEngine;

class RaycastRelation:Relation {

    protected override VisualAspectOfPair createVAOP() {
        
        VisualAspectOfPair aspectOfPair = VisualAspectOfPair.CreateVisualPair<RaycastDependentAspectOfPair>(
            gameObject,
            connectionType,
            activator.gameObject, actiDeviation,
            mechanism.gameObject, mechDeviation
        );

        return aspectOfPair;

    }

}