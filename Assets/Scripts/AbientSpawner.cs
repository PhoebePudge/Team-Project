using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbientSpawner : MonoBehaviour
{
    [SerializeField] int spawnWidth;
    [SerializeField] int spawnHeight;
    [SerializeField] int noOfFireflys;
    [SerializeField] Vector3 offset = new Vector3(-25,-10,0);
    // Start is called before the first frame update
    void Start()
    {
        for (int index = 0; index < noOfFireflys; index++) {
            GameObject g = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            g.transform.position = offset + new Vector3(Random.Range(0, spawnWidth), Random.Range(0, spawnHeight), -1);
            g.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
            g.AddComponent<Light>().type = LightType.Point;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
