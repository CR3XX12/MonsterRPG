using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneInteract : MonoBehaviour
{
    [SerializeField] string targetScene;
   public void ChangeScene()
    {
        UnityEngine.Object.FindFirstObjectByType<GameSceneManager>().SwitchEnvironmentScene(targetScene);
        
    }
}
