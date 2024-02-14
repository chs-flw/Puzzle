using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Simple explanation",menuName = "Explanations",order = 0)]
public class SimpleExplanation : ScriptableObject {

    [SerializeField]
    protected string _onDeactivatedExplanation;

    [SerializeField]
    protected Color _onDeactivatedColor;

    [SerializeField]
    protected string _onActivatedExplanation;

    [SerializeField]
    protected Color _onActivatedColor;

    [SerializeField]
    protected string _whileActivatedExplanation;

    [SerializeField]
    protected Color _whileActivatedColor;

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

    public virtual Color onActivatedColor {

        get {

            return _onActivatedColor;

        }

        protected set {

            _onActivatedColor = value;

        }

    }

    public virtual Color onDeactivatedColor {

        get {

            return _onDeactivatedColor;

        }

        protected set {

            _onDeactivatedColor = value;

        }

    }

    public virtual Color whileActivatedColor {

        get {

            return _whileActivatedColor;

        }

        protected set {

            _whileActivatedColor = value;

        }

    }

}
