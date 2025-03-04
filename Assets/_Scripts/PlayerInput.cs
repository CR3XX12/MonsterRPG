using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    CharacterMovement characterMovement;
    Vector3 moveVector;

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.z = Input.GetAxisRaw("Vertical");

        characterMovement.AddMoveVectorInput(moveVector);
    }
}
