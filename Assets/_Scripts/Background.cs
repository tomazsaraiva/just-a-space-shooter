using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Vector2 _speed;

    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }
    private void Update()
    {
        _renderer.material.mainTextureOffset += Vector2.one * _speed * Time.deltaTime;
    }
}
