using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTurrels : MonoBehaviour
{
    [SerializeField] private GameObject turrelPrefab;

    public Transform Platform;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        Instantiate(turrelPrefab, Platform.position, Quaternion.identity);
    }
}
