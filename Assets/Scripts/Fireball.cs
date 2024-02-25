using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed = 5f;
    public float LifeTimeLimit;
    public float Damage = 10f;

    private void Start()
    {
        Invoke("DestroyFareball", LifeTimeLimit);
    }
    void FixedUpdate()
    {
        MoveFixedUpdate();
    }
    private void MoveFixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
    }
    private void OnCollisionEnter(Collision Collision)
    {
        FireballDamage(Collision);
        DestroyFareball();
    }
    private void DestroyFareball()
    {
        Destroy(gameObject);
    }
    private void FireballDamage(Collision Collision)
    {
        var enemyHealth = Collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(Damage);
        }
        
    }
}
