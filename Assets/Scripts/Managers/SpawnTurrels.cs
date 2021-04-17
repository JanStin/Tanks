using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTurrels : MonoBehaviour
{
    [SerializeField] private GameObject turrelPrefab;

    private readonly float _minmaxX = 100f;
    private readonly float _minmaxZ = 100f;
    

    public Transform Platform;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        int randomCountTurrel = Random.Range(1, 11);

        for (int i = 0; i < randomCountTurrel; i++)
        {
            float x = Random.Range(-_minmaxX, _minmaxX) + Platform.position.x;
            float z = Random.Range(-_minmaxZ, _minmaxZ) + Platform.position.z;   

            Instantiate(turrelPrefab, new Vector3(x, 0, z), Quaternion.identity);
        }
    }
}
