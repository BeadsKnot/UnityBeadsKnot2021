using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortLine : MonoBehaviour
{
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
        Vector3 vecM = (vec0 + vec1) * 0.5f;
        vecM.z = -0.1f;
        transform.position = vecM;
        float len = (vec1 - vec0).magnitude;
        transform.localScale = new Vector3(len, 0.02f, 1f);
        float th = Mathf.Rad2Deg * Mathf.Atan2(vec1.y - vec0.y, vec1.x - vec0.x);
        Quaternion rotation = Quaternion.Euler(0f, 0f, th);
        transform.rotation = rotation;
    }
}
