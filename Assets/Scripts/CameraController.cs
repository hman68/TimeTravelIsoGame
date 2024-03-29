using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Transform playerPos;
    public float xConstraints = 10.0f;
    public float yConstraints = 10.0f;
    public float distance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerPos = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float xVal = Mathf.Clamp(playerPos.position.x, -xConstraints, xConstraints);
        float yVal = Mathf.Clamp(playerPos.position.z , -yConstraints, yConstraints);
        transform.position = new Vector3(xVal, 5 , yVal);
    }
}
