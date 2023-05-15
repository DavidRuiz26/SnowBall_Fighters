using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip bonk;

    [SerializeField]
    private float timeLife = 5f;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeLife);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Valla"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(bonk);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(bonk);
            Destroy(gameObject);
        }

        if (other.CompareTag("Valla"))
        {
            Destroy(gameObject);
        }
    }
}
