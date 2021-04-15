using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text healthText;
    [SerializeField] private SettingsPopup settingsPopup;

    private void Start()
    {
        settingsPopup.ChangeActive();
    }

    public void OnOpenSettings()
    {
        settingsPopup.ChangeActive();
    }

    public void ChangeHealthBar(int value)
    {
        healthText.text = $"Health {value}";
    }

}
