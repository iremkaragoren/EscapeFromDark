using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PointCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.tag == "FallPoint")
        {
            EventManager.OnFallTriggered?.Invoke();
        }
    }
   
       
    
    

}