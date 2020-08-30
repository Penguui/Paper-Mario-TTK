using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float cameraDistOffset = 9;
    private Camera mainCamera;
    private GameObject player;
    private GameObject[] characters;

    // Use this for initialization
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        player = GameObject.Find("Mario");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerInfo = player.transform.transform.position;
        mainCamera.transform.position = new Vector3(playerInfo.x, playerInfo.y + 4.186303f, playerInfo.z - cameraDistOffset);
    }

}
