using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
    public AudioClip sound;
    private AudioSource audioSource;
	void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

	void Update () {
		// 弾発射
		transform.Translate (0, 0.05f, 0);

		if (transform.position.y > 5) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D othor) {
		if (othor.CompareTag("Enemy"))
		{
			// スコア更新
			GameObject.Find("Canvas").GetComponent<UIController>().AddScore();

        // 効果音
        if (sound != null)
        {
            GameObject tempAudio = new GameObject("TempAudio");
            AudioSource tempSource = tempAudio.AddComponent<AudioSource>();
            tempSource.PlayOneShot(sound);

            // 音の長さ分待って削除
            Destroy(sound, sound.length);
        }
			Destroy(othor.gameObject); // 敵を消す
			Destroy(gameObject);       // 弾を消す
		}
	}
}