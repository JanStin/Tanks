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
            NewGame();
        }
        Messenger.Broadcast(GameEvent.HEALTH_UPDATED);
    }

    public int GetHealth()
    {
        return _health;
    }

    private void NewGame()
    {
        _health = 100;
        GameObject player = GameObject.Find("Player");
        player.GetComponent<Rigidbody>().MovePosition(new Vector3(-330, 0, 450));

        GameObject[] turrels = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject turrel in turrels)
        {
            Destroy(turrel);
        }

        GameObject spawnTurrels = GameObject.Find("Spawn Points");
        spawnTurrels.GetComponent<SpawnTurrels>().NewGameSpawn();

        GameObject sceneController = GameObject.Find("SceneController");
        sceneController.GetComponent<UIController>().NullifyScore();
    }
}
