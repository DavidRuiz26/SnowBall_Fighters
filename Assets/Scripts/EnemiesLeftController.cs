using UnityEngine;
using UnityEngine.UI;
public class EnemiesLeftController : MonoBehaviour
{
    private Text tm;
    public GameObject spawnZone;
    private int enemiesLeft;

    void Start()
    {
        tm = gameObject.GetComponent(typeof(Text)) as Text;
        tm.text = $"Enemies Left";
    }

    public void UpdateText()
    {
        enemiesLeft = spawnZone.GetComponent<SpawnZone>().CheckNumberOfEnemies();
        tm.text = $"Enemies Left: {enemiesLeft}";
    }
}
