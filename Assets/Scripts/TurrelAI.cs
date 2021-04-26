using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrelAI : MonoBehaviour
{
    [SerializeField] private GameObject shell;
    [SerializeField] private Transform firePoint;

    private Transform _target;
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
        if (InTriggerZone && !Pause.IsPause())
        {
            _target = FindObjectOfType<PlayerCharater>().transform;
            Vector3 direction = (_target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 3.0f);

            _rechargeTimer += Time.deltaTime;

            if (_rechargeTimer > _rechargeTime)
            {
                GetComponent<AudioSource>().Play();

                GameObject relShell = Instantiate(shell, firePoint.position, firePoint.rotation) as GameObject;
                Rigidbody shellRigidbody = relShell.GetComponent<Rigidbody>();
                shell.GetComponent<Shell>().ParentTag = "Enemy";
                shellRigidbody.velocity = 20.0f * firePoint.forward;
                _rechargeTime = shell.GetComponent<Shell>().RechargeTime;

                _rechargeTimer = 0;
            }
        }
    }

    public void ChangeHealth(int value)
    {
        _health += value;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Messenger.Broadcast(GameEvent.SCORE);
        Managers.Player.ChangeHealth(60);
        Destroy(gameObject);
    }
}
