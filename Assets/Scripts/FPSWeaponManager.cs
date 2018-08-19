using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSWeaponManager : MonoBehaviour {
    public GameObject[] Weapon;
    public GameObject weapons_manager;
    public GameObject[] FPSHands;
    public GameObject crosshair;
   
    GameObject Player;
    RaycastHit Range;
    int i;
    // Use this for initialization
    void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        //weapons_manager =  GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>();
        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
    }
    
    // Update is called once per frame
    void Update()
    {
        i = weapons_manager.GetComponent<WeaponManager>().ChooseState();
        Physics.Raycast(Player.transform.position,Player.transform.forward, out Range);
        //Debug.Log(Range.distance);
       
       // Debug.DrawLine(muzzle.transform.position,crosshair.transform.position,Color.red);
        if (i == 1)
        {
            FPSHands[1].SetActive(true);
            FPSHands[0].SetActive(false);
        }
        else
        {
            FPSHands[0].SetActive(true);
            FPSHands[1].SetActive(false);
        }
    }
}
