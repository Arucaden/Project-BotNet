using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float attackSpeed = 1f;
    public float attackRange = 5f;
    public int attackDamage = 1;
    public GameObject attackParticles;
    public Transform attackPoint;

    private float attackCooldown = 0f;

    void Update()
    {
        if (attackCooldown <= 0f)
        {
            // Find the nearest enemy
            GameObject nearestEnemy = null;
            float nearestDistance = Mathf.Infinity;
            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance <= attackRange && distance < nearestDistance)
                {
                    nearestEnemy = enemy;
                    nearestDistance = distance;
                }
            }

            if (nearestEnemy != null)
            {
                Attack(nearestEnemy);
                attackCooldown = 1f / attackSpeed;
            }
        }
        else
        {
            attackCooldown -= Time.deltaTime;
        }
    }

    void Attack(GameObject enemy)
    {
        // Rotate attackPoint to face the enemy
        Vector2 direction = enemy.transform.position - attackPoint.position;
        attackPoint.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f);

        // Check if enemy is in range
        RaycastHit2D hit = Physics2D.Raycast(attackPoint.position, direction, attackRange);
        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            // Create attack particles
            Instantiate(attackParticles, hit.collider.transform.position, Quaternion.identity);

            // Damage enemy
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(attackDamage);

            Debug.DrawLine(attackPoint.transform.position, enemy.transform.position, Color.red, 1f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a circle in the editor to visualize the attack range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
