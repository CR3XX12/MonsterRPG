using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    string currentEnvironmentScene;
    [SerializeField] Rigidbody playerTransform;

    private void Start()
    {
        DetectCurrentEnvironmentScene();
    }

    private void DetectCurrentEnvironmentScene()
    {
        for(int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == "Essential")
            {
                continue;
            }
            currentEnvironmentScene = scene.name;
        }
    }

    string newScene;

    public void SwitchEnvironmentScene(string newScene)
    {
        this.newScene = newScene;

        StartCoroutine(SwitchScene());
    }

    IEnumerator SwitchScene()
    {
        AsyncOperation unload = SceneManager.UnloadSceneAsync(currentEnvironmentScene);
        AsyncOperation load = SceneManager.LoadSceneAsync(newScene, LoadSceneMode.Additive);

        currentEnvironmentScene = newScene;

        // Wait for the previous scene to unload
        while (!unload.isDone)
        {
            yield return null;
        }

        // Wait for the new scene to load completely
        while (!load.isDone)
        {
            yield return null;
        }

        // Ensure SceneInfoContainer is available in the new scene
        SceneInfoContainer sceneInfo = null;
        float timeout = 5f; // Timeout to prevent infinite loop
        float elapsedTime = 0f;

        while (sceneInfo == null && elapsedTime < timeout)
        {
            sceneInfo = UnityEngine.Object.FindFirstObjectByType<SceneInfoContainer>();
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (sceneInfo == null)
        {
            Debug.LogError("SceneInfoContainer not found in the loaded scene! Make sure it exists.");
            yield break;
        }

        // Ensure entranceWaypoints is not null or empty
        if (sceneInfo.entranceWaypoints == null || sceneInfo.entranceWaypoints.Count == 0)
        {
            Debug.LogError("SceneInfoContainer has no entrance waypoints! Assign at least one.");
            yield break;
        }

        Transform waypoint = sceneInfo.entranceWaypoints[0];

        // Ensure playerTransform is assigned
        if (playerTransform != null)
        {
            playerTransform.position = waypoint.position;
            playerTransform.rotation = waypoint.rotation;
        }
        else
        {
            Debug.LogError("playerTransform is null! Make sure it's assigned in the Inspector.");
        }

        yield return null;
    }

}
