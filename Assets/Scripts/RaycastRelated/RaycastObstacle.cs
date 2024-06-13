using UnityEngine;

public class RaycastObstacle:MonoBehaviour {

    [SerializeField]
    private bool initialState;

    [SerializeField]
    private Collider obstacle;

    private void Start() {

        SetObstacle();

    }

    private void SetObstacle() {
        obstacle.gameObject.SetActive(initialState);
        UpdateRaycast();
    }

    public void ChangeState() {
        initialState = !initialState;
        SetObstacle();
    }

    private void UpdateRaycast() {

        RaycastUpdater.instance.ChangeRaycastState();

    }

}