using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLookAt : MonoBehaviour
{
    public Transform target;
    public float adjustment;
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - adjustment;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
