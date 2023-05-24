using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossDisparador : MonoBehaviour
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
        for (int i = 0; i < maxCounter; i++)
        {
            counter++;
            var offset = new Vector3(Mathf.Sin(transform.eulerAngles.y * Mathf.Deg2Rad), 0, Mathf.Cos(transform.eulerAngles.y * Mathf.Deg2Rad)) * 1;
            Instantiate(bullet, transform.position + offset, transform.rotation);
            yield return new WaitForSeconds(timer);
        }
        Debug.Log("Fin coroutine");
    }
}
