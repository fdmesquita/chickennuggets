using UnityEngine;

public class PlayerSpawnL : MonoBehaviour
{
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
    }
}
