using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagHands : MonoBehaviour
{
    //public GameObject[] allHandParts;
    public int noOfChildren;
    // Start is called before the first frame update
    void Start()
    {
        //UpdateHandTags();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHandTags();
    }

    public void UpdateHandTags()
    {
        noOfChildren = this.transform.childCount;
        //allHandParts = new GameObject[noOfChildren];
        for (int i = 0; i<noOfChildren; i++)
        {
            //allHandParts[i] = this.transform.GetChild(i).gameObject;
            GameObject child = this.transform.GetChild(i).gameObject;
            if (child.transform.name.Contains("Left"))
                child.tag = "LeftHandObject";
            else
            {
                if (child.transform.name.Contains("Right"))
                    child.tag = "RightHandObject";
            }
        }
    }
}
