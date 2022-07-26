using TMPro;
using UnityEngine;

public class KilledText : MonoBehaviour
{
    private int _killedCounter;

    private void Awake()
    {
        GlobalEventManager.OnEnemyKilled.AddListener(EnemyKilled);
    }

    private void OnDestroy()
    {
        GlobalEventManager.OnEnemyKilled.RemoveListener(EnemyKilled);
    }

    private void EnemyKilled()
    {
        _killedCounter++;
        GetComponent<TextMeshProUGUI>().text = "Killed: " + _killedCounter;
    }
}
