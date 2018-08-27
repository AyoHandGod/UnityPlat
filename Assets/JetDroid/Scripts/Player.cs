using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Public Fields
    public float speed = 150f;
    public Vector2 maxVelocity = new Vector2(60, 100);
    public float airSpeedModifier = 0.3f;
    public float jetSpeed = 200f;
    public bool standing = true;
    public float standingThreshold = 4.0f;


    // Private Fields
    private Rigidbody2D body2D;
    private SpriteRenderer renderer2D;

	// Use this for initialization
	void Start () {
        body2D = GetComponent<Rigidbody2D>();
        renderer2D = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        var absVelX = Mathf.Abs(body2D.velocity.x);
        var absVelY = Mathf.Abs(body2D.velocity.y);
        var forceX = 0f;
        var forceY = 0f;

        if (Input.GetKey("right"))
        {
            if(absVelX < maxVelocity.x)
            {
                forceX = standing ? speed : speed * airSpeedModifier;
                renderer2D.flipX = false;
            }
        } else if (Input.GetKey("left"))
        {
            if(absVelX < maxVelocity.x)
            {
                forceX = standing ? -speed : -speed * airSpeedModifier;
                renderer2D.flipX = true;
            }
        }

        if(absVelY <= standingThreshold){ standing = true; }
        else { standing = false; }

        if (Input.GetKey("up"))
        {
            if(absVelY < maxVelocity.y)
            {
                forceY = jetSpeed;
            }
        }

        body2D.AddForce(new Vector2(forceX, forceY));
	}
}
