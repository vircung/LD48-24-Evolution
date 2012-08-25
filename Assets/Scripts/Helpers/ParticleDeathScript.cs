using UnityEngine;
using System.Collections;

public class ParticleDeathScript : MonoBehaviour
{

    void Update()
    {
        if (!particleSystem.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
