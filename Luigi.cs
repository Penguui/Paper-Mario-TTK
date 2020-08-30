using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luigi : MonoBehaviour
{
    public Transform Gonzales;
    public Transform leader;
    public float distance;
    public static int speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 7;
    }

    // Update is called once per frame
    void Update()
    {
        speed = GameObject.Find("Mario").GetComponent<Mario>().speed;

        Physics.IgnoreCollision(Gonzales.GetComponent<Collider>(), GetComponent<Collider>());

        distance = Vector3.Distance(leader.transform.position, transform.position);
        Debug.Log("d" + distance);

        if (distance > 0.95)
        {
            transform.position = Vector3.MoveTowards(transform.position, leader.position, Time.deltaTime * speed);
        }
    }
}
