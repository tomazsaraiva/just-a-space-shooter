using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _powerUpOffset;

    private AudioSource _audioSource;
    private bool _isPoweredUp;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PowerUp(bool powerUp)
    {
        _isPoweredUp = powerUp;
    }
    public void Shoot()
    {
        Instantiate(transform.position);
        
        if(_isPoweredUp)
        {
            Instantiate(transform.position + Vector3.right * _powerUpOffset);
            Instantiate(transform.position + Vector3.left * _powerUpOffset);
        }

        _audioSource.Play();
    }

    private void Instantiate(Vector3 position)
    {
        Instantiate(_bulletPrefab, position, _bulletPrefab.transform.rotation);
    }
}
