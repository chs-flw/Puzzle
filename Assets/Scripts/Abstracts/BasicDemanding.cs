using UnityEngine;
using UnityEngine.Events;

public class BasicDemanding : AbstractInteractable {

    [SerializeField]
    private AbstractActivator activator;

    public override void Interact(PlayerInfo playerInfo) {
        
        if (activator.Activated) {

            playerInfo.IncreaseAmount();
            activator.Activate();

        } else {

            if (playerInfo.DecreaseAmount()) {

                activator.Activate();

            }
            
        }

    }

}