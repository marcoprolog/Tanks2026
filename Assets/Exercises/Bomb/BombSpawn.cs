using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour {

    //in this case, like in the coin spawning in the 2D platformer, I created an empty object as a child of the tank to use as a spawn point
    //this object has to be dragged in this transform variable
    public Transform bombSpawnPoint;
    public GameObject bombPrefab;
    //cooldown variables
    public int rechargingTime = 5;
    bool recharging = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if the specified key is pressed and we are not recharging (in cooldown)
		if (Input.GetKeyDown(KeyCode.Space) && !recharging)
        {
            //create the bomb at the specific position defined by bombSpawnPoint
            Instantiate(bombPrefab, bombSpawnPoint.position, Quaternion.identity);
            //set that we are in cooldown
            recharging = true;
            //after the cooldown time call FinishRecharging, which will allow us to spawn another bomb
            Invoke("FinishRecharging", rechargingTime);
        }
	}

    void FinishRecharging()
    {
        recharging = false;
    }
}
