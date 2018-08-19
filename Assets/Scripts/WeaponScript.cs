using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
        InputScript playerInput;
   public  GameObject wep;
    WeaponManager weapons_manager;
    GameObject[] weapons;
    // Use this for initialization
    void Start()
    {
        //wep = GameObject.FindGameObjectWithTag("WeaponManager");

        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<InputScript>();
        weapons_manager = wep.GetComponent<WeaponManager>();
        weapons = weapons_manager.weapons;
        weapons[1].SetActive(true);
        weapons[0].SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapons[1].SetActive(true);
            weapons[0].SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapons[1].SetActive(false);
            weapons[0].SetActive(true);
        }

    }
}
