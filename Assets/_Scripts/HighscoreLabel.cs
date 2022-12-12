using TMPro;

using UnityEngine;

public class HighscoreLabel : MonoBehaviour
{
    [SerializeField] private TMP_Text _labelInitials;
    [SerializeField] private TMP_Text _labelScore;

    private void Start()
    {
        var highscore = GameManager.Instance.Highscore;
        if (highscore != null)
        {
            _labelInitials.text = string.Format("HI-SCORE<{0}>", highscore.PlayerInitials);
            _labelScore.text = highscore.ScoreValue.ToString("000000");
        }
    }
}
