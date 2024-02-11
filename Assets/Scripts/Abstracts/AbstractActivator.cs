using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class AbstractActivator : MonoBehaviour, IActivator {

    [SerializeField]
    private AutomatedPairCreator creator;

    private List<IMechanism> GiveAwayMechanism() {

        List<IMechanism> mechanisms = new List<IMechanism>();

        for(int i = 0; i < OnActivated.GetPersistentEventCount(); i++) {

            IMechanism mechanism = OnActivated.GetPersistentTarget(i) as IMechanism;
            if (mechanism != null) mechanisms.Add(mechanism);

        }

        return mechanisms;

    }

    protected void Awake() {
        if (creator != null)
            creator.mechanisms = GiveAwayMechanism().ToArray();

    }

    public abstract bool Activated {
        get; protected set;
    }

    public abstract UnityEvent OnActivated { protected get; set; }
    public abstract UnityEvent OnDeactivated { protected get; set;}

    public abstract void Activate();

}