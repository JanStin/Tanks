using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private int _damage;
    private float _lifeTime;

    public float RechargeTime = 2.0f;
    public string ParentTag;


    private void Start()
    {
        _damage = 20;
        _lifeTime = 2f;

        Destroy(gameObject, _lifeTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (ParentTag.Equals("Player"))
        {
            if (!collision.gameObject.CompareTag("Player"))
            {
                if (collision.gameObject.GetComponent<TurrelAI>())
                {
                    collision.gameObject.GetComponent<TurrelAI>().ChangeHealth(-_damage);
                }
                Destroy(gameObject);
            }
        }
        else if (ParentTag.Equals("Enemy"))
        {
            if (!collision.gameObject.CompareTag("Enemy"))
            {
                if (collision.gameObject.GetComponent<PlayerCharater>())
                {
                    collision.gameObject.GetComponent<PlayerCharater>().ChangeHealth(-_damage);
                }
                Destroy(gameObject);
            }
        } 
        
    }


}
