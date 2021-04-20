using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private int _damage;
    private float _lifeTime;

    public float RechargeTime = 2.0f;
    public string ParentTag;
    public GameObject explosionParticlesPrefab;


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
                Explosion();
            }
        }
        else if (ParentTag.Equals("Enemy"))
        {
            if (!collision.gameObject.CompareTag("Enemy"))
            {
                if (collision.gameObject.GetComponent<PlayerCharater>())
                {
                    collision.gameObject.GetComponent<PlayerCharater>().GetDamage(_damage);
                }
                Explosion();
            }
        } 
        
    }

    private void Explosion()
    {
        if (explosionParticlesPrefab)
        {
            GameObject explosion = Instantiate(explosionParticlesPrefab, transform.position, explosionParticlesPrefab.transform.rotation) as GameObject;
            Destroy(explosion, explosion.GetComponent<ParticleSystem>().main.startLifetimeMultiplier);
        }
        Destroy(gameObject);
    }

}
