using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopup : MonoBehaviour
{
    public void ChangeActive()
    {
        if (gameObject.activeSelf)
        {            
            gameObject.SetActive(false);
            Pause.ResumeGame();
        }
        else
        {
            gameObject.SetActive(true);
            Pause.PauseGame();
        }
    }

    public void OnSoundsVolue(float volume)
    {
        Managers.Audio.SoundsVolume = volume;
    }
}
