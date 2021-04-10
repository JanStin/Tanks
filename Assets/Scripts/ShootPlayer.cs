using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] private GameObject[] shells;
    [SerializeField] private Transform firePoint;

    private float _rechargeTime;
    private float _rechargeTimer;

    private void Update()
    {
        _rechargeTimer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && _rechargeTimer > _rechargeTime)
        {
            GameObject shell = Instantiate(shells[0], firePoint.position, firePoint.rotation) as GameObject;
            Rigidbody shellRigidbody = shell.GetComponent<Rigidbody>();
            shellRigidbody.velocity = 20.0f * firePoint.forward;
            _rechargeTime = shell.GetComponent<Shell>().RechargeTime;

            _rechargeTimer = 0;
        }
    }
}
