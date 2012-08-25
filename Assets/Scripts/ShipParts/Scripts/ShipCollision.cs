using UnityEngine;
using System.Collections;
using Assets.Scripts.ShipParts;
using Assets.Scripts;

public class ShipCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Hull h = null;
        Ship s = null;

        s = gameObject.transform.parent.GetComponent<Player>().ship;

        if (s != null)
        {
            h = s.map[gameObject] as Hull;
        }

        if (h != null)
            if (other.tag == "Enemy")
            {
                Enemy1 es = other.GetComponent<Enemy1>();
                h.TakeDamage(es.enemy.damage);
                Destroy(other.gameObject);
            }
            else if (other.tag == "PowerUp")
            {
                Debug.Log("POwerUp");
                PwrUpScript pus = other.GetComponent<PwrUpScript>();
                Debug.Log(pus);
                pus.pwr.Action(h);
            }
    }
}
