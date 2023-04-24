using System.Collections.Generic;
using UnityEngine;

public class BallStack : MonoBehaviour
{
    public GameObject ballPrefab;
    public int maxStackSize = 10;

    private List<GameObject> ballList = new List<GameObject>();

    private void Start()
    {
        ballList.Add(gameObject);
    }

    public void SpawnBall()
    {
        GameObject newBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        newBall.transform.parent = transform;
        ballList.Add(newBall);

        if (ballList.Count > maxStackSize)
        {
            GameObject oldBall = ballList[0];
            ballList.RemoveAt(0);
            Destroy(oldBall);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            SpawnBall();
        }
    }
}
