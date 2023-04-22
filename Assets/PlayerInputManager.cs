using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private DefaultInput inputs;
    private GameObject player;

    void Awake(){
        inputs = new DefaultInput();
    }
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.GetObjectby("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
