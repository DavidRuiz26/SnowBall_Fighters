using UnityEngine;
using UnityEngine.UI;
public class EnemiesLeftController : MonoBehaviour
{
    private Text tm;

    void Start()
    {
        tm = gameObject.GetComponent(typeof(Text)) as Text;
        tm.text = $"Enemies Left";
    }

    public void UpdateText(int enemiesLeft)
    {
        tm.text = $"Enemies Left: {enemiesLeft}";
    }
}
