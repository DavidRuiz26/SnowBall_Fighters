using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private float timer = 2.5f;

    [SerializeField]
    private int maxCounter = 20;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireBullets_CR());
    }

    IEnumerator FireBullets_CR()
    {
        Debug.Log("Inicio coraoutine");
        for(int i=0; i<maxCounter; i++)
        {
            counter++;
            Instantiate(bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(timer);
        }
        Debug.Log("Fin coroutine");
    }
}
