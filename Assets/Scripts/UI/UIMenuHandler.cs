using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UIMenuHandler : MonoBehaviour
{
    public void StartGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        {
            EditorApplication.ExitPlaymode();
        };
#else
        Application.Quit();
#endif
    }
}
