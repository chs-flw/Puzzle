using UnityEngine;

public class VisualAspectOfPair : MonoBehaviour {

    [Space]
    [Header("Positions of connected objects and their deviation from origin points")]

    [SerializeField]
    protected Transform from;

    [SerializeField]
    protected Vector3 fromDeviation;

    [SerializeField]
    protected Transform to;

    [SerializeField]
    protected Vector3 toDeviation;

    [SerializeField]
    public LineRenderer lineRenderer;

    public Vector3 fromPosition { get { return from.position + fromDeviation; } }

    public Vector3 toPosition { get { return to.position + toDeviation; } }
    
    
    protected virtual void Start() {
        lineRenderer.positionCount = 2;
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.blue;
        lineRenderer.SetPosition(0,fromPosition);
        lineRenderer.SetPosition(1,toPosition);
    }

    public static T CreateVisualPair<T>(                GameObject      possessor,
                                                        Transform       from, Vector3 fromDeviation,
                                                        Transform       to,   Vector3 toDeviation 
                                                        ) where T : VisualAspectOfPair {

        LineRenderer lineRenderer = possessor.AddComponent<LineRenderer>();
        
        lineRenderer.material = MaterialDefaults.instance.defaultLineMaterial;
        
        lineRenderer.startWidth = 0.021f;
        lineRenderer.endWidth = 0.021f;

        T result = possessor.AddComponent<T>();

        result.lineRenderer = lineRenderer;
        
        result.from          = from;
        result.fromDeviation = fromDeviation;

        result.to          = to;
        result.toDeviation = toDeviation;

        return result;

    }    
}
