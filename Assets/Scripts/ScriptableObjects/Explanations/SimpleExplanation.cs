using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Simple explanation",menuName = "Explanations",order = 0)]
public class SimpleExplanation : ScriptableObject {

    [SerializeField]
    protected string _onDeactivatedExplanation;

    [SerializeField]
    protected string _onActivatedExplanation;

    [SerializeField]
    protected string _whileActivatedExplanation;

    public virtual string onDeactivatedExplanation {

        get {

            return _onDeactivatedExplanation;

        }

        protected set {

            _onDeactivatedExplanation = value;

        }

    }

    public virtual string onActivatedExplanation {

        get {

            return _onActivatedExplanation;

        }

        protected set {

            _onActivatedExplanation = value;

        }

    }

    public virtual string whileActivatedExplanation {

        get {

            return _whileActivatedExplanation;

        }

        protected set {

            _whileActivatedExplanation = value;

        }

    }

}
