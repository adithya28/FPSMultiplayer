using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
        StartCoroutine("Dest");
      
	}
   
	// Update is called once per frame
	void Update () {
        
	}
    IEnumerator Dest()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }
}
