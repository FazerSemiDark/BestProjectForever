using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float maxSize = 5f;
    public float speedScale = 10f;
    public float explosionDamage = 30f;

    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * speedScale;

        if (transform.localScale.x > maxSize)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.DealDamage(explosionDamage);
        }

        var enemyHealth = other.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            Debug.Log(enemyHealth);
            enemyHealth.DealDamage(explosionDamage);
        }
    }
}
