using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class AbstractActivator : MonoBehaviour, IActivator {

    [SerializeField]
    protected ConnectionType connectionType;

    public abstract bool Activated {
        get; protected set;
    }

    public abstract UnityEvent OnActivated { protected get; set; }
    public abstract UnityEvent OnDeactivated { protected get; set;}

    public abstract void Activate();

}