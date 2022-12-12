using UnityEngine;
using TMPro;

public class PlayerLabel : MonoBehaviour
{
    private TMP_Text _label;

    private void Awake()
    {
        _label= GetComponent<TMP_Text>();
    }
    private void Start()
    {
        _label.text = string.Format("PLAYER<{0}>", GameManager.Instance.PlayerInitials);
    }
}
