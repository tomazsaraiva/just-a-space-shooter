using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    private GameObject _content;

    private void Start()
    {
        _content = transform.GetChild(0).gameObject;
    }

    public void Open(bool open)
    {
        Time.timeScale = open ? 0 : 1;

        _content.gameObject.SetActive(open);
    }
}
