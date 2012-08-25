using UnityEngine;
using System.Collections;
using Assets.Scripts.Ship;

public class Player : MonoBehaviour
{

    // Public fields

    // Priate fields

    Ship ship;
    GameObject prefab;

    // GUI stuff

    #region System Methods

    void Awake()
    {
        ship = new Ship();
    }

    void Start()
    {
        foreach (Hull part in ship.parts)
        {
            GameObject go = Instantiate(ship.prefab, part.position, Quaternion.identity) as GameObject;

            go.transform.parent = gameObject.transform;
        }
    }

    void Update()
    {
        MovePlayer();
    }

    #endregion

    #region My Methods

    private void MovePlayer()
    {
        Vector3 dir = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            dir += new Vector3(0.0f, 1.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir += new Vector3(0.0f, -1.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            dir += new Vector3(-1.0f, 0.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir += new Vector3(1.0f, 0.0f, 0.0f);
        }

        Debug.Log(dir);

        ship.Move(this.gameObject, dir);
    }

    #endregion
}
