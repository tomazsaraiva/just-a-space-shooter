using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private GameObject _content;

    private void Start()
    {
        _content = transform.GetChild(0).gameObject;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            Open(true);
        }
    }

    public void Open(bool open)
    {
        Time.timeScale = open ? 0 : 1;

        _content.gameObject.SetActive(open);
    }
}
