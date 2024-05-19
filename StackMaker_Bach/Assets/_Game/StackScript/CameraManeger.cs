using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManeger : MonoBehaviour
{
    public Transform target;
    public Vector3 offSet;
    public float speed = 10f;

    private void Start()
    {
        offSet = transform.position - target.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offSet, Time.deltaTime * speed);
    }
}

