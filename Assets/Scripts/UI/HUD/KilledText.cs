using TMPro;
using UnityEngine;

public class KilledText : MonoBehaviour
{
    private int _killedCounter;

    private void Awake()
    {
        GlobalEvents.OnEnemyKilled.AddListener(EnemyKilled);
    }

    private void OnDestroy()
    {
        GlobalEvents.OnEnemyKilled.RemoveListener(EnemyKilled);
    }

    private void EnemyKilled()
    {
        _killedCounter++;
        GetComponent<TextMeshProUGUI>().text = "Killed: " + _killedCounter;
    }
}
