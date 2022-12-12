using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMenuButton : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Button_Clicked);
    }

    private void Button_Clicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
