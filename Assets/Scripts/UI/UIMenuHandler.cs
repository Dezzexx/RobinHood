using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.InputSystem.OnScreen;
using Unity.VisualScripting;
using UnityEngine.UI;

public class UIMenuHandler : MonoBehaviour
{

//     public void ExitGame()
//     {
// #if UNITY_EDITOR
//         {
//             EditorApplication.ExitPlaymode();
//         };
// #else
//         Application.Quit();
// #endif
//     }
    MenuAction action;

    private void Awake() {
        action = new MenuAction();
    }

    private void OnEnable() {
        action.Enable();
    }

    private void OnDisable() {
        action.Disable();
    }

    private void Start() {
        action.UIAction.Start.started += _ => StartGame();
    }
    public void StartGame(){
        if(true){
            SceneManager.LoadScene(1);
        }
    }
}
