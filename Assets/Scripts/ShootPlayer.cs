using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] private GameObject[] shells;
    [SerializeField] private Transform spawnPoint;

    private float _rechargeTime;
    private float _rechargeTimer;

    private void Update()
    {
        _rechargeTimer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && _rechargeTimer > _rechargeTime)
        {
            GameObject shell = Instantiate(shells[0], spawnPoint.position, spawnPoint.rotation) as GameObject;
            Rigidbody shellRigidbody = shell.GetComponent<Rigidbody>();
            shellRigidbody.velocity = 20.0f * spawnPoint.forward;
            _rechargeTime = shell.GetComponent<Shell>().RechargeTime;

            _rechargeTimer = 0;
        }
    }
}
