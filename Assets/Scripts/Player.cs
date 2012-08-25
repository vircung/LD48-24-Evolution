using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    // Public fields

    // Priate fields

    public float moveSpeed = 5.0f;
    float startMoveSpeed = 1.0f;
    float maxMoveSpeed = 20.0f;
    float speedUpFactor = 0.001f;
    bool playerMoves = false;

    float deltaTime;

    // Methods

    void Update()
    {

        deltaTime = Time.deltaTime;

        MovePlayer();
    }

    private void MovePlayer()
    {
        playerMoves = false;
        float dx = 0.0f;
        float dy = 0.0f;

        if (Input.GetKey(KeyCode.W))
        {
            dy = 1.0f * moveSpeed * Time.deltaTime;
            playerMoves = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dy = -1.0f * moveSpeed * Time.deltaTime;
            playerMoves = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            dx = -1.0f * moveSpeed * Time.deltaTime;
            playerMoves = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dx = 1.0f * moveSpeed * Time.deltaTime;
            playerMoves = true;
        }

        if (playerMoves)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, maxMoveSpeed, speedUpFactor);
        }
        else
        {
            moveSpeed = startMoveSpeed;
        }

        transform.Translate(dx, dy, 0.0f);
    }
}
