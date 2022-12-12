using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private float _speed;
    [SerializeField] private float _shootRate;
    [SerializeField] private Destroyer _destroySFX;
    [SerializeField] private Destroyer _destroyVFX;

    public UnityEvent<int> OnDestroyed;

    private BulletShooter _shooter;

    private void Start()
    {
        _shooter = GetComponentInChildren<BulletShooter>();

        InvokeRepeating("Shoot", 0, _shootRate);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }

    public void Destroy()
    {
        OnDestroyed?.Invoke(_score);

        Instantiate(_destroySFX);
        Instantiate(_destroyVFX, transform.position, _destroySFX.transform.rotation);

        Destroy(gameObject);
    }

    private void Shoot()
    {
        _shooter.Shoot();
    }
}
