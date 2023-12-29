using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int _healthPoints;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxAngle;
    [SerializeField] private Bullet _bulletPrefab;

    public UnityEvent<float> OnHealthValueChanged;

    private int _currenthealth;
    private BulletShooter _shooter;
    private Animator _animator;

    private void Start()
    {
        _shooter = GetComponentInChildren<BulletShooter>();
        _animator = GetComponent<Animator>();

        _currenthealth = _healthPoints;
    }
    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        Move(Vector3.right * horizontal);
        Move(Vector3.forward * vertical);

        // transform.rotation = Quaternion.Euler(0, 0, -_maxAngle * horizontal);
        _animator.SetFloat("inputX", horizontal);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            _shooter.Shoot();
        }
    }

    private void Move(Vector3 direction)
    {
        transform.Translate(direction * Time.deltaTime * _speed, Space.World);
    }

    public void Hit(int damage)
    {
        _currenthealth -= damage;

        OnHealthValueChanged?.Invoke((float)_currenthealth / (float)_healthPoints);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PowerUp powerUp))
        {
            _shooter.PowerUp(true);
            Invoke("DisablePowerUp", powerUp.Duration);

            Destroy(other.gameObject);
        }
    }
    private void DisablePowerUp()
    {
        _shooter.PowerUp(false);
    }
}
