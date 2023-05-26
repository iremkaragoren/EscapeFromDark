using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFall : MonoBehaviour
{
    [SerializeField] GameObject[] obsPrefab;

    [SerializeField] private float secondSpawn = 0.5f;

    [SerializeField] private float minTras;

    [SerializeField] private Transform character;


    [SerializeField] float maxTras;

    void Start()
    {

        StartCoroutine(ObstacleSpawn());

    }


    IEnumerator ObstacleSpawn()
    {

        while (true)
        {
            var wanted = Random.Range(character.transform.position.x+10, character.transform.position.x + 30);
            var position = new Vector3(wanted, transform.position.y);

            GameObject gameObject = Instantiate(obsPrefab[Random.Range(0, obsPrefab.Length)], position, Quaternion.identity);

            yield return new WaitForSeconds(secondSpawn);

            Destroy(gameObject, 3f);
        }

           

    }

}
