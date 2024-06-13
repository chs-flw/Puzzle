using UnityEngine;

class RaycastRelation:Relation {

    [SerializeField]
    private Transform from;

    [SerializeField]
    private Transform to;

    private bool Check() {

        RaycastHit result;

        if(Physics.Raycast(
            from.position, 
            (to.position - from.position).normalized, 
            out result, 100f, 
            (1 << InteractionPart.InteractionLayer) + (1 << RaycastUpdater.ResponsiveLayer) )
        ) {

            if (result.collider.transform == to) return true;

        }

        return false;

    }

    public override void Use() {
        if (Check()) base.Use();
    }

}