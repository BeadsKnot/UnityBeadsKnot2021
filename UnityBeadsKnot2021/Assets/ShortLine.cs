using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortLine : MonoBehaviour
{
    public GameObject bd0, bd1;
    public Vector3 vec0, vec1;
    // Start is called before the first frame update
    void Start()
    {
        vec0 = Vector3.left;
        vec1 = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        vec0 = bd0.transform.position;
        vec1 = bd1.transform.position;
        Vector3 vecM = (vec0 + vec1) * 0.5f;
        vecM.z = -0.1f;
        transform.position = vecM;
        transform.localScale = new Vector3((vec1 - vec0).magnitude, 0.02f, 1f);
        transform.rotation = Quaternion.Euler(0f, 0f, 
            Mathf.Rad2Deg * Mathf.Atan2(vec1.y - vec0.y, vec1.x - vec0.x));
    }

    public bool IsCrossing(ShortLine sh)
	{
        if (bd0 == sh.bd0 || bd0 == sh.bd1 || bd1 == sh.bd0 || bd1 == sh.bd1)
        {
            return false;
		}
        Vector3 vec2 = sh.vec0;
        Vector3 vec3 = sh.vec1;
        float sNum = Util.Area(vec2 - vec0, vec3 - vec2);
        float sDen = Util.Area(vec1 - vec0, vec3 - vec2);
        float tNum = Util.Area(vec1 - vec0, vec2 - vec0);
        //float tDen = Util.Area(vec1 - vec0, vec3 - vec2);
        if (sDen != 0f) {
            float s = sNum / sDen;
            float t = tNum / sDen;
            if (0f <= s && s <= 1f && 0f <= t && t <= 1f)
            {
                return true;
            }
        }
        return false;
	}
}
