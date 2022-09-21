using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private GameObject player;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
