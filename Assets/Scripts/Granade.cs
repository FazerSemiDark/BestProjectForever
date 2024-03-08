using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    public float delay= 3f;
    public GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explosion", delay);
    }
    private void Explosion()
    {
        Destroy(gameObject);
        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
    }
}
