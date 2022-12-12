using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float _secondsToDestroy;

    private void Start()
    {
        Invoke("Destroy", _secondsToDestroy);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
