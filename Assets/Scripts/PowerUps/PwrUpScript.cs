using UnityEngine;
using System.Collections;
using Assets.Scripts.PowerUps;

public class PwrUpScript : MonoBehaviour
{
    public PwrUp pwr;

    void Start()
    {
        pwr = new Exp(gameObject);
    }
}
