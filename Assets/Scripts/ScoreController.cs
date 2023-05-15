using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    private int score;
    private Text tm;

    void Start()
    {
        tm = gameObject.GetComponent(typeof(Text)) as Text;
        tm.text = $"Score: {score}";
    }

    public void UpdateScore()
    {
        score++;
        tm.text = $"Score: {score}";
    }
}
