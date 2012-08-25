using UnityEngine;
using System.Collections;
using Assets.Scripts.Ship;

public class ShipCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Player p = transform.parent.GetComponent<Player>();
            Hull h = p.map[gameObject] as Hull;
            p.ship.DestroyPart(h);
            Destroy(gameObject);
        }
    }
}
