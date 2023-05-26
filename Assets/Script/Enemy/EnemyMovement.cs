using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    bool isMoveStart;


    private void Start()
    {
        StartCoroutine(StartMovement());
    }
    void Update()
    {
        if (!isMoveStart)
            return;
        transform.Translate(Vector2.right * speed * Time.deltaTime);




    }
    IEnumerator StartMovement()
    {
        yield return new WaitForSeconds(2f);
        isMoveStart = true;
    }
}
