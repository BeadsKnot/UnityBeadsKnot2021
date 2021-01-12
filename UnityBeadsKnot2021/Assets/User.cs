using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public Vector3 mouse;
    public Vector3 previousPosition;

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

    void AddEdge(List<Vector3> t)
	{

	}
}
