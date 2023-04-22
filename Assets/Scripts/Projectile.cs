using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    [System.NonSerialized] public float playerSpeed;
    private Rigidbody projRb;
    public GameObject player;
    protected void Awake()
    {

    }

    // Update is called once per frame
    protected void Update()
    {
        rm.Translate(transform.forward * speed * Time.deltaTime);
    }
}
