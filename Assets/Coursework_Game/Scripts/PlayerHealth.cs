using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 2;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            StartCoroutine(Respawn());
        }
    }

    private System.Collections.IEnumerator Respawn()
    {
        Camera.main.backgroundColor = Color.black;

        yield return new WaitForSeconds(1f);

        transform.position = new Vector3(-1.66f, -1.92f, 0f);

        currentHealth = maxHealth;

        Camera.main.backgroundColor = Color.gray; 
    }
}
