using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private string mainTheme;

    public float SoundsVolume
    {
        get { return AudioListener.volume; }
        set { AudioListener.volume = value; }
    }

    public float MusicVolume
    {
        get { return musicSource.volume; }
        set { musicSource.volume = value; }
    }

    public ManagerStatus Status { get; private set; }

    public void Startup()
    {
        musicSource.ignoreListenerVolume = true;

        SoundsVolume = 0.5f;
        MusicVolume = 0.5f;

        Status = ManagerStatus.Started;
    }
}
