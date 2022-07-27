using UnityEngine;
using UnityEngine.Events;

public class GlobalEvents : MonoBehaviour
{
    public static UnityEvent OnEnemyKilled = new();

    public static void SendEnemyKilled()
    {
        OnEnemyKilled.Invoke();
    }
}

