using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverMenu;

    public static GameManager Instance { get; private set; }
    public bool GameOverFlag = false;
    public Player player;
    public Pooler _arrowPlayerPooler;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    
    private void OnEnable()
    {
        GlobalEvents.OnGameOver.AddListener(GameOver);
    }

    private void OnDisable()
    {
        GlobalEvents.OnGameOver.RemoveListener(GameOver);
    }

    public void RestartGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void BackToMainMenu(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    private void GameOver()
    {
        _gameOverMenu.SetActive(true);
        GameOverFlag = true;
    }
}

