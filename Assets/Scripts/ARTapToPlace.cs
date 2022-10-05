using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlace : MonoBehaviour
{
    public GameObject spawnPrefab; // This is the prefab that will instantiate when tapping the screen

    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject spawnedPrefab = null;
    private float roboHeight = 1f;

    private float destroyBelow = -20f;
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {        
        if (spawnedPrefab == null)
        {
            if (Input.touchCount > 0) // Identify the touch(es) to the screen
            {
                Vector2 touchPosition = Input.GetTouch(0).position;

                if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
                {
                    var hitPose = hits[0].pose;

                    spawnedPrefab = Instantiate(spawnPrefab, hitPose.position, hitPose.rotation);
                    roboHeight = spawnedPrefab.transform.position.y;
                }
            }
        }
        else
        {
            roboHeight = spawnedPrefab.transform.position.y;
            if (roboHeight < destroyBelow)
            {
                Destroy(spawnedPrefab);
                spawnedPrefab = null;
            }
        }
        
    }
}
