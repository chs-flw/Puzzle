using Unity;
using UnityEngine;


public class RaycastDependentAspectOfPair : VisualAspectOfPair {

    private Color denied;
    
    private float colorTransitionSpread;

    protected override void Start() {

        denied = Color.red;
        colorTransitionSpread = 0.05f;
        lineColor = Color.green;

        RaycastUpdater.instance.Subscribe(UpdateRaycast);

        UpdateRaycast();
    }

    public override void UpdateColor() {
        
        lineRenderer.startColor = lineColor;
        //This method is superfluous. Code including with references of this method should be re-written

    }

    private void UpdateRaycast() {

        RaycastHit hit;
        Vector3 direction = (secondPosition - firstPosition).normalized;

        if(Physics.Raycast(firstPosition,direction,out hit,100f, (1 << RaycastHandler.ResponsiveLayer) + (1 << InteractionPart.InteractionLayer))) {
            lineRenderer.positionCount = 4;
            lineRenderer.SetPosition(0, firstPosition);
            lineRenderer.SetPosition(1, hit.point - colorTransitionSpread * direction );
            lineRenderer.SetPosition(2, hit.point + colorTransitionSpread * direction );
            lineRenderer.SetPosition(3, secondPosition);
            lineRenderer.colorGradient = new Gradient() {
                colorKeys = new GradientColorKey[] {
                    new GradientColorKey(lineColor, hit.distance/(secondPosition - firstPosition).magnitude),
                    new GradientColorKey(denied, 1)
                },
                mode = GradientMode.Fixed
            };
        } else {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, firstPosition);
            lineRenderer.SetPosition(1, secondPosition);
            lineRenderer.colorGradient = new Gradient() {
                colorKeys = new GradientColorKey[] {new GradientColorKey(lineColor,1)}
            };
        }

    }

}