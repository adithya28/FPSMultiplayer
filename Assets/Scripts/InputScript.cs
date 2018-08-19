using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour {
    // if()
    public float Vertical;
    public float Horizontal;
    public  float jump;
    public float fire;
    public float Reload;
    public float crouch;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        crouch = Input.GetAxis("Crouch");
        Reload = Input.GetAxis("Reload");
        fire = Input.GetAxis("Fire1");
        if (Input.GetKeyDown(KeyCode.Space))
            jump = 1;
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        
    }
}
