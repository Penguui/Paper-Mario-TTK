using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QMBController : MonoBehaviour
{
    public UnityEngine.Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<UnityEngine.Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void qmbbump()
    {
        animator.Play("qmbbump"); 
    }
}
