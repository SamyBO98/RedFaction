using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int grenadeNumber = 2;
    public int healthBase;
    public int healthMax;
    public int armorBase;
    public int armorMax;


    private void Update()
    {
        if(healthBase > healthMax)
        {
            healthBase = healthMax;
        }

        if(armorBase > armorMax)
        {
            armorBase = armorMax;
        }
    }
    void ApplyDamage(int dmg)
    {
        if (armorBase <= 0)
        {
            healthBase -= 2*dmg;
        }
        else
        {
            armorBase -= dmg;
        }

        if (healthBase <= 0)
        {
            Dead();
        }

    }

    void Dead()
    {
        Debug.Log("mort");
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 120, 30), new GUIContent("" + healthBase));
        GUI.Box(new Rect(10, 50, 120, 30), new GUIContent("" + armorBase));
    }

}
