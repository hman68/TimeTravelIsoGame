using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushAtPlayer : MonoBehaviour
{
    //Ok so when I read the description, I assumed that the goblins would be moving at normal speeds until they see a player.
    // Start is called before the first frame update
    Transform playerTransform;
    GameObject player;
    //GameManager gameManagerScript;
    Rigidbody enemyRb;
    Vector3 normVelocity;
    [SerializeField]
    float dashLen;
    float distToDash;
    bool isDashing;
    float dashSpeed;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        //gameManager = GameObject.Find("GameManager");
        //gameManagerScript = gameManager.GetComponent<GameManager>();
        //player = gameManagerScript.player;
        player = GameObject.FindWithTag("Player");
        //playerTransform = gameManagerScript.playerTransform;
        playerTransform = player.transform;
        distToDash = 5.0f;
        dashSpeed = 20.0f;
        dashLen = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(playerTransform.position, this.transform.position) < distToDash) 
        {
            StartCoroutine(dash());
        }
    }
    IEnumerator dash() 
    {
        //An animation will play here to indicate that the enemy is going to dash
        //Animation
        //Then the rest of the script will play
        //yield return new WaitForSecondsRealtime(animationTime);
        Debug.Log("Dashing");
        isDashing = true;
        normVelocity = enemyRb.velocity;
        enemyRb.velocity = new Vector3(dashSpeed * (enemyRb.velocity.x / enemyRb.velocity.magnitude), enemyRb.velocity.y, dashSpeed * (enemyRb.velocity.z / enemyRb.velocity.magnitude));
        yield return new WaitForSecondsRealtime(dashLen);
        Debug.Log("endDash");
        enemyRb.velocity = normVelocity;
        yield return new WaitForSecondsRealtime(10);
        isDashing = false;
    }
}
