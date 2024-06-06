using UnityEngine;

public class RaycastObstacle:BasicMechanism {

    [SerializeField]
    private Collider obstacle;

    private void EnableObstacle() {
        obstacle.gameObject.SetActive(true);
        UpdateRaycast();
    }

    public override void DoMagic() {
        EnableObstacle();
    }

    private void DisableObstacle() {
        obstacle.gameObject.SetActive(false);
        UpdateRaycast();
    }

    public override void UndoMagic() {
        DisableObstacle();
    }

    private void UpdateRaycast() {

        RaycastUpdater.instance.ChangeRaycastState();

    }

}