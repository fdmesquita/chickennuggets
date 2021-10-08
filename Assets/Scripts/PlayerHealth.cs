using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

	public int maxHealth = 3;
	public int currentHealth;
	public float invincibilityTimeAfterHit = 1.5f;
	public float invincibilityFlashDelay = 0.2f;
	public bool isInvincible = false;
	public SpriteRenderer graphics;

	public HealthBar healthBar;
	void Start()
    {
		currentHealth = maxHealth;
		healthBar.setMaxHealth(maxHealth);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
				{
					TakeDamage(1);
				}
        if (Input.GetKeyDown(KeyCode.J))
				{
					HealDamage(1);
				}
    }

		public void TakeDamage(int damage)
		{
			if(!isInvincible)
			{
				currentHealth -= damage;
				healthBar.setHealth(currentHealth);

				if(currentHealth <= 0)
				{
				Die();
				return;
				}

				isInvincible = true;
				StartCoroutine(InvincibilityFlash());
				StartCoroutine(HandleInvincibilityDelay());
			}
		}

		public void Die()
		{
		Debug.Log("Player is dead !");
		// Prevent Player to move
		PlayerMovement.instance.enabled = false;
		// Play Die animation
		PlayerMovement.instance.animator.SetTrigger("Die");
		// Prevent physical interactions with other elements
	}

		public IEnumerator HandleInvincibilityDelay()
		{
		yield return new WaitForSeconds(invincibilityTimeAfterHit);
		isInvincible = false;
		}

		public IEnumerator InvincibilityFlash()
		{
			while (isInvincible)
			{
			graphics.color = new Color(1f, 1f, 1f, 0f);
			yield return new WaitForSeconds(invincibilityFlashDelay);
			graphics.color = new Color(1f, 1f, 1f, 1f);
			yield return new WaitForSeconds(invincibilityFlashDelay);
			}
		}
		
		
		void HealDamage(int damage)
		{
		currentHealth += damage;
		healthBar.setHealth(currentHealth);
		}
}
