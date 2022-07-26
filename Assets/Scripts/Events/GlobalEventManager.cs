using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent OnEnemyKilled = new();

    public static void SendEnemyKilled()
    {
        OnEnemyKilled.Invoke();
    }
}
