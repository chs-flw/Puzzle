using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VisualAspectOfPair : MonoBehaviour {

    [SerializeField]
    private ConnectedPairBehaviour pair;

    [SerializeField]
    private LineRenderer lineRenderer;
    private Color lineColor;

    public void UpdateColor() {

        switch(pair.connectionType) {

            case ConnectionType.Absolute:
                lineColor = Color.magenta;
            break;
            case ConnectionType.On:
                lineColor = Color.green;
            break;
            case ConnectionType.Off:
                lineColor = Color.red;
            break;

        }

        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;

    }

    public VisualAspectOfPair(ConnectedPairBehaviour pair) {

        this.pair = pair;

        lineRenderer = new LineRenderer() { 
            
            material = GraphicsSettings.defaultRenderPipeline.defaultLineMaterial, 

            startWidth = 0.021f,
            endWidth = 0.021f

        };

        UpdateColor();

    }

    private void Start() {

        UpdateColor();

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0,pair.firstPosition);
        lineRenderer.SetPosition(1,pair.secondPosition);

    }

}
