using System.Collections;
using UnityEngine;

public class ExplanationBehaviour : MonoBehaviour {

    [SerializeField]
    private bool _countDownOverride;

    public bool countDownOverride {

        get {

            return _countDownOverride;
        
        }

        set {

            _countDownOverride = value;

        }

    }

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
            
        }

    }

    public void onDeactivatedDefaultUpdate() {

        holder.explanationDisplay.text  = explanation.onDeactivatedExplanation;
        holder.explanationDisplay.color = explanation.onDeactivatedColor;

    }

    public void onActivatedUpdate() {

        holder.explanationDisplay.text  = explanation.onActivatedExplanation;
        holder.explanationDisplay.color = explanation.onActivatedColor;

    }

    public void whileActivatedUpdate(int seconds) {
        
        if(!countDownOverride) return;
        StartCoroutine(countDown(seconds));

    }

    IEnumerator countDown(int seconds) {

        int secondsLeft = seconds;

        while (secondsLeft > 0) {

            whileActivatedSecondsUpdate(secondsLeft);

            yield return new WaitForSeconds(1);
            secondsLeft--;

        }

    }

    protected void whileActivatedSecondsUpdate(int seconds) {

        holder.explanationDisplay.text  = $"{seconds}s";
        holder.explanationDisplay.color = explanation.whileActivatedColor;

    }


}