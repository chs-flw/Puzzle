using UnityEngine;

public class RaycastObstacle:MonoBehaviour,IMechanism {

    [SerializeField]
    private Collider obstacle;

    private void EnableObstacle() {
        obstacle.enabled = true;
        UpdateRaycast();
    }

    public void DoMagic() {
        EnableObstacle();
    }

    private void DisableObstacle() {
        obstacle.enabled = false;
        UpdateRaycast();
    }

    public void UndoMagic() {
        DisableObstacle();
    }

    private void UpdateRaycast() {

        RaycastUpdater.instance.ChangeRaycastState();

    }

}