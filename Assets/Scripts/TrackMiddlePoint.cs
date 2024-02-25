using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMiddlePoint : MonoBehaviour
{
    public Transform FirstPoint;
    public Transform SecondPoint;

    private void Start()
    {
        GetComponent<Transform>();
    }
    void Update()
    { 
        transform.position = Vector3.Lerp(FirstPoint.position, SecondPoint.position, 0.5f);
    }
}
