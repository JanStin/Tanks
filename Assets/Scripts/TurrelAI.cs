using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrelAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject shell;
    [SerializeField] private Transform firePoint;

    private int _health { get; set; }
    private float _rechargeTime { get; set; }
    private float _rechargeTimer { get; set; }

    public bool InTriggerZone;

    private void Start()
    {
        _health = 100;
        InTriggerZone = false;
    }

    private void Update()
    {
        if (InTriggerZone)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 3.0f);

            _rechargeTimer += Time.deltaTime;

            if (_rechargeTimer > _rechargeTime)
            {
                GameObject relShell = Instantiate(shell, firePoint.position, firePoint.rotation) as GameObject;
                Rigidbody shellRigidbody = relShell.GetComponent<Rigidbody>();
                shellRigidbody.velocity = 20.0f * firePoint.forward;
                _rechargeTime = shell.GetComponent<Shell>().RechargeTime;

                _rechargeTimer = 0;
            }
        }
    }

    public void GetDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
