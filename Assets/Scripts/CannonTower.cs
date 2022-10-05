using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : MonoBehaviour
{
    public float turnSpeed = 30f;
    public float shootForce = 200f;
    public Transform projectileSpawnPoint;
    public GameObject cannonBallPrefab;

    private GameObject robot;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("shootAtTarget", 3f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        robot = targetSighted();

        if (!robot)
        {
            return;
        }
        else
        {
            // Rotate the cannon tower towards the robot
            Vector3 targetDirection = robot.transform.position - transform.position;
            Vector3 aimDirection = Vector3.RotateTowards(transform.forward, targetDirection, turnSpeed * Time.deltaTime, 0.0f);

            transform.rotation = Quaternion.LookRotation(targetDirection);
        }
    }

    private void shootAtTarget()
    {
        if (robot)
        {
            GameObject newCannonBall = Instantiate(cannonBallPrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            newCannonBall.GetComponent<Rigidbody>().AddForce(cannonBallPrefab.transform.forward * shootForce);
            // Destroy the cannonball after 2 seconds
            Destroy(newCannonBall, 2f);
        }
    }

    private GameObject targetSighted()
    {
        RobotMovement robot = FindObjectOfType<RobotMovement>();

        if (robot)
        {
            return robot.gameObject;
        }

        return default;
    }
}
