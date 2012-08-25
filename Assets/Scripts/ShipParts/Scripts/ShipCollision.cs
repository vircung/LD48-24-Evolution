using UnityEngine;
using System.Collections;
using Assets.Scripts.ShipParts;

public class ShipCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Player p = transform.parent.GetComponent<Player>();
        Hull h = p.ship.map[this] as Hull;

        if (other.tag == "Enemy")
        {

            Enemy1 es = other.GetComponent<Enemy1>();
            h.TakeDamage(es.enemy.damage);
        }
        else if (other.tag == "PowerUp")
        {

        }
    }
}
