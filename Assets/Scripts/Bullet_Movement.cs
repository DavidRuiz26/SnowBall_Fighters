using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Movement : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 12f;
    [SerializeField]
    private float minSpeed = 7f;
    [SerializeField]
    private float timeLife = 10f;

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeLife);
        speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
