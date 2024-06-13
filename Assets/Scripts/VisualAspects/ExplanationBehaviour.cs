using UnityEngine;

public class ExplanationBehaviour : MonoBehaviour {
    public bool initialState;
    public ProperDisplay holder;
    public SimpleExplanation explanation;

    void Start() {
        CheckState();
    } 

    public void ChangeState() {

        initialState = !initialState;
        CheckState();

    }

    public void CheckState() {

        if( !initialState ) {
            holder.explanationDisplay.text  = explanation.onDeactivatedExplanation;
            holder.explanationDisplay.color = explanation.onDeactivatedColor;
        } else {
            holder.explanationDisplay.text  = explanation.onActivatedExplanation;
            holder.explanationDisplay.color = explanation.onActivatedColor;
        }
    }
}