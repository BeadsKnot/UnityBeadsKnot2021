using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public Vector3 mouse;
    public Vector3 previousPosition;
    public GameObject currentObject;
    public List<Vector3> trace;

    public float ScreenHeight, ScreenWidth;
    // Start is called before the first frame update
    void Start()
    {
        ScreenHeight = 2.5f;
        ScreenWidth = Screen.width * 2.5f / Screen.height;
        trace = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            trace.Clear();
            previousPosition = mouse;
        }
        else if (Input.GetMouseButton(0))
		{
			if ((previousPosition - mouse).magnitude >= 0.1)
			{
                trace.Add(mouse);
                previousPosition = mouse;
            }
		}
        else if (Input.GetMouseButtonUp(0))
		{
            AddEdge(trace);
		}
    }

    void AddEdge(List<Vector3> trace)
	{
        int size = trace.Count;
        GameObject[] bead = new GameObject[size];
        GameObject[] shortLine = new GameObject[size - 1];
        for (int pos= 0; pos < size; pos++)
		{
            Vector3 vec = trace[pos];
            vec.z = -0.1f;
            GameObject prefab = Resources.Load("Prefabs/Bead") as GameObject;
            bead[pos] = Instantiate<GameObject>(prefab, vec, Quaternion.identity, currentObject.transform);
		}
        for (int pos = 0; pos < size-1; pos++)
        {
            GameObject prefab = Resources.Load("Prefabs/ShortLine") as GameObject;
            shortLine[pos] = Instantiate<GameObject>(prefab, Vector3.zero, Quaternion.identity, currentObject.transform);
            ShortLine sl = shortLine[pos].GetComponent<ShortLine>();
            sl.bd0 = bead[pos];
            sl.bd1 = bead[pos+1];
        }
    }
}
