using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

    // public fields
    public Debris debris;
    public int totalDebris = 10;

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

        // generate debris upon explosion
        var t = transform;
        for(int i = 0; i < totalDebris; i++)
        {
            t.TransformPoint(0, -100, 0);
            var clone = Instantiate(debris, t.position, Quaternion.identity) as Debris;
            var body2D = clone.GetComponent<Rigidbody2D>();
            body2D.AddForce(Vector3.right * Random.Range(-1000, 1000));
            body2D.AddForce(Vector3.up * Random.Range(500, 2000));

        }
        Destroy(gameObject);
    }
}
