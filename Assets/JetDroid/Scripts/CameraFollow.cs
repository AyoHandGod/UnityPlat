using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    // public fields
    public GameObject target;
    public float scale = 4f;

    // private field
    private Transform t;

    private void Awake()
    {
        // set camera size appropriately
        var cam = GetComponent<Camera>();
        cam.orthographicSize = (Screen.height / 2f) / scale;
    }
    // Use this for initialization
    void Start () {
        // set tranform to that of target object
        t = target.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null)
        {
            // update to follow transform of target with camera
            transform.position = new Vector3(t.position.x, t.position.y, transform.position.z);
        }
	}
}
