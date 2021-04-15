using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    private int _health;
    private readonly int _maxHealth = 100;

    public ManagerStatus Status { get; private set; }

    public void Startup()
    {
        _health = 100;
        Status = ManagerStatus.Started;
    }

    public void ChangeHealth(int value)
    {
        _health += value;

        if (_health > _maxHealth)
        {
            _health = 100;
        } 
        else if (_health <= 0)
        {
            _health = 0;
            Debug.Log("You lose...");
        }
    }


}
