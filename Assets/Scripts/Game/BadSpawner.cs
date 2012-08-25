using UnityEngine;
using System.Collections;

public class BadSpawner : MonoBehaviour
{
    private bool enemy1CanSpawn = true;
    private float enemy1SpawnTime = 5.0f;

    private float widthRadius;
    private float heightRadius;

    void Start()
    {
        widthRadius = Camera.main.orthographicSize;
        heightRadius = Camera.main.orthographicSize;
        enemy1 = Resources.Load("Prefabs/Enemy/Enemy1") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy1CanSpawn)
            StartCoroutine(SpawnEnemy1(enemy1SpawnTime));
    }

    public IEnumerator SpawnEnemy1(float timeToSpawn)
    {
        enemy1CanSpawn = false;

        Vector3 pos = new Vector3(Random.Range(-widthRadius, widthRadius), Random.Range(heightRadius, heightRadius), 0.0f);

        Instantiate(enemy1, pos, Quaternion.identity);
        yield return new WaitForSeconds(timeToSpawn);
        enemy1CanSpawn = true;
    }

    public GameObject enemy1 { get; protected set; }
}
