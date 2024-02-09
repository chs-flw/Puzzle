
using UnityEngine;
using UnityEngine.Events;

public interface IActivator {

    bool Activated { get; }

    UnityEvent OnActivated   { set; } 
    UnityEvent OnDeactivated { set; }

    void Activate();

}