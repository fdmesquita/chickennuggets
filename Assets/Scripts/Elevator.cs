using UnityEngine;

public class Elevator : MonoBehaviour
{
	public float speed;
	public Transform[] waypoints;

	public SpriteRenderer graphics;

	private Transform target;
	private int destPoint = 0;
	void Start()
    {
		target = waypoints[0];
		}

	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
		// If enemy closed to its destination
		if (Vector3.Distance(transform.position, target.position) < 0.3f)
		{
			// if waypoints.Length = 5, destPoints will take the values 
			// x=0 => 1 (go to dest 1)
			// x=1 => 2, x=2 => 3, x=3 => 4, x=4 => 5 (go to dest 5)
			// x=5 => 0 (go back to dest 0)
			// in other words, enemy comes back to origin
			destPoint = (destPoint + 1) % waypoints.Length;
			target = waypoints[destPoint];
		}
	}

}
