using UnityEngine;

public class SimpleExplanationBehaviour : MonoBehaviour {

    [SerializeField]
    protected CanvasInterface holder; 

    [SerializeField]
    protected string _explanation;

    public string explanation {

        get {

            return _explanation;

        }

        protected set {

            _explanation = value;

        }

    }

    protected void Start() {

        holder.explanationDisplay.text = explanation;

    }

}