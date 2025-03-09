using UnityEngine;
using UnityEngine.Events;

public class WorldTriggerArea : MonoBehaviour    
{
    public UnityEvent onEnter;

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter pc = other.GetComponent<PlayerCharacter>();
        if (pc != null)
        {
            onEnter?.Invoke();
        }
    }
}
