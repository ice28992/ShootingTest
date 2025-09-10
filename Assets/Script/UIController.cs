using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	int score = 0;
    public static int result;
	GameObject scoreText;
    GameObject gameOverText;

    // GameOver
    public void GameOver()
    {
        this.gameOverText.GetComponent<Text>().text = "Game Over";
        result = this.score;
        Invoke("GoResultScene", 2.0f);
    }

    void GoResultScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
    }

    // Scoreの加算
    public void AddScore()
    {
        this.score += 20;
    }

    void Start()
    {
        this.scoreText = GameObject.Find("Score");
        this.gameOverText = GameObject.Find ("GameOver");
	}

	void Update () {
		scoreText.GetComponent<Text>().text = "Score:" + score.ToString("D4");
	}
}