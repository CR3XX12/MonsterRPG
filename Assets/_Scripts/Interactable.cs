using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent onInteract;

    public void Interact()
    {
        onInteract?.Invoke();
    }

    public void MoveUpwards()
    {
        StartCoroutine(MoveObjectUp());
    }
    public void MoveDown()
    {
        StartCoroutine(MoveObjectDown());
    }

    private IEnumerator MoveObjectUp()
    {
        float speed = 1f; // Units per second
        Vector3 targetPos = transform.position + new Vector3(0, 2, 0); // Moves 2 units up

        while (transform.position.y < targetPos.y)
        {
            transform.position += Vector3.up * speed * Time.deltaTime; // Moves upward smoothly
            yield return null;
        }

        transform.position = targetPos; // Ensure it reaches the exact position
    }

    private IEnumerator MoveObjectDown()
    {
        float speed = 1f; // Units per second
        Vector3 targetPos = transform.position - new Vector3(0, 2, 0); // Moves 2 units down

        while (transform.position.y > targetPos.y) // Correct condition
        {
            transform.position -= Vector3.up * speed * Time.deltaTime; // Moves DOWN
            yield return null;
        }

        transform.position = targetPos; // Ensure it reaches the exact position
    }


}

