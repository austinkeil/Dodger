using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody rb;
    private PlayerHealth playerHealth;
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        speed = 10;
    }
	
    void FixedUpdate(){
		
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0.0f,moveVertical, -moveHorizontal);
        if (playerHealth.isDead) speed = 0;
        rb.velocity = (movement * speed);

    }
        
}
