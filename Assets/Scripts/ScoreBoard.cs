using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int score;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>(); // find the text component where the script attached into
        updateScore();
    }

    private void updateScore()
    {
        scoreText.text = score.ToString();
    }

    public void ScoreHit(int scorePerHit)//public method to update the score
    {
        score = score + scorePerHit;
        updateScore();
    }

}
