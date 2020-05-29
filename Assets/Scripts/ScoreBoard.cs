using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int score;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        updateScore();
    }

    private void updateScore()
    {
        scoreText.text = score.ToString();
    }

    public void ScoreHit(int scorePerHit)
    {
        //change a
        score = score + scorePerHit;
        updateScore();
    }

}
