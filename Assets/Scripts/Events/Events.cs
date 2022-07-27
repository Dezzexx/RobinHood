using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    public static UnityEvent<int> OnPlayerTakeDamage = new();
    public static UnityEvent<int> OnEnemyTakeDamage = new();

    public static void SendPlayerTakeDamage(int damage)
    {
        OnPlayerTakeDamage.Invoke(damage);
    }

    public static void SendEnemyTakeDamage(int damage)
    {
        OnEnemyTakeDamage.Invoke(damage);
    }
}
