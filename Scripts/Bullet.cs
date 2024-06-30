using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsEnemies;

    // Damage
    public int explosionDamage;
    public float explosionRange;

    // When it explodes... idk if i want it to explode.
    public int maxCollisions;
    public bool explodeOnTouch = true;

    int collisions;
    PhysicMaterial physics_mat;

    private void Update()
    {
        //when to exploide
        if (collisions > maxCollisions) Explode();
    }

    private void Explode()
    {
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

        //Check for enemys
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemies);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyAI>().TakeDamage(explosionDamage);
        }

        //bug preventino
        Invoke("Delay", 0.05f);
    }

    private void Delay()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisions++;
        //Bullet explode when hits enemy
        if (collision.collider.CompareTag("Enemy") && explodeOnTouch) Explode();
    }
}
