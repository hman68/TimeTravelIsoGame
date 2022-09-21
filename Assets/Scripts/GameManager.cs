using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Note to fix this
    public GameObject player {get;set;}
    public Transform playerTransform {get;set;}
    // Start is called before the first frame update
     void Start()
    {
        //This player will keep track of the player for other calculations so that most game objects wont need to continously find the player
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = player.transform;
    }
}
