using UnityEngine;

public class SysDefBullet : MonoBehaviour
{
    public float speed = 20f; // Kecepatan peluru
    public int damage = 10; // Damage yang diberikan peluru pada musuh

    private Transform target;

    public void SetTarget(Transform enemyTransform)
    {
        target = enemyTransform;
    }

    void Update()
    {
        // if (target == null)
        // {
        //     Destroy(gameObject);
        //     return;
        // }

        // Dapatkan arah dari peluru ke musuh dan gerakkan peluru
        Vector2 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            // Jika peluru sudah mencapai musuh, lakukan damage dan hancurkan peluru
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        // Lakukan damage pada musuh dan hancurkan peluru
        EnemyController enemy = target.GetComponent<EnemyController>();
        if (enemy != null)
        {
            //enemy.TakeDamage(damage);
            Debug.Log("Mampus");
        }

        //Destroy(gameObject);
    }
}