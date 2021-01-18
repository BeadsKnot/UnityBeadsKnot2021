using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bead : MonoBehaviour
{
    public GameObject Nnorth=null, Nsouth = null, Uwest = null, Ueast = null;
    public GameObject NnorthNode = null, NsouthNode = null, UwestNode = null, UeastNode = null;
    public bool isNode, isCrossing, isEnd;
    public Mesh BeadMesh;
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
        Nsouth = bead;
    }

    public void SetNode()
	{
        MeshFilter MF = GetComponent<MeshFilter>();
        MF.mesh = BeadMesh;
        isNode = true;
    }

    public void UnsetNode()
	{
        MeshFilter MF = GetComponent<MeshFilter>();
        MF.mesh = null;
        isNode = false;
    }

    public void Identify(Bead old)
	{
        if (!isNode && !old.isNode)
        {

            Uwest = old.Nnorth;
            if (old.Nnorth.GetComponent<Bead>().Nnorth == old)
            {
                Uwest.GetComponent<Bead>().Nnorth = gameObject;
            }
            else
            {
                Uwest.GetComponent<Bead>().Nsouth = gameObject;
            }
            Ueast = old.Nsouth;
            if (old.Nsouth.GetComponent<Bead>().Nnorth == old)
            {
                Ueast.GetComponent<Bead>().Nnorth = gameObject;
            }
            else
            {
                Ueast.GetComponent<Bead>().Nsouth = gameObject;
            }
            // omit set direction
            SetNode();
            // Inactivate old bead
            old.gameObject.SetActive(false);
        }

    }
}
