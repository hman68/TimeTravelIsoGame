using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected float speed;
    public const float rps = 1f;
    [System.NonSerialized] public float playerSpeed;
    public PlayerController player;
    protected const float damage = 5f;

    protected void Start()
    {
        StartCoroutine(ProjectileFlight());
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed);
    }

    // Update is called once per frame
    protected void Update()
    {
        Debug.DrawRay(transform.position, transform.rotation * Vector3.forward);
    }

    protected IEnumerator ProjectileFlight()
    {
        yield return new WaitForSecondsRealtime(5f);
        Destroy(this.gameObject);
    }



    protected void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        collision.gameObject.SendMessage("takeDamage", damage);
        Destroy(this.gameObject);
    }
}
