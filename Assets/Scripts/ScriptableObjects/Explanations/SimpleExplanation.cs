using UnityEngine;

[CreateAssetMenu(fileName = "Simple explanation",menuName = "Explanations",order = 0)]
public class SimpleExplanation : ScriptableObject {

    [SerializeField]
    public string onDeactivatedExplanation;

    [SerializeField]
    public Color onDeactivatedColor;

    [SerializeField]
    public string onActivatedExplanation;

    [SerializeField]
    public Color onActivatedColor;

}
