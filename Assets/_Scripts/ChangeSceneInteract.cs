using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneInteract : MonoBehaviour
{
   public void ChangeScene()
    {
        SceneManager.UnloadSceneAsync("DemoScene");
        SceneManager.LoadSceneAsync("BattleScene", LoadSceneMode.Additive);
        
    }
}
