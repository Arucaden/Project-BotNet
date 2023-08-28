using UnityEngine;

public class Virus : MonoBehaviour
{
    // Start is called before the first frame update
    public VirusSO virus;
    private int currentHealth;
    EnemyController enemyctrl;

    private void Start() 
    {
        enemyctrl = GetComponent<EnemyController>();
        enemyctrl.movSpeed = virus.movSpeed;
    }

    private void Update() 
    {
        enemyctrl.GetTransform(transform);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0 )
        {
            Destroy(gameObject);
        }
    }
}
