using UnityEngine;
using System.Collections;
using Assets.Scripts.ShipParts;
using Assets.Scripts;

public class Player : MonoBehaviour
{

    // Public fields

    // Priate fields

    public Ship ship;
    public Hashtable map;

    GameObject prefab;
    private bool gameover = false;

    // GUI stuff

    #region System Methods

    void Awake()
    {
        ship = new Ship();
        map = new Hashtable();

        foreach (Hull part in ship.parts)
        {
            GameObject go = Instantiate(part.prefab, part.position, Quaternion.identity) as GameObject;

            go.transform.parent = gameObject.transform;
            ship.AddPart(go, part);
            Debug.Log(go.GetInstanceID() + " " + part);
        }
    }
    
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.up, Color.magenta, 1.0f);
        MovePlayer();

        if (Input.GetKeyUp(KeyCode.Space))
        {
            ship.Fire(gameObject.transform.position);
        }

        if (ship.parts.Count <= 0)
        {
            gameover = true;
        }
    }

    void OnGUI()
    {
        if (gameover)
        {
            GUI.Box(new Rect(50, 100, 150, 150), "GAME OVER");
        }
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
        
        ship.Move(this.gameObject, dir);
    }

    #endregion
}
