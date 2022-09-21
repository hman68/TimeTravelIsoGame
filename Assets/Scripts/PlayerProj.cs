using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProj : MonoBehaviour
{
    float speed = 10f;
    Rigidbody clone;

    // Start is called before the first frame update
    void Start()
    {
        clone = GetComponent<Rigidbody>();
        clone.AddForce(clone.rotation * Vector3.forward * speed, ForceMode.VelocityChange); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        other.SendMessage("takeDamage", 5f);
        Debug.Log(other.name);
        Destroy(this.gameObject);
    }
}
