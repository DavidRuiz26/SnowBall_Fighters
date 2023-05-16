using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    private int score = 0;
    private Text tm;

    void Start()
    {
        tm = gameObject.GetComponent(typeof(Text)) as Text;
        tm.text = $"Score";
    }

    public void UpdateScore()
    {
        score++;
        tm.text = $"Score: {score}";
    }
}
