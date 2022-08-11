using UnityEngine;
using UnityEngine.Events;

public class GlobalEvents : MonoBehaviour
{
    public static UnityEvent OnEnemyKilled = new();
    public static UnityEvent OnGameOver = new();

    public static void SendEnemyKilled()
    {
        OnEnemyKilled.Invoke();
    }

    public static void SetGameOver()
    {
        OnGameOver.Invoke();
    }
}

