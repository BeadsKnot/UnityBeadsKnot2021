using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public float Area(Vector3 v0, Vector3 v1)
	{
        return v0.x * v1.y - v0.y * v1.x;
	}
}
