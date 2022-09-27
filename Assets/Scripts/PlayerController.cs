using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerController : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
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
            playerRB.AddForce(-playerRB.velocity.x * speed * 0.1f,0f,0f);
        }
        if(verticalInput == 0){
            playerRB.AddForce(0f,0f,-playerRB.velocity.z * speed * 0.1f);
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

}
