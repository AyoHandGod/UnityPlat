using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D target)
    {
        // if object touches an object with the tag Deadly
        if(target.gameObject.tag == "Deadly")
        {
            OnExplode();
        }
    }

    private void OnExplode()
    {
        Destroy(gameObject);
    }
}
