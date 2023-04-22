using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAction : MonoBehaviour
{
    private Rigidbody rb;
    public float dashLen;
    public float dashSpeed;
    public float cooldown;
    private Vector3 normVelocity;
    public bool isDashing;
    public bool ready  { get; private set; } = true;
    private MovementAction dash;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        isDashing = false;
        dash = GetComponent<MovementAction>();
    }

    // Update is called once per frame
    void Update()
    {
       
        /*if(Input.GetKeyDown(KeyCode.Space) && ready)
        {
            Debug.Log("DashAttempt");
            StartCoroutine(Dash());
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Space");
        }*/

    }
    /*
    Dashes the character in a certain direction
    */
    public IEnumerator Dash()
    {
        Debug.Log("Dashing");
        isDashing = true;
        ready = false;
       normVelocity = rb.velocity;
        rb.velocity = new Vector3(dashSpeed * (rb.velocity.x/rb.velocity.magnitude), rb.velocity.y,  dashSpeed * (rb.velocity.z/rb.velocity.magnitude));
        Debug.Log(rb.velocity);
        yield return new  WaitForSecondsRealtime(dashLen);
        Debug.Log("endDash");
        rb.velocity = normVelocity;
        isDashing = false;
        yield return new WaitForSecondsRealtime(cooldown);
        ready = true;
    }
}
