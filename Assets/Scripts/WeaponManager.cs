using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
    public GameObject[] weapons;
       // Use this for initialization
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public int ChooseState()
    {
        for(int i=0;i<weapons.Length;i++)
        {
            if(weapons[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
