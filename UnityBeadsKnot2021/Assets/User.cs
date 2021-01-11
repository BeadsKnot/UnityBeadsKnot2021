using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public Vector3 mouse;
    public Vector3 previousPosition;

    public List<Vector3> trace;
    // Start is called before the first frame update
    void Start()
    {
        // Screen_size = (Screen.width, Screen.height);
        trace = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            trace.Clear();
            previousPosition = mouse;
        }
        else if (Input.GetMouseButton(0))
		{
			if ((previousPosition - mouse).magnitude >= 10)
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

    void AddEdge(List<Vector3> t)
	{

	}
}
