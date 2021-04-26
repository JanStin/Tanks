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
        MouseLock(settingsPopup.gameObject.activeSelf);
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            settingsPopup.ChangeActive();
            MouseLock(settingsPopup.gameObject.activeSelf);
        }
    }

    private void MouseLock(bool active)
    {
        if (!active)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
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

    public void OnOpenSettings()
    {
        settingsPopup.ChangeActive();
        MouseLock(settingsPopup.gameObject.activeSelf);
    }
}
