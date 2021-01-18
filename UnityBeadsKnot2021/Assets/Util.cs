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

    static public bool IsCrossing(GameObject vec0, GameObject vec1, GameObject vec2, GameObject vec3)
    {
        if(vec0==vec2 || vec0 == vec3 || vec1 == vec2 || vec1 == vec3)
		{
            return false;
		}
        Vector3 vec20 = vec2.transform.position - vec0.transform.position;
        Vector3 vec23 = vec2.transform.position - vec3.transform.position;
        Vector3 vec10 = vec1.transform.position - vec0.transform.position;
        float sNum = Util.Area(vec20, vec23);
        float sDen = Util.Area(vec10, vec23);
        float tNum = Util.Area(vec10, vec20);
        //float tDen = Util.Area(vec1 - vec0, vec3 - vec2);
        if (sDen != 0f)
        {
            float s = sNum / sDen;
            float t = tNum / sDen;
            if (0f <= s && s < 1f && 0f <= t && t < 1f)
            {
                return true;
            }
        }
        return false;
    }


}
