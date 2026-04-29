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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            scoreText.text = $"Score: {score++}";
        }
        else
        {
            Debug.Log("Error: score cannot count!");
        }
    }
}
