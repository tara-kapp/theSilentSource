using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut_Action : MonoBehaviour
{
    public GameObject cutPrefab;
    public float spacing = 0.1f;
    public Transform parentTransform;

    private List<Vector3> cutPath = new List<Vector3>();
    private Vector3 lastPosition;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cutPath.Clear();
            lastPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lastPosition.z = 0;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0;

            //Raycast to detect if the mouse is over the pig sprite
            RaycastHit2D hit = Physics2D.Raycast(currentPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {                

                if (Vector3.Distance(currentPosition, lastPosition) >= spacing)
                {
                    cutPath.Add(currentPosition);
                    lastPosition = currentPosition;

                    //Instantiate the cut prefab at current position
                    Instantiate(cutPrefab, currentPosition, Quaternion.identity, parentTransform);
                }
            }
        }
        
    }
}
