using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTurrels : MonoBehaviour
{
    [SerializeField] private GameObject turrelPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private readonly float _minmaxX = 100f;
    private readonly float _minmaxZ = 100f;
    
    private void Start()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Spawn(spawnPoint);
        }        
    }

    private void Spawn(Transform spawnPoint)
    {
        int randomCountTurrel = Random.Range(5, 15);

        for (int i = 0; i < randomCountTurrel; i++)
        {
            float x = Random.Range(-_minmaxX, _minmaxX) + spawnPoint.position.x;
            float z = Random.Range(-_minmaxZ, _minmaxZ) + spawnPoint.position.z;   

            Instantiate(turrelPrefab, new Vector3(x, 0, z), Quaternion.identity);
        }
    }
}
