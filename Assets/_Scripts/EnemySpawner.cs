using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _repeatRate;
    [SerializeField] private float _maxOffsetX;
    [SerializeField] private GameplayManager _scoreManager;
    [SerializeField] private Enemy[] _enemyPrefabs;

    private void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", _repeatRate, _repeatRate);
    }

    private void SpawnRandomEnemy()
    {
        var prefab = _enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)];

        var position = transform.position;
        position.x = Random.Range(transform.position.x - _maxOffsetX, transform.position.x + _maxOffsetX);

        var instance = Instantiate(prefab, position, prefab.transform.rotation);
        instance.OnDestroyed.AddListener(Enemy_Destroyed);
    }

    private void Enemy_Destroyed(int score)
    {
        _scoreManager.AddScore(score);
    }
}
