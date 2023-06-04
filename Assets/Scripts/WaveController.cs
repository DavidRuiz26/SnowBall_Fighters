using UnityEngine;
using UnityEngine.UI;
public class WaveController : MonoBehaviour
{
    private Text tm;
    public GameObject spawnZone;
    private int wave = 1;

    void Start()
    {
        tm = gameObject.GetComponent(typeof(Text)) as Text;
        tm.text = $"Wave: {wave}";
    }

    public void UpdateText()
    {
        wave = spawnZone.GetComponent<SpawnZone>().CheckWave();
        tm.text = $"Wave: {wave}";
    }
}
