using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public Vector3 mouse;
    public Vector3 previousPosition;
    public GameObject currentObject;
    public List<Vector3> trace;
    GameObject ShortCurve;

    public float ScreenHeight, ScreenWidth;
    // Start is called before the first frame update
    void Start()
    {
        ScreenHeight = 2.5f;
        ScreenWidth = Screen.width * 2.5f / Screen.height;
        trace = new List<Vector3>();
        ShortCurve = null;
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            trace.Clear();
            previousPosition = mouse;
            GameObject prefab = Resources.Load("Prefabs/ShortCurve") as GameObject;
            ShortCurve = Instantiate(prefab,Vector3.zero,Quaternion.identity, currentObject.transform) as GameObject;
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
        Debug.Log("AddEdge");
        int size = trace.Count;
        GameObject[] bead = new GameObject[size];
        GameObject[] shortLine = new GameObject[size - 1];
        for (int pos= 0; pos < size; pos++)
		{
            Vector3 vec = trace[pos];
            vec.z = -0.1f;
            GameObject prefab = Resources.Load("Prefabs/Bead") as GameObject;
            bead[pos] = Instantiate<GameObject>(prefab, vec, Quaternion.identity, ShortCurve.transform);
		}
        for (int pos = 0; pos < size-1; pos++)
        {
            GameObject prefab = Resources.Load("Prefabs/ShortLine") as GameObject;
            shortLine[pos] = Instantiate<GameObject>(prefab, Vector3.zero, Quaternion.identity, ShortCurve.transform);
            ShortLine sl = shortLine[pos].GetComponent<ShortLine>();
            sl.bd0 = bead[pos];
            sl.bd1 = bead[pos+1];

            bead[pos].GetComponent<Bead>().SetNorth(bead[pos + 1]);
            bead[pos + 1].GetComponent<Bead>().SetSouth(bead[pos]);
        }
        bead[0].GetComponent<Bead>().SetNode();
        bead[0].GetComponent<Bead>().isEnd = true;
        bead[size - 1].GetComponent<Bead>().SetNode();
        bead[size - 1].GetComponent<Bead>().isEnd = true;
        DetectCrossingAfterAddEdge(ShortCurve);
    }

    public class PairBead
	{
        public Bead first, second;
        public PairBead(Bead a, Bead b)
		{
            first = a;second = b;
		}
 
    }

    void DetectCrossingAfterAddEdge(GameObject ShortCurve)
	{
        List<PairBead> pairs = new List<PairBead>();
        Debug.Log("DetectCrossingAfterAddEdge"); 
        Bead[] SBeads = ShortCurve.GetComponentsInChildren<Bead>();
        Bead[] AllBeads = FindObjectsOfType<Bead>();
        int nLength = SBeads.Length;
        int mLength = AllBeads.Length;
        for(int n=0; n<nLength; n++)
		{
            Bead SLa = SBeads[n];
            GameObject BdaN = SLa.Nnorth;
            GameObject BdaS = SLa.Nsouth;
            if (BdaN != null && BdaS != null)
			{
                for (int m=0; m<mLength; m++)
    			{
                    Bead SLb = AllBeads[m];
                    GameObject BdbN = SLb.Nnorth;
                    GameObject BdbS = SLb.Nsouth;
                    if (BdbN != null && BdbS != null && SLa.gameObject != BdbN && SLa.gameObject != BdbS)
                    {
                        if (Util.IsCrossing(BdaN, BdaS, BdbN, BdbS))
                        {
                            int pairLength = pairs.Count;
                            bool itsNew = true;
                            for(int k=0; k<pairLength; k++)
							{
                                GameObject bdA = pairs[k].first.gameObject;
                                GameObject bdB = pairs[k].second.gameObject;
                                if (bdA== BdaN || bdA== BdaS || bdA == BdbN || bdA == BdbS)
								{
                                    itsNew = false;
								}
                                if (bdB == BdaN || bdB == BdaS || bdB == BdbN || bdB == BdbS)
                                {
                                    itsNew = false;
                                }
                            }
                            if (itsNew)
                            {
                                pairs.Add(new PairBead(SLa, SLb));
                                // Identify SLa.bd0 with SLb.bd0
                                Debug.Log("detect crossing[" + n + "," + m + "]");
                                //newNode.Identify(oldNode);
                            }
                        }
                    }
				}
			}
		}
	}
}
