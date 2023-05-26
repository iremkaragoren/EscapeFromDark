using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ParticalEffect : MonoBehaviour
{
    [SerializeField] GameObject particalGamebject;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
      
        if (collision.gameObject.tag == "Plane")
        {
            particalGamebject.SetActive(true); 
        }
    }
}
