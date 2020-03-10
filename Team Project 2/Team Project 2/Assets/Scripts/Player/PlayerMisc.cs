using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMisc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region character class
    private string characterClass = "Knight";
    public string ReturnClass()
    {
        return characterClass;
    }
    #endregion
    #region Spawn Position
    private readonly Vector3[] spawnPositions = new Vector3[6]
    {
        new Vector3(-7.5f,1.5f,0),
        new Vector3(6.5f,0.5f,0),
        new Vector3(-2.5f,3.5f,0),
        new Vector3(4.5f,-0.5f,0),
        new Vector3(0.5f,-3.5f,0),
        new Vector3(-6.5f,-3.5f,0),
    };
    private void SpawnPosition()
    {
        bool positionFound = false;
        while (!positionFound)
        {
            gameObject.transform.position = spawnPositions[Random.Range(0, spawnPositions.Length - 1)];
            positionFound = true;
        }
    }
    private void OnDrawGizmos()
    {
        for (int index = 0; index < spawnPositions.Length; index++)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(spawnPositions[index], 0.5f);
        }
    }
    #endregion
}
