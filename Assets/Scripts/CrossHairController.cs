using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairController : MonoBehaviour {
    
    GameObject crosshair;
   
    public RaycastHit hit;
   
    void Start()
    {

        crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        Cursor.lockState = CursorLockMode.Locked;
      
    }

    // Update is called once per frame
    void Update() {
            
      
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
           else if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            
        }
       
    }
  
        
        
       
        

    
}

