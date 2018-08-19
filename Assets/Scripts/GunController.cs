using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {
    InputScript playerInput;
    public GameObject MuzzleFlash;

    
    // Use this for initialization
    void Start () {

        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<InputScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerInput.fire == 1)
            MuzzleFlash.SetActive(true);
        else
            MuzzleFlash.SetActive(false);
		
	}
}
