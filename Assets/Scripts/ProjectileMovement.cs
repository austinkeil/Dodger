using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed;
    public Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
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
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player"){
            Debug.Log("Collision detected!");
        }
    }
}
