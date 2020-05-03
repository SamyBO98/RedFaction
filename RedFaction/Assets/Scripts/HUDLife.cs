using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDLife : MonoBehaviour
{
    public Sprite[] Life;
    public Sprite[] Armor;
    public Image LifeUI;
    public Image ArmorUI;
    private PlayerStats ps;

    private void Start()
    {
        ps = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();
    }
    // Update is called once per frame
    void Update()
    {
        LifeUI.sprite = Life[ps.healthBase];
        ArmorUI.sprite = Armor[ps.armorBase];
    }
}
