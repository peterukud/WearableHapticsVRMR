using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualButtonPress : MonoBehaviour
{

    public HapticPlugin hapticDevice;

    public int buttonToReactTo;

    public Material material;

    private Material originalMaterial, currentMaterial;

    // Start is called before the first frame update
    void Start()
    {
        originalMaterial = this.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        currentMaterial = this.GetComponent<MeshRenderer>().material;
        if (currentMaterial != material && hapticDevice.Buttons[buttonToReactTo] == 1)
        {
            Debug.Log("Button " + buttonToReactTo + " pressed");
            this.GetComponent<MeshRenderer>().sharedMaterial = material;
        }
        if(currentMaterial != originalMaterial && hapticDevice.Buttons[buttonToReactTo] == 0)
        {
            this.GetComponent<MeshRenderer>().sharedMaterial = originalMaterial;
        }
    }
}
