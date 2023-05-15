using UnityEngine;
using UnityEngine.UI;
public class WaveController : MonoBehaviour
{
    private Text tm;
    void Start()
    {
        tm = gameObject.GetComponent(typeof(Text)) as Text;
        tm.text = $"Wave: {1}";
    }

    public void UpdateText(int wave)
    {
        tm.text = $"Wave: {wave}";
    }
}
