using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _buttonPlay;

    private void Start()
    {
        _inputField.onValueChanged.AddListener(InputField_ValueChanged);

        _buttonPlay.onClick.AddListener(ButtonPlay_Clicked);
        _buttonPlay.interactable = false;
    }

    private void InputField_ValueChanged(string value)
    {
        _buttonPlay.interactable = !string.IsNullOrEmpty(value) && value.Length == 3;

        GameManager.Instance.PlayerInitials = value.ToUpper();
    }
    private void ButtonPlay_Clicked()
    {
        SceneManager.LoadScene(1);
    }
}
