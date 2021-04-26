using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    public float SoundsVolume
    {
        get { return AudioListener.volume; }
        set { AudioListener.volume = value; }
    }

    public ManagerStatus Status { get; private set; }

    public void Startup()
    {
        SoundsVolume = 0.5f;
        Status = ManagerStatus.Started;
    }
}
