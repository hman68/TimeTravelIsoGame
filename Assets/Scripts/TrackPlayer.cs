using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    //This script will allow objects, and hopefully projectiles, to rotate towards the player.
    // Start is called before the first frame update
    GameObject player;
     

    void Start()
    {
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player.transform.position);
    }
}
