using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;
	// public GameObject objectToCreate;

	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
					Destroy(objectToDestroy, 0.1f);
			// Instantiate(objectToCreate);
				}
    }

}