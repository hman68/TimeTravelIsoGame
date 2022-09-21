using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnController : MonoBehaviour
{
    /*Ok, so after thinking it out and talking about it, there are two plans to do spawners
     * Plan A is to have the spawners set by a trigger, and so when the player steps on the trigger, the spawners are set to active.
     * This would be the easiest, if manually intensive way to do it.
     * Plan B is to have the spawners instead be set as active or inactive depending on if they are within the radius
     *This way would be resourse intensive, as distance would need to be constantly recalculated.
     */
    public float radius;
    public GameObject[] Spawners;
    private float[] spawnerDistance;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnEnable() 
    {
        //This calls an the OnSceneLoaded event anytime a scene changes. So that it can check for spawners when the scene changes.
        SceneManager.sceneLoaded += OnSceneLoaded;
        //Ok so my first thought was to check distance for each spawner constantly and see which will need to be deactivated or activated
        //But I think that will be too resource intensive, so I want to find a better solution.
    }
    //This simply looks for every Spawner and adds them to an array, if the spawners are outside of the radius, then the spawners are taken outside of the array.
    //I've never used dynamic arrays, so I'm not sure if this will work
    void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
    {
        Spawners = GameObject.FindGameObjectsWithTag("Spawner");
        for (int i = 0; i < Spawners.Length; ++i) 
        {
            float distanceFromPlayer = Vector3.Distance(this.transform.position, Spawners[i].transform.position);
            if (distanceFromPlayer > radius)
            {
                Spawners[i] = null;
                --i;
            }
            else spawnerDistance[i] = Vector3.Distance(this.transform.position, Spawners[i].transform.position);
        }
    }
}
