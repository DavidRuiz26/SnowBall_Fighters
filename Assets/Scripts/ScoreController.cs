using UnityEngine;

public class ScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    private int score;
    TextMesh tm;

    void Start()
    {
        tm = gameObject.GetComponent(typeof(TextMesh)) as TextMesh;
        score = 0;
        tm.text = $"Score: {score}";
    }

    public void UpdateScore()
    {
        score++;
        tm.text = $"Score: {score}";
    }
}
