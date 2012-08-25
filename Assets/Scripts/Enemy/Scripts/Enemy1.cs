using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class Enemy1 : MonoBehaviour
{
    public Enemy enemy;

    Transform target;
    Vector3 direction = Vector3.zero;
    float distance = 0.0f;

    float searchTimer = 0.1f;
    bool canSearch = true;

    void Awake()
    {
        enemy = new Enemy();
    }

    void Update()
    {
        StartCoroutine(SearchPlayer());

        if (target != null)
        {
            transform.Translate(direction.normalized * Time.deltaTime, Space.World);
        }
    }

    void OnDestroy()
    {

    }

    public IEnumerator SearchPlayer()
    {
        canSearch = false;

        Search();

        yield return new WaitForSeconds(searchTimer);
        canSearch = true;
    }

    private void Search()
    {
        target = null;
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject trg in targets)
        {
            float dist = Vector3.Distance(transform.position, trg.transform.position);

            if (target == null || dist < distance)
            {
                distance = dist;
                target = trg.transform;
                direction = target.position - transform.position;
                transform.up = direction;
            }
        }
    }
}
