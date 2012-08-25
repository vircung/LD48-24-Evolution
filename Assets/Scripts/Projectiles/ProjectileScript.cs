using UnityEngine;
using System.Collections;
using Assets.Scripts.Amunition;

public class ProjectileScript : MonoBehaviour
{
    private Vector3 direction;
    private float speed;

    Projectile projectile;

    void Start()
    {
        projectile = new Projectile();
        speed = projectile.speed;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        Vector3 onScreenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (onScreenPosition.x < 0 || onScreenPosition.x > Screen.width || onScreenPosition.y < 0 || onScreenPosition.y > Screen.height)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Enemy1 es = other.GetComponent<Enemy1>();
            es.enemy.TakeDamage(projectile.dmg);
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    public void SetSpeed(float spd)
    {
        speed = spd;
    }
}
