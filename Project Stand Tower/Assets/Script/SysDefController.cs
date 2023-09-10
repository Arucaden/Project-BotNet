using UnityEngine;

public class SysDefController : MonoBehaviour
{
    public float range = 10f; // Jarak tower dapat mendeteksi musuh
    public float fireRate = 1f; // Waktu tembakan (dalam detik)
    public GameObject bulletPrefab; // Prefab dari proyektil
    public Transform firePoint; // Titik tembakan proyektil

    private SysDefBullet sysDefBullet;
    private Transform target;
    private float fireCountdown = 0f;

    void Update()
    {
        UpdateTarget();

        if (target != null)
        {
            RotateToTarget();

            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance && distanceToEnemy <= range)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
                Debug.Log("Found an Enenmy!");
            }
        }

        target = nearestEnemy?.transform;
    }

    void RotateToTarget()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        sysDefBullet.SetTarget(target);
        // Atur proyektil (bullet) dengan mengirimkan informasi target ke dalam skrip "BulletController" (jika diperlukan).
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, range);
    }
}
