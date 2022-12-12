using TMPro;

using UnityEditor.Rendering;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _labelScore;
    [SerializeField] private Slider _sliderHealth;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private Player _player;

    private int _score;

    private void Start()
    {
        _player.OnHealthValueChanged.AddListener(Player_HealthValueChanged);
    }

    public void AddScore(int value)
    {
        _score += value;
        _labelScore.text = _score.ToString("000000");
    }

    private void Player_HealthValueChanged(float value)
    {
        _sliderHealth.value = value;

        if(value <= 0)
        {
            Time.timeScale = 0;

            GameManager.Instance.SaveScore(_score);

            _gameOverMenu.SetActive(true);
        }
    }
}
