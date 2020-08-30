using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public Animator animator;
    public float timer;
    public bool timerStart;
    public bool isGrounded;
    public float isMoving;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        animator = GetComponent<Animator>();
        isMoving = GameObject.Find("Mario").GetComponent<Mario>().IsMoving;
        isGrounded = GameObject.Find("Mario").GetComponent<Mario>().isGrounded;
    }

    // Update is called once per frame
    void Update()
    {
        isMoving = GameObject.Find("Mario").GetComponent<Mario>().IsMoving;
        isGrounded = GameObject.Find("Mario").GetComponent<Mario>().isGrounded;

        if (isMoving == 0 && isGrounded == true)
        {
            timerStart = true;
            timer += Time.deltaTime;
        } else if (isMoving == 1 || isGrounded == false)
        {
            timer = 0;
        }

        if (timer > 5)
        {
            animator.Play("activate");
        } else if (timer == 0 && animator.GetCurrentAnimatorStateInfo(0).IsName("activate"))
        {
            animator.Play("deactivate");
        }

    }
}
