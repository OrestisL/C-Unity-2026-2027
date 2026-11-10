using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class Utilities 
{
    public static void ChangeScene(string sceneName, MonoBehaviour runner)
    {
        runner.StartCoroutine(LoadSceneAsync(sceneName));
    }

    private static IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
