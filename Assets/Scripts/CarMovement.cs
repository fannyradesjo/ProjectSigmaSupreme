using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float rotationalSpeed = 100f;
    [SerializeField] KeyCode Forward = KeyCode.UpArrow;
    [SerializeField] KeyCode Backward = KeyCode.DownArrow;
    [SerializeField] KeyCode Right = KeyCode.RightArrow;
    [SerializeField] KeyCode Left = KeyCode.LeftArrow;
    [SerializeField] KeyCode Up = KeyCode.Alpha0;
    [SerializeField] float groundBound = 0.5f;
    [SerializeField] float jumpForce = 2.7f;


    Vector3 forward;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
        {
            MoveFunction();
            Jump();
        }
    }

    void MoveFunction()
    {
        forward = transform.right;

        if (Input.GetKey(Forward))
        {
            rb.AddForce(movementSpeed * forward);
        }
        if (Input.GetKey(Backward))
        {
            rb.AddForce(-movementSpeed * forward);
        }
        if (Input.GetKey(Right))
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotationalSpeed);
        }
        if (Input.GetKey(Left))
        {
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotationalSpeed);
        }
    }

    bool IsGrounded()
    {
        Transform transWheel1 = transform.GetChild(0);
        Transform transWheel2 = transform.GetChild(1);
        Transform transWheel3 = transform.GetChild(2);
        Transform transWheel4 = transform.GetChild(3);

        return (Physics.Raycast(transWheel1.position, Vector3.down, groundBound) ||
                Physics.Raycast(transWheel2.position, Vector3.down, groundBound) ||
                Physics.Raycast(transWheel3.position, Vector3.down, groundBound) ||
                Physics.Raycast(transWheel4.position, Vector3.down, groundBound));
        
    }

    void Jump()
    {
        if (Input.GetKeyDown(Up))
        {
            rb.AddForce(new Vector3(0,1,0) * jumpForce, ForceMode.Impulse);
        }
    }
}
