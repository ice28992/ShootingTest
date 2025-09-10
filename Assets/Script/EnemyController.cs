using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	float fallSpeed;
	float rotSpeed;

	void Start () {
		this.fallSpeed = 0.005f + 0.005f * Random.value;
		this.rotSpeed = 5f + 3f * Random.value;
	}
	
	void Update () {
		transform.Translate( 0, -fallSpeed, 0, Space.World);

		if (transform.position.y < -5.5f)
		{
			GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
			FindObjectOfType<EnemyGenerator>()?.StopGenerate();
			Destroy(gameObject);
		}
	}
}