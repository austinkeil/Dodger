using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodProjectileMovement : MonoBehaviour
{
    public float speed;
    public Vector3 dir;
	GameObject player;                          // Reference to the player GameObject.
	PlayerHealth playerHealth;                  // Reference to the player's health.
    public int attackDamage = 20;
	private ScoreScript score;

	// Start is called before the first frame update	
	void Start()
    {
		//This is an inefficient way of initializing these values, this should be moved
		//to ProjectileGeneration or PlayerMovement
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);

        if (playerHealth.isDead)
        {
	        Destroy(gameObject);
	        
        }

        if (transform.localPosition.x < -50)
        {
            Destroy(gameObject);
            Debug.Log("Item destroyed!!!");
        }
        
    }
	
	//Detects when a projectile collides with a player
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Player"){
			Debug.Log("Good Collision detected!");
			playerHealth.TakeHealth(attackDamage);
			Destroy(gameObject);
		}
	}
	
}
