using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text healthText;
    [SerializeField] private SettingsPopup settingsPopup;

    private int _score;

    private void Start()
    {
        _score = 0;
        OnHealthUpdated();
        settingsPopup.ChangeActive();        
    }

    private void Awake()
    {
        Messenger.AddListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
        Messenger.AddListener(GameEvent.SCORE, ChangeScore);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
        Messenger.RemoveListener(GameEvent.SCORE, ChangeScore);
    }

    public void OnOpenSettings()
    {
        settingsPopup.ChangeActive();
    }

    private void OnHealthUpdated()
    {
        string health = Managers.Player.GetHealth().ToString();
        string message = $"Health:{health}/100";
        healthText.text = message;
    }

    private void ChangeScore()
    {
        _score++;
        scoreText.text = $"Score:{_score.ToString()}";
    }

}
