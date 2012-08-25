using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour
{

    public Transform target;
    public Vector3 direction = Vector3.zero;
    float distance = 0.0f;

    float searchTimer = 0.1f;
    bool canSearch = true;

    void Update()
    {
        StartCoroutine(SearchPlayer());

        if (target != null)
        {
            Debug.Log("Got player");
            transform.Translate(direction.normalized * Time.deltaTime, Space.World);
        }
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
            }
        }
    }
}
