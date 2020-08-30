using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Mario : MonoBehaviour
{
    public float yVelocity;
    public SpriteRenderer spriteRenderer;
    public int direction;
    public GameObject mario;
    public float X;
    public float Y;
    public float IsMoving;
    public UnityEngine.Animator animator;
    public Sprite[] sprites;
    RaycastHit hit = new RaycastHit();
    public float constDistanceToGround;
    public float distanceToGround;
    public int speed;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public Transform target;
    public bool isGrounded;
    public int coinCount;
    public Transform marioCamera;
    Rigidbody rb;

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void OnCollisionExit()
    {
        isGrounded = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        coinCount = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<UnityEngine.Animator>();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
 
    void FixedUpdate()
    {
        transform.Translate((Input.GetAxisRaw("Horizontal") * Time.deltaTime) * speed, 0f, (Input.GetAxisRaw("Vertical") * Time.deltaTime) * speed);
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(marioCamera);
    
        X = (Input.GetAxisRaw("Horizontal") * Time.deltaTime) * speed;
        Y = (Input.GetAxisRaw("Vertical") * Time.deltaTime) * speed;
        yVelocity = rb.velocity.y;

        if (X != 0 || Y != 0)
        {
            IsMoving = 1;
        } else if (X == 0 && Y == 0)
        {
            IsMoving = 0;
        }

        if (Physics.Raycast(transform.position, -Vector3.up, out hit) && isGrounded == true)
        {
            constDistanceToGround = hit.distance;
        }

        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            distanceToGround = hit.distance;
        }

        if (Input.GetKeyDown(KeyCode.Z) && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }

        //Animation crap :)
        //Walk anim
        if (isGrounded == true)
        {
            if (X > 0 && Y == 0)
            {
                spriteRenderer.flipX = true;
                direction = 1;
                animator.Play("Walkpm");
            }
            else if (X == 0 && Y < 0)
            {
                if (direction == 8)
                {
                    spriteRenderer.flipX = false;
                    animator.Play("downleftpm");
                }
                else if (direction == 5)
                {
                    spriteRenderer.flipX = true;
                    animator.Play("downleftpm");
                }
                else if ((direction == 4) || (direction == 1))
                {
                    spriteRenderer.flipX = true;
                    direction = 5;
                    animator.Play("downleftpm");
                }
                else
                {
                    spriteRenderer.flipX = false;
                    animator.Play("downleftpm");
                    direction = 8;
                }
            }
            else if (X == 0 && Y > 0)
            {
                if (direction == 4)
                {
                    spriteRenderer.flipX = true;
                    animator.Play("walkuppm");
                }
                else if ((direction == 7) || (direction == 6))
                {
                    spriteRenderer.flipX = false;
                    animator.Play("walkuppm");
                    direction = 7;
                }
                else if ((direction == 5) || (direction == 1))
                {
                    spriteRenderer.flipX = true;
                    direction = 4;
                    animator.Play("walkuppm");
                }
                else
                {
                    spriteRenderer.flipX = false;
                    animator.Play("walkuppm");
                    direction = 7;
                }
            }
            else if (X > 0 && Y > 0)
            {
                spriteRenderer.flipX = true;
                direction = 4;
                animator.Play("walkuppm");
            }
            else if (X > 0 && Y < 0)
            {
                spriteRenderer.flipX = true;
                direction = 5;
                animator.Play("downleftpm");
            }
            else if (X < 0 && Y == 0)
            {
                spriteRenderer.flipX = false;
                direction = 6;
                animator.Play("Walkpm");
            }
            else if (X < 0 && Y > 0)
            {
                spriteRenderer.flipX = false;
                direction = 7;
                animator.Play("walkuppm");
            }
            else if (X < 0 && Y < 0)
            {
                spriteRenderer.flipX = false;
                direction = 8;
                animator.Play("downleftpm");
            }
            else if ((X == 0 && Y == 0) && direction == 1)
            {
                spriteRenderer.flipX = true;
                animator.Play("downleftidlepm");
            }
            else if ((X == 0 && Y == 0) && direction == 4)
            {
                spriteRenderer.flipX = true;
                animator.Play("upidlepm");
            }
            else if ((X == 0 && Y == 0) && direction == 5)
            {
                spriteRenderer.flipX = true;
                animator.Play("downleftidlepm");
            }
            else if ((X == 0 && Y == 0) && direction == 6)
            {
                spriteRenderer.flipX = false;
                animator.Play("downleftidlepm");
            }
            else if ((X == 0 && Y == 0) && direction == 7)
            {
                spriteRenderer.flipX = false;
                animator.Play("upidlepm");
            }
            else if ((X == 0 && Y == 0) && direction == 8)
            {
                spriteRenderer.flipX = false;
                animator.Play("downleftidlepm");
            }
        }

        //jump anim
        if ((animator.GetCurrentAnimatorStateInfo(0).IsName("right") || animator.GetCurrentAnimatorStateInfo(0).IsName("Walk")) && isGrounded == false && ((yVelocity > 0) || (yVelocity < 0)) && (spriteRenderer.flipX == false))
        {
            animator.Play("jumpright");
        }
        else if ((animator.GetCurrentAnimatorStateInfo(0).IsName("jumpright") || animator.GetCurrentAnimatorStateInfo(0).IsName("Walk")) && isGrounded == false && (yVelocity > -0.1 && yVelocity < 0.1))
        {
            animator.Play("jumpright2");
        }

    }
}
