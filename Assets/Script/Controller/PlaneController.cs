using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlaneController : MonoBehaviour
{
    
    private bool isFalling = false;
    private Rigidbody2D rb;


    private void OnEnable()
    {
        EventManager.OnFallTriggered += FallPlane;
    } 
    private void OnDisable()
    {
        EventManager.OnFallTriggered -= FallPlane;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FallPlane()
    {

        
        rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        StartCoroutine(WaitForMove());


    }

    private IEnumerator WaitForMove() {
        yield return new WaitForSeconds(1f);
        EventManager.MovedPlaneTriggered?.Invoke();

    }




}