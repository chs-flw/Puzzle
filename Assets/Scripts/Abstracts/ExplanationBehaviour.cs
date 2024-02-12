using UnityEngine;

public class ExplanationBehaviour : MonoBehaviour {

    [SerializeField]
    protected CanvasInterface _holder; 

    public CanvasInterface holder {

        get {

            return _holder;

        }

    }

    [SerializeField]
    protected SimpleExplanation _explanation;

    public SimpleExplanation explanation {

        get {

            return _explanation;

        }

        set {

            _explanation = value;
            UpdateText();
        }

    }

    protected void UpdateText() {

        holder.explanationDisplay.text = explanation.onDeactivatedExplanation;

    }



}