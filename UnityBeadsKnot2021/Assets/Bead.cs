using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bead : MonoBehaviour
{
    public GameObject Nnorth, Nsouth, Uwest, Ueast;
    public GameObject NnorthNode, NsouthNode, UwestNode, UeastNode;
    public bool isNode, isCrossing, isEnd;
    // Start is called before the first frame update
    void Start()
    {
        isNode = false;
        isCrossing = false;
        isEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CopyBead(Bead b)
	{
        Nnorth = b.Nnorth;
        Nsouth = b.Nsouth;
        Uwest = b.Uwest;
        Ueast = b.Ueast;
        NnorthNode = b.NnorthNode;
        NsouthNode = b.NsouthNode;
        UwestNode = b.UwestNode;
        UeastNode = b.UeastNode;
    }

    public void SetNorth(GameObject bead)
	{
        Nnorth = bead;
    }
 
    public void SetSouth(GameObject bead)
    {
        Nnorth = bead;
    }
}
