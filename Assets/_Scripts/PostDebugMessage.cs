using UnityEngine;

public class PostDebugMessage : MonoBehaviour
{
    [SerializeField] string message;

    public void Post()
    {
        Debug.Log(message);
    }
}
