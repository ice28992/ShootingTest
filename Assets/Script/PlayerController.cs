using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public GameObject bulletPrefab;
	public AudioClip shotSound;
	public AudioClip pbreakSound;
    private AudioSource audioSource;

	void Start()
    {
		// AudioSource取得
        audioSource = GetComponent<AudioSource>();
    }

	void Update()
	{
		// キー入力関係
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(-transform.right * 0.01f); // 左
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(transform.right * 0.01f); // 右
		}
		// if (Input.GetKey(KeyCode.UpArrow))
		// {
		// 	transform.Translate(transform.up * 0.01f); // 上
		// }
		// if (Input.GetKey(KeyCode.DownArrow))
		// {
		// 	transform.Translate(-transform.up * 0.01f); // 下
		// }
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Instantiate(bulletPrefab, transform.position, Quaternion.identity);
			if (shotSound != null)
            {
                audioSource.PlayOneShot(shotSound);
            }
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		// 自機が敵にぶつかったときGameOver
		if (other.CompareTag("Enemy"))
		{
			GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
			GameObject.Find("EnemyGenerator").GetComponent<EnemyGenerator>().StopGenerate();
			// 効果音を別オブジェクトで再生してからプレイヤーを破壊
			if (pbreakSound != null)
			{
				GameObject tempAudio = new GameObject("TempAudio");
				AudioSource tempSource = tempAudio.AddComponent<AudioSource>();
				tempSource.PlayOneShot(pbreakSound);
				Destroy(tempAudio, pbreakSound.length); // 再生後に削除
			}

			// プレイヤーを削除（音の再生には影響なし）
			Destroy(gameObject);
		}
	}
}