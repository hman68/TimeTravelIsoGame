using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerController : MonoBehaviour
{
    private Projectile equippedProjectile;
    private Projectile altEquippedProjectile;
    private Rigidbody playerRB;
    private float horizontalInput;
    private float verticalInput;
    private float prevHoriz;
    private float prevVert;
    private float hyp;
    private DefaultInput PlayerInput;
    private InputAction movementVector;
    public float maxSpeed;
    public float speed;
    public bool rtf = true, rtf2 = true;
    [SerializeField] private MovementAction MovemementScript;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        equippedProjectile = Resources.Load<Projectile>("Prefabs/Projectiles/Projectile");
        altEquippedProjectile = Resources.Load<Projectile>("Prefabs/Projectiles/Fireball");
    }
    void Awake(){
        PlayerInput = new DefaultInput();
    }
    void OnEnable(){
        movementVector = PlayerInput.Player.Move;
        movementVector.Enable();
    }
    void OnDisable(){
        movementVector.Disable();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = movementVector.ReadValue<Vector2>().x;
        verticalInput = movementVector.ReadValue<Vector2>().y;
        hyp = MathF.Sqrt((horizontalInput * horizontalInput)+(verticalInput * verticalInput));
        if(!GetComponent<MovementAction>().isDashing && hyp != 0){
            if(Math.Sign(horizontalInput) == -1*Math.Sign(playerRB.velocity.x)){
                horizontalInput *= 5;
            }
            if(Math.Sign(verticalInput) == -1*Math.Sign(playerRB.velocity.z)){
                verticalInput *= 5;
            }
            playerRB.AddForce(new Vector3((horizontalInput/hyp)*speed ,0f, (verticalInput/hyp) * speed ), ForceMode.Acceleration);
        }
        if(!GetComponent<MovementAction>().isDashing){
            Vector3 vel = playerRB.velocity;
            if(vel.magnitude > maxSpeed){
                vel = playerRB.velocity;
                Vector3.ClampMagnitude(vel, maxSpeed);
                playerRB.velocity = vel;
            }
        }
        if(horizontalInput == 0){
            playerRB.AddForce(-playerRB.velocity.x * speed * 0.5f,0f,0f);
        }
        if(verticalInput == 0){
            playerRB.AddForce(0f,0f,-playerRB.velocity.z * speed * 0.5f);
        }
        if(Mathf.Abs(playerRB.velocity.x) < 0.001f){
            playerRB.velocity = new Vector3(0f, playerRB.velocity.y, playerRB.velocity.z);
        }
        if(Mathf.Abs(playerRB.velocity.z) < 0.001f){
            playerRB.velocity = new Vector3(playerRB.velocity.x, playerRB.velocity.y, 0f);
        }
    }

    public void takeDamage(float dam){

    }
    public void OnFire(){
        Debug.Log("FireAttempt");
        Debug.Log(rtf);
        if(rtf == true){
            Debug.Log("Fired");
            Projectile proj = Instantiate(equippedProjectile, transform.position, transform.rotation);
            proj.player = this as PlayerController;
            proj.playerSpeed = playerRB.velocity.magnitude;
            rtf = false;
            proj.SendMessage("Start");
            StartCoroutine(WaitUntilReadyToFire(proj, false));
        }
    }

    public void OnDash(){
        if(MovemementScript.ready == true){
            Debug.Log("Dash Attempt");
            StartCoroutine(MovemementScript.Dash());    
        }
    }
    
    public void OnAltFire(){
        if(rtf2){
            Projectile proj = Instantiate(altEquippedProjectile, transform.position, transform.rotation);
            proj.player = this as PlayerController;
            proj.playerSpeed = playerRB.velocity.magnitude;
            rtf2 = false;
            proj.SendMessage("Start");
            StartCoroutine(WaitUntilReadyToFire(proj, true));
        }
    }

    protected IEnumerator WaitUntilReadyToFire(Projectile p, bool alt)
    {
        yield return new WaitForSecondsRealtime(1/Projectile.rps);
        if(alt){
            rtf2 = true;
        }else{
            rtf = true;
        }
    }
}
