using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	private Transform playerSpawn;
	private void Awake()
	{
	playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			playerSpawn.position = transform.position;
			// If we want to keep the last checkpoint only.
			// Destroy(GameObject);
			//gameObject.GetComponents<BoxCollider2D>().enabled = false;
		}
	}

}
