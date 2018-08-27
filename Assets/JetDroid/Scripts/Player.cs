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

    // Private Fields, Player Components being referenced
    private Rigidbody2D body2D;
    private SpriteRenderer renderer2D;
    private PlayerController controller;
    private Animator animator;

	// Use this for initialization
	void Start () {
        body2D = GetComponent<Rigidbody2D>();
        renderer2D = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        var absVelX = Mathf.Abs(body2D.velocity.x);  // maximum X velocity
        var absVelY = Mathf.Abs(body2D.velocity.y);  // maximum Y velocity
        var forceX = 0f;          // will be used to apply force to object once calculated
        var forceY = 0f;          // will be used to apply force to object once calculated

        // Left Right logic
        if (controller.moving.x != 0)
        {
            if(absVelX < maxVelocity.x)
            {
                var newSpeed = speed * controller.moving.x;
                forceX = standing ? newSpeed : newSpeed * airSpeedModifier;
                renderer2D.flipX = forceX < 0;
            }
            animator.SetInteger("AnimState", 1);  // change animation state (1)
        }else { animator.SetInteger("AnimState", 0); }  // change animation state (0)

        // Check if player standing or not
        if(absVelY <= standingThreshold){ standing = true; }
        else { standing = false; }

        // Jumping logic
        if (controller.moving.y != 0)
        {
            if(absVelY < maxVelocity.y)
            {
                forceY = jetSpeed * controller.moving.y;
            }
            animator.SetInteger("AnimState", 2);  // change animation state (2)
        } else if(absVelY > 0 && !standing) { animator.SetInteger("AnimState", 3); } // change animation state (3)

        body2D.AddForce(new Vector2(forceX, forceY)); // Apply force to our rigidbody
	}
}
