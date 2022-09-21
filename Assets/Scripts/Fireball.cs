using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    //So the fireball will have an aoe. It will explore either upon hitting terrain, an enemy, or when it runs out of duration.
    //It is assumed that the fireball will also have the projectile script attached, so movement is not covered here.
    // Start is called before the first frame update
    float timeToExplode;
    Vector3 center;
    public float radius;
    public float damage;
    public bool enemyFired;
    float animTime;
    void Start()
    {
        timeToExplode = 10.0f;
        //The fireball will explode at a set time
        explode(timeToExplode  * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision other) 
    {
        explode(0.1f);
    }
    //Ok so this method takes in a float, time. Time determines how long it will take for the fireball to explode.
    //But before the fireball explodes, an animation is played. This animation will play between the first and second waitforseconds
    //When it does explode, the fireball will get all colliders within the radius of the center(itself) creating a circle of damage.
    //If the player fired the fireball, then it will only damage enemies
    //If an enemy did, it will only damage the player
    IEnumerator explode(float time) 
    {
        yield return new WaitForSeconds(time);
        //An explosion animation will play here;
        yield return new WaitForSecondsRealtime(animTime);
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders) 
        {
            if (enemyFired)
            {
                PlayerController playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
                playerScript.takeDamage(damage);
                break;
            }
            else
            {
                //If the player was in the radius of their own fireball, the loop will skip their collider so they dont take damage.
                if (hitCollider.tag == "Player") continue;
                SendMessage("takeDamage", damage);
            }
        }
        Destroy(this);
    }
}
