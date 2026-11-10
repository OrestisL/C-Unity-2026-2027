using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ChangeScene : MonoBehaviour
{
    public Button button;
    public string sceneName;

    void Start()
    {
        button.onClick.AddListener(() => Utilities.ChangeScene(sceneName, this));
    }
}
