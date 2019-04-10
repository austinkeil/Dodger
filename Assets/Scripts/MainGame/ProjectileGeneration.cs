using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Random = UnityEngine.Random;

public class ProjectileGeneration : MonoBehaviour
{
	
	enum Difficulty {EASY = 0, NORMAL, HARD};
    public float rate;
    public Vector3 center = new Vector3(2f, 2.5f, 2.5f);
    public Vector3 size = new Vector3(1f, 5f, 5f);
    public GameObject Projectileprefab;
	GameObject player;                          // Reference to the player GameObject.
	PlayerHealth playerHealth;                  // Reference to the player's health.
    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		if (PlayerPrefs.GetInt("Difficulty") != null)SetDifficulty();
        InvokeRepeating("SpawnProjectile", 0, rate);
    }


    void SetDifficulty()
    {

	    switch (PlayerPrefs.GetInt("Difficulty"))
	    {
		    case (int)Difficulty.EASY : rate = 1f;
			    
			    break;
		    
		    case (int)Difficulty.NORMAL : rate = 0.1f;
			    
			    break;
		    
		    case (int)Difficulty.HARD : rate = 0.001f;
			    
			    break;
		    
	    }

	    

	  

    }

    // Update is called once per frame
    void Update()
    {
		if (playerHealth.isDead){
			CancelInvoke();
			Destroy(gameObject);
		}
    }

    public void SpawnProjectile()
    {
        Vector3 pos = transform.localPosition + center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2),
                          Random.Range(-size.z / 2, size.z / 2));
        Instantiate(Projectileprefab, pos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0,0,5f);
        Gizmos.DrawCube(transform.localPosition + center, size);
    }
}
