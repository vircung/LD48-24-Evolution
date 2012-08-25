using UnityEngine;
using System.Collections;
using Assets.Scripts.Amunition;

public class ProjectileScript : MonoBehaviour
{
    Projectile projectile;


    void Awake()
    {
        projectile = new Projectile();
    }
    void Start()
    {
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

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

    public int speed { get; set; }

    public Vector3 direction { get; set; }
}
