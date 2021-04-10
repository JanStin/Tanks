using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrelAI : MonoBehaviour
{
    [SerializeField] Transform target;

    private int _health { get; set; }

    public bool InTriggerZone;

    private void Update()
    {
        if (InTriggerZone)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 3.0f);
        }
    }
}
