using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody rb;

    Vector3 moveVectorInput;
    Vector3 moveDirection;
    [SerializeField] float speed = 10f;
    [SerializeField] Camera targetCamera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void AddMoveVectorInput(Vector3 moveVector)
    {
        moveVectorInput = moveVector;
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
       //moveDirection = moveVectorInput;
        moveDirection = targetCamera.transform.forward * moveVectorInput.z;
        moveDirection += targetCamera.transform.right * moveVectorInput.x;
        moveDirection.y = 0f;
        moveDirection.Normalize();

        Vector3 moveVelocity = moveDirection * speed;
        moveVelocity += Physics.gravity;

        rb.linearVelocity = moveVelocity;
    }
}
