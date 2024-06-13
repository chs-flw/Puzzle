using UnityEngine;

public class RaycastObstacle:MonoBehaviour {

    [SerializeField]
    private bool initialState;

    [SerializeField]
    private Collider obstacle;

    private void Start() {

        SetObstacle();

    }
    public void ChangeState() {
        initialState = !initialState;
        SetObstacle();
    }
    private void SetObstacle() {
        obstacle.gameObject.SetActive(initialState);
        UpdateRaycast();
    }
    
    private void UpdateRaycast() {

        RaycastUpdater.instance.ChangeRaycastState();

    }

}