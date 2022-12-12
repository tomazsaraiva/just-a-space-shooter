using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;

    private void Start()
    {
        _toggle.onValueChanged.AddListener(Toggle_ValueChanged);
        _toggle.isOn = GameManager.Instance.HasSound;
    }

    private void Toggle_ValueChanged(bool value)
    {
        AudioListener.pause = !value;

        GameManager.Instance.EnableSound(value);
    }
}
