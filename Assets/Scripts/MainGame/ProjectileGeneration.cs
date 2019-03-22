using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGeneration : MonoBehaviour
{
    public float rate;
    public Vector3 center;
    public Vector3 size;
    public GameObject Projectileprefab;
    public float xRotation;
    public float yRotation;
    public float zRotation;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnProjectile", 0, rate);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnProjectile()
    {
        Vector3 pos = transform.localPosition + center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2),
                          Random.Range(-size.z / 2, size.z / 2));
        Instantiate(Projectileprefab, pos, Quaternion.Euler(new Vector3(xRotation, yRotation, zRotation)));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0,0,5f);
        Gizmos.DrawCube(transform.localPosition + center, size);
    }
}
