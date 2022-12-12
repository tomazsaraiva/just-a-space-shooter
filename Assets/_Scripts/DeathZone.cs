using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Bullet bullet) || other.TryGetComponent(out Enemy enemy))
        {
            Destroy(other.gameObject);
        }
    }
}
