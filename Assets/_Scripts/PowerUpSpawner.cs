using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private float _minSeconds;
    [SerializeField] private float _maxSeconds;

    [SerializeField] private float _radius;
    [SerializeField] private PowerUp[] _powerUpPrefabs;

    private void Start()
    {
        SpawnAtRandomInterval();
    }

    private void SpawnAtRandomInterval()
    {
        Invoke("SpawnRandomPrefab", Random.Range(_minSeconds, _maxSeconds));
    }
    private void SpawnRandomPrefab()
    {
        var prefab = _powerUpPrefabs[Random.Range(0, _powerUpPrefabs.Length)];

        var position = transform.position + (Random.onUnitSphere * _radius);
        position.y = transform.position.y;

        Instantiate(prefab, position, prefab.transform.rotation);

        SpawnAtRandomInterval();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
