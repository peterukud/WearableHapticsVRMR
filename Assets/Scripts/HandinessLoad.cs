using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HapticPlugin))]
public class HandinessLoad : MonoBehaviour
{
    //public GameObject rightHand, leftHand;

    private bool leftHanded;
    public HapticPlugin hapticPlugin;
    //private bool isInkwellOccupied;
    public Vector3 inkWellDefaultPosition;
    public GameObject[] foundLeftHandObjects;
    public GameObject[] foundRightHandObjetcs;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("LeftHanded"))
        {
            if (PlayerPrefs.GetInt("LeftHanded") == 1)
            {
                leftHanded = true;
                Debug.Log("LeftHanded Loaded");
            }
            else
            {
                leftHanded = false;
                Debug.Log("RightHanded Loaded");
            }
        }
        //hapticPlugin = this.GetComponent<HapticPlugin>();
    }

    // Update is called once per frame
    void Update()
    {
        if(getInkwellStat())
        {
            if (leftHanded)
            {
                foundLeftHandObjects = GameObject.FindGameObjectsWithTag("LeftHandObject");
                for (int i = 0; i < foundLeftHandObjects.Length; i++)
                {
                    foundLeftHandObjects[i].SetActive(false);
                }
            }
            else
            {
                foundRightHandObjetcs = GameObject.FindGameObjectsWithTag("RightHandObject");
                for (int i = 0; i < foundRightHandObjetcs.Length; i++)
                {
                    foundRightHandObjetcs[i].SetActive(false);
                }
            }
        }
    }

    public bool getInkwellStat()
    {
        return hapticPlugin.stylusPositionRaw != inkWellDefaultPosition;
    }
}
