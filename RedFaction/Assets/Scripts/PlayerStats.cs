using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int grenadeNumber = 2;
    public int healthBase;
    public int healthMax;

    void ApplyDamage(int dmg)
    {
        healthBase -= dmg;

        if (healthBase <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        Debug.Log("mort");
    }
}
