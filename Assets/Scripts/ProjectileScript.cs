using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour
{
    private Vector3 direction;
    private float speed;

    void Start()
    {
        Debug.Log(transform.position);
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
        Debug.Log("Trigger !!");
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
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
