using UnityEngine;
using System.Collections;
using Assets.Scripts.ShipParts;

public class ShipCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Hull h = p.ship.map[this] as Hull;

        if (other.tag == "Enemy")
        {
            Player p = transform.parent.GetComponent<Player>();

            Enemy1 es = other.GetComponent<Enemy1>();
            h.TakeDamage(es.enemy.damage);
        }
        else if (other.tag == "PowerUp")
        {

        }
    }
}
