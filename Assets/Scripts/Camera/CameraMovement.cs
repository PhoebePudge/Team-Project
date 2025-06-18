using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject[] targets;
    // Update is called once per frame
    void Update()
    {
        targets = GameObject.FindGameObjectsWithTag("Player");

        float desiredWidth = maxX() - minX();
        float desiredHeight = maxY() - minY();

        #region orthographic camera size

        int currentWidth = Screen.width;
        int currentHeight = Screen.height;

        float targetSize;
        if (desiredWidth > desiredHeight)
        {
            targetSize = ((desiredWidth / currentWidth) * currentHeight) / 2.0f;
        }
        else
        {
            targetSize = ((desiredHeight / currentHeight) * currentWidth) / 2.0f;
        }

        targetSize += 1.0f;

        Camera cam = gameObject.GetComponent<Camera>();
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, Time.deltaTime);

        #endregion

        var position = cam.transform.position;

        position.x = maxX() * 0.5f + minX() * 0.5f;
        position.y = maxY() * 0.5f + minY() * 0.5f;

        cam.transform.position = position;
    }
    private float minX()
    {
        float minX = targets[0].transform.position.x;
        for (int index = 0; index < targets.Length; index++)
        {
            if (targets[index].transform.position.x < minX)
            {
                minX = targets[index].transform.position.x;
            }
        }
        return minX;
    }
    private float minY()
    {
        float minY = targets[0].transform.position.y;
        for (int index = 0; index < targets.Length; index++)
        {
            if (targets[index].transform.position.y < minY)
            {
                minY = targets[index].transform.position.y;
            }
        }
        return minY;
    }
    private float maxX()
    {
        float maxX = targets[0].transform.position.x;
        for (int index = 0; index < targets.Length; index++)
        {
            if (targets[index].transform.position.x > maxX)
            {
                maxX = targets[index].transform.position.x;
            }
        }
        return maxX;
    }
    private float maxY()
    {
        float maxY = targets[0].transform.position.y;
        for (int index = 0; index < targets.Length; index++)
        {
            if (targets[index].transform.position.y > maxY)
            {
                maxY = targets[index].transform.position.y;
            }
        }
        return maxY;
    }
}
