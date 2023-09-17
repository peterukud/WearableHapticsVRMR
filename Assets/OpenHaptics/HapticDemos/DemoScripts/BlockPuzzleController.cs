using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPuzzleController : MonoBehaviour {

	public GameObject[] ToyBlocks = {null, null, null, null};
	private Vector3[] ToyPosition;
	private Quaternion[] ToyRotation;


	// Remember the original positions of the blocks.
	void Start () 
	{
		ToyPosition = new Vector3[ToyBlocks.Length];
		ToyRotation = new Quaternion[ToyBlocks.Length];
		for (int ii = 0; ii < ToyBlocks.Length; ii++)
		{
			ToyPosition [ii] = ToyBlocks [ii].transform.position;
			ToyRotation [ii] = ToyBlocks [ii].transform.rotation;
		}
	}

	// Return the blocks to their original position.
	public void ResetBlocks()
	{
		if (ToyPosition.Length != ToyBlocks.Length) return;

		for (int ii = 0; ii < ToyBlocks.Length; ii++)
		{
			ToyBlocks [ii].transform.SetPositionAndRotation(ToyPosition[ii], ToyRotation[ii]);
			Rigidbody RB = (Rigidbody)ToyBlocks[ii].GetComponent(typeof(Rigidbody));
			if (RB)	RB.velocity = Vector3.zero;
			if (RB) RB.angularVelocity = Vector3.zero;
		}
	}

	public void PopulateFromChildrenOfZerothElement()
    {
		if(ToyBlocks.Length != 0)
        {
			Transform[] children = ToyBlocks[0].GetComponentsInChildren<Transform>();
			ToyBlocks = new GameObject[children.Length];
			for (int i = 0; i < children.Length; i++)
			{
				ToyBlocks[i] = children[i].gameObject;
			}
		}
    }


	// Update is called once per frame
	void Update () 
	{

	}
}
