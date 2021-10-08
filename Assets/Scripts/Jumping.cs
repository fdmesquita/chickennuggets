using System.Collections;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public Animator jump;

    private void Awake()
    {
        jump = GameObject.FindGameObjectWithTag("Jump").GetComponent<Animator>();
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            jump.SetTrigger("Jumping");
        }
    }
}
