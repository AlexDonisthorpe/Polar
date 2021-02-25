using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTest : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] float jumpSpeed = 10f;

    float horizantalAxis;
    float verticalAxis;
    Vector3 movementVec;

    Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        InputMovement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(0, jumpSpeed, 0, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        Move();

    }

    private void InputMovement()
    {
        horizantalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        movementVec = (horizantalAxis * transform.right + verticalAxis * transform.forward).normalized;
    }

    void Move()
    {
        Vector3 yVector = new Vector3(0, rigidBody.velocity.y, 0);
        rigidBody.velocity = movementVec * speed;
        rigidBody.velocity += yVector;
    }
}
