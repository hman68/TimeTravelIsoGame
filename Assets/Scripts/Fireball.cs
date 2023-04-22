using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile
{
    protected const float damage = 10f;
    private float flightTime = 5f;
    [SerializeField] private GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ProjectileFlight());
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    protected IEnumerator ProjectileFlight()
    {
        yield return new WaitForSecondsRealtime(flightTime);
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    protected void OnCollisionEnter(Collision collision){
        GameObject exp = Instantiate(explosion, transform.position, transform.rotation);
        Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), exp.GetComponent<Collider>());
        base.OnCollisionEnter(collision);
    }
}
