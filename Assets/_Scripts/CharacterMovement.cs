using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody rb;

    UnityEngine.Vector3 moveVectorInput;
    UnityEngine.Vector3 moveDirection;
    UnityEngine.Vector3 rotationDirection;
    [SerializeField] float speed = 10f;
    [SerializeField] float rotationSpeed = 5f;
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
        HandleRotation();
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

    private void HandleRotation()
    {
       if (moveDirection.magnitude > 0f)
        {
            rotationDirection = moveDirection;
        }

       if(rotationDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(rotationDirection);
            Quaternion rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            transform.rotation = rotation;
        }
    }
}
