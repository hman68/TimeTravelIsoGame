using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemiesToSpawn;
    public float timeBetweenSpawns;
    public float numToSpawn;
    public float length;
    public float width;
    public float enemySpawned;
    private Vector3 spawnLocation;
    Collider collider;
    public GameObject spawnController;
    GameObject gameManager;
    GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        length = collider.bounds.size.x;
        width = collider.bounds.size.y;
        //This will get the player's transform so that spawned enemies can look at the player when they spawn. In the future, the spawners should be children of the spawn controller, so this will be removed.
        spawnController = GameObject.FindWithTag("Spawn Controller");
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Ok so in theory, the spawner will already be given some enemies to spawn
    //So it will pick one at random, spawn it, and remove it from the array
    //Also in theory, the spawns are weighted based on how many enemies are in the array
    //So there, for example, should be 5 weak enemies and a strong one
    //To reduce lag, spawners will set themselves to be inactive after they finish spawning
    //If you continue to spawn enemies, reload the event that will activate the spawners
    public void Spawn(GameObject[] enemiesToSpawn, float timeBetweenSpawns, float numToSpawn, bool infiniSpawn, float invulTime) 
    {
        //So in theory, spawnLocation should get the length of the spawner, or how much it covers on the x axis, and how wide it is, or how long it covers on the z axis.
        spawnLocation = new Vector3(Random.Range(-length, length), 15, Random.Range(-width, width));
        this.enemiesToSpawn = enemiesToSpawn;
        enemySpawned = Random.Range(0,enemiesToSpawn.Length);
        //If enemies are supposed to be invulnerable when they spawn, will change a variable that will make them invulnerable
        //This either means we need to have an self-removing invulnerable script, or a variable on every enemy that will make them invulnerable.
        //My current idea is to make an interface and to make everything implement said interface, so that the spawner can call an event that will add invulnerability when it spawns something
        //if (invulTime != 0)
        //{
        //    GameObject newObj = Instantiate(enemiesToSpawn[(int)enemySpawned], spawnLocation, transform.LookAt(90)) as GameObject;
        //    In
        //
        //}
       // Transform tempTransform = gameManagerScript.GetComponent<SpawnController>().playerTransform;
       // Instantiate(enemiesToSpawn[(int)enemySpawned], spawnLocation, transform.LookAt(tempTransform));//I am assuming that enemies will be able to look at the player
        if(!infiniSpawn)this.numToSpawn--;
        if (numToSpawn == 0) gameObject.SetActive(false);
        this.timeBetweenSpawns = timeBetweenSpawns;
    }
}
