using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGeneration : MonoBehaviour
{
    public float rate = 0.3f;
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
		
        InvokeRepeating("SpawnProjectile", 0, rate);
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
