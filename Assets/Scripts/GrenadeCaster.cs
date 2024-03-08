using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public Transform GranadeSourseTransform;
    public Granade GranadePrefab;
    public float Force = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SpawnGranade();
        }
    }
    private void SpawnGranade()
    {
        var Granade = Instantiate(GranadePrefab);
        Granade.transform.position = GranadeSourseTransform.position;
        Granade.GetComponent<Rigidbody>().AddForce(GranadeSourseTransform.forward * Force);
    }
}
