using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HapticPlugin))]
public class HandinessLoadMR : MonoBehaviour
{
    //public GameObject rightHand, leftHand;

    private bool leftHanded;
    public HapticPlugin hapticPlugin;
    //private bool isInkwellOccupied;
    public Vector3 inkWellDefaultPosition;
    public SkinnedMeshRenderer[] leftControllerMeshRenderers;
    public SkinnedMeshRenderer[] rightControllerMeshRenderers;
    public GameObject leftHandPrefab;
    public GameObject rightHandPrefab;

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
        if (leftHanded)
        {
            if (getInkwellStat())
            {
                for (int i = 0; i < leftControllerMeshRenderers.Length; i++)
                {
                    leftControllerMeshRenderers[i].enabled = false;
                }
                leftHandPrefab.SetActive(false);
            }
            else
            {

                for (int i = 0; i < leftControllerMeshRenderers.Length; i++)
                {
                    leftControllerMeshRenderers[i].enabled = true;
                }
                leftHandPrefab.SetActive(true);

            }
        }
        else
        {
            if (getInkwellStat())
            {
                for (int i = 0; i < rightControllerMeshRenderers.Length; i++)
                {
                    rightControllerMeshRenderers[i].enabled = false;
                }
                rightHandPrefab.SetActive(false);
            }
            else
            {

                for (int i = 0; i < rightControllerMeshRenderers.Length; i++)
                {
                    rightControllerMeshRenderers[i].enabled = true;
                }
                rightHandPrefab.SetActive(true);

            }
        }
    }

    public bool getInkwellStat()
    {
        return hapticPlugin.stylusPositionRaw != inkWellDefaultPosition;
    }
}
