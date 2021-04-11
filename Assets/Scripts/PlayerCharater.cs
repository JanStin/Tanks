using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharater : MonoBehaviour
{
    private int _health;
    private readonly int _maxHealth = 100;

    private void Start()
    {
        _health = 100;
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
