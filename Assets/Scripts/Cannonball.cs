using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
 
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<RobotMovement>())
        {
            // Lose one life from life counter
            GameManager.Instance.LoseLife();

            Destroy(collision.gameObject);
            Destroy(gameObject); // Destroy self (cannonball)
        }
    }
}
