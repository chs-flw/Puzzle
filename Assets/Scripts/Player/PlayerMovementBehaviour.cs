using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour{
    

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private Rigidbody self;
    [SerializeField]
    private float sensetivityX = 45f;

    private void Rotation() {
        
        float mouseX = transform.eulerAngles.y + Input.GetAxis("Mouse X") * sensetivityX;

        transform.rotation = Quaternion.Euler(0f,mouseX,0f);

    }

    private void Movement() {

        Vector3 currentDirection = (Input.GetAxisRaw("Vertical") * transform.forward + Input.GetAxisRaw("Horizontal") * transform.right).normalized;

        self.AddForce(speed*currentDirection*Time.deltaTime,ForceMode.Force);

        if (self.velocity.magnitude > 5f) {
            self.velocity = 5f * self.velocity.normalized;
        }

    }

    void FixedUpdate() {
        
        

    }

    void Update() {

        Movement();
        Rotation();

    }

}
