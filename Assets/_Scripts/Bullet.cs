using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            enemy.Destroy();
        }
        else if (other.TryGetComponent(out Player player))
        {
            player.Hit(_damage);
        }

        Destroy(gameObject);
    }
}
