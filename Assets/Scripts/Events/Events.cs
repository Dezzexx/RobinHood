using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    public static UnityEvent<int> OnPlayerTakeDamage = new();

    public static void SendPlayerTakeDamage(int damage)
    {
        OnPlayerTakeDamage.Invoke(damage);
    }
}
