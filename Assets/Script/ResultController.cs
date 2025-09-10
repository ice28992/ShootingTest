using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    void Start()
    {
        // ScoreText オブジェクトを探してスコアを表示
        GameObject scoreText = GameObject.Find("ScoreText");
        int final = UIController.result;
        scoreText.GetComponent<Text>().text = final.ToString("D4") + "点";
    }
}
