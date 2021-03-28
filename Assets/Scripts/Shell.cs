using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private int _damage;
    private float _lifeTime;

    private void Start()
    {
        _damage = 20;
        _lifeTime = 2f;

        Destroy(gameObject, _lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy get damage " + _damage);
            Destroy(gameObject);
        }
    }
}
