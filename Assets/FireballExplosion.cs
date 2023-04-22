using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballExplosion : MonoBehaviour
{
    private float damage = 10f;
    private float fadeTime = 0.5f;

    private void Awake(){
        StartCoroutine(Explode());
    }
    protected void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        collision.gameObject.SendMessage("takeDamage", damage);
        Destroy(this.gameObject);
    }

    IEnumerator Explode()
    {
        yield return new WaitForSecondsRealtime(fadeTime);
        Destroy(this.gameObject);
    }
}
