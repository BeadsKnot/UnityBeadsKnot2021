using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bead : MonoBehaviour
{
    GameObject Nnorth, Nsouth, Uwest, Ueast;
    GameObject NnorthNode, NsouthNode, UwestNode, UeastNode;
    bool isNode, isCrossing, isEnd;
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
}
