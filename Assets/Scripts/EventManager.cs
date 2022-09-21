/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager {
    /* 
    * Private reference of our instance to us
    * Public reference so that if someone tries to call us...
    * (and we don't exist)
    * ...a new instance of us will be made
    * It's wierd but it works...
    */
    /*
    private static EventManager instance;
    public static EventManager Instance {
        get
        {
            if(instance == null) {
                instance = new EventManager();
            }
            return instance;
        }
    }  
    //public static GameState currentGameState = GameState.Play;

    // Don't get any funny ideas just because I'm using lambda expressions () => {}
    // I still hate this things. Nobody use them!! >:(
    // Either way, all these events have to be filled with atleast one function in order to, yknow, work
    public Action PauseEvent = () => { Debug.Log("Event Fired: Pause"); currentGameState = GameState.Paused; };
    public Action UnpauseEvent = () => { Debug.Log("Event Fired: Unpause"); currentGameState = GameState.Play; };


    /*
     * Things to test:
     * Writing specific SubscribeToEvent() and FireEvent() functions
     * see if you can pass in delegates as input values, since Actions and Funcs should be considered delegates too
     * Delete the Game Event Enum
     */

    //Empty constructor for the sake of being able to create this component out of thin air
    /*  private EventManager() {
    }
    //So this should manage the spawners, calling an event when the player is in the scene the spawners are in.
    //This event will activate the spawners and fill them with enimies.
    

}

*/