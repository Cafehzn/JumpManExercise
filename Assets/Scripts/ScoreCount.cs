using TMPro;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;
    private void Start()
    {
        scoreText.text = $"Score: {score}";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            score++;
            scoreText.text = $"Score: {score} ";
        }
    }

}
