using Unity;
using UnityEngine;


public class RaycastDependentAspectOfPair : VisualAspectOfPair {

    private Color denied;

    private Color lineColor;
    
    private float colorTransitionSpread;

    protected override void Start() {

        denied = Color.red;
        colorTransitionSpread = 0.05f;
        lineColor = Color.green;

        RaycastUpdater.instance.Subscribe(UpdateRaycast);

        UpdateRaycast();
    }
    
    public void UpdateRaycast() {

        RaycastHit hit;
        Vector3 direction = (toPosition - fromPosition).normalized;

        if(Physics.Raycast(fromPosition,direction,out hit,100f, 1 << RaycastUpdater.ResponsiveLayer )) {
            lineRenderer.positionCount = 4;
            lineRenderer.SetPosition(0, fromPosition);
            lineRenderer.SetPosition(1, hit.point - colorTransitionSpread * direction );
            lineRenderer.SetPosition(2, hit.point + colorTransitionSpread * direction );
            lineRenderer.SetPosition(3, toPosition);
            lineRenderer.colorGradient = new Gradient() {
                colorKeys = new GradientColorKey[] {
                    new GradientColorKey(lineColor, hit.distance/(toPosition - fromPosition).magnitude),
                    new GradientColorKey(denied, 1)
                },
                mode = GradientMode.Fixed
            };
        } else {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, fromPosition);
            lineRenderer.SetPosition(1, toPosition);
            lineRenderer.colorGradient = new Gradient() {
                colorKeys = new GradientColorKey[] {new GradientColorKey(lineColor,1)}
            };
        }

    }

}