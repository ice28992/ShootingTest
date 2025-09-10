using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Sprite[] enemySprites;

    void Start()
    {
        InvokeRepeating("GenerateEnemy", 1, 1);
    }

    public void StopGenerate()
    {
        CancelInvoke("GenerateEnemy");
    }

    void GenerateEnemy()
    {
        // 敵生成
        GameObject enemy = Instantiate(
            enemyPrefab, 
            new Vector3(-2.5f + 5 * Random.value, 6, 0), 
            Quaternion.identity
        );

        // スプライトランダム
        int index = Random.Range(0, enemySprites.Length);
        SpriteRenderer sr = enemy.GetComponent<SpriteRenderer>();
        sr.sprite = enemySprites[index];
    }
}
