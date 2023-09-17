using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[RequireComponent(typeof(SpringJoint))]
public class SpringSwap : MonoBehaviour
{
    //public GameObject pivotPoint;
    public float tippingPointInDeg;
    public Rigidbody anchorL, anchorR;

    // Start is called before the first frame update
    void Start()
    {
        tippingPointInDeg = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(TransformUtils.GetInspectorRotation(this.gameObject.transform).z + " " + this.name);
        if (UnityEditor.TransformUtils.GetInspectorRotation(this.gameObject.transform).z > tippingPointInDeg && GameObject.ReferenceEquals(this.gameObject.GetComponent<SpringJoint>().connectedBody.gameObject, anchorR.gameObject))
        {
            //Debug.LogError("TippingPoint Condition reached L");
            this.gameObject.GetComponent<SpringJoint>().connectedBody = anchorL;
        }
        else
        {
            if (UnityEditor.TransformUtils.GetInspectorRotation(this.gameObject.transform).z < tippingPointInDeg && GameObject.ReferenceEquals(this.gameObject.GetComponent<SpringJoint>().connectedBody.gameObject, anchorL.gameObject))
            {
                //Debug.LogError("TippingPoint Condition reached R");
                this.gameObject.GetComponent<SpringJoint>().connectedBody = anchorR;
            }
        }
    }
}
