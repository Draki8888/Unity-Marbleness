using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float yOffset = 3f;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + Vector3.up * yOffset;
    }
}
