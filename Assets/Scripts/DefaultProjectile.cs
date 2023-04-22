/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    protected Rigidbody proj;
    protected Rigidbody player;
    protected bool rtf; // ready to fire
    public float rpm;
    public float travelTime;
    protected void Start()
    {
        rtf = true;
        speed = 25.0f;
        player = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
        proj = GameObject.FindWithTag("Projectile").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && rtf){
            StartCoroutine(Shoot());
            Debug.Log("Shoot");
        }
    }

    protected IEnumerator Shoot(){
        Rigidbody clone;
        rtf = false;
        clone = (Rigidbody)Instantiate(proj, player.position + (player.rotation * new Vector3(0,0.5f,1.5f)), new Quaternion(0f, player.rotation.y, 0f, player.rotation.w));
        clone.gameObject.AddComponent<PlayerProj>();
        yield return new WaitForSecondsRealtime((60f/rpm));
        rtf = true;
        yield return new WaitForSecondsRealtime(travelTime);
        if(clone.gameObject){
            Destroy(clone.gameObject);
        }
    }
}
*/