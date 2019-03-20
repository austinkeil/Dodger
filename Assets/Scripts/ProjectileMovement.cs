using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed;
    public Vector3 dir;
	GameObject player;                          // Reference to the player GameObject.
	PlayerHealth playerHealth;                  // Reference to the player's health.
    public int attackDamage = 20;               // The amount of health taken away per attack.

	// Start is called before the first frame update	
	void Start()
    {
		//This is an inefficient way of initializing these values, this should be moved
		//to ProjectileGeneration or PlayerMovement
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
        if (transform.localPosition.x < -50)
        {
			
            Destroy(gameObject);
        }
        
    }
	
	//Detects when a projectile collides with a player
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Player"){
			Debug.Log("Collision detected!");
			playerHealth.TakeDamage(attackDamage);
		}
	}
	
	
}
