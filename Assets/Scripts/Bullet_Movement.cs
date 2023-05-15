using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private float timeLife = 5f;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeLife);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Valla")
        {
            Destroy(gameObject); 
        }
    }
}