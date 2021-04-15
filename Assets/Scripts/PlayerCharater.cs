using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharater : MonoBehaviour
{
    public void GetDamage(int damage)
    {
        Managers.Player.ChangeHealth(-damage);
    }
}
