using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    
    //once picked up by net, destroy self after 2 seconds
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Net"))
        {
            Destroy(gameObject, 2f);
        }
    }
}
