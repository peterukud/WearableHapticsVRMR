using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FreeFlyCameraStylus : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Camera rotation by stylus movement is active")]
    private bool _enableRotation = true;

    [SerializeField]
    private HapticPlugin hapticDevice;

    [SerializeField]
    private HapticAttachToCamera CameraAttachment;

    [SerializeField]
    [Tooltip("Sensitivity of stylus rotation")]
    private float _rotSense = 1.8f;

    [SerializeField]
    private int buttonToReactTo, buttonToNOTReactTo;

    private Vector3 stylusStartPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int darkButton = hapticDevice.Buttons[buttonToNOTReactTo];
        int lightButton = hapticDevice.Buttons[buttonToReactTo];

        // Rotation
        if (darkButton == 0 && lightButton == 1 && _enableRotation)
        {
            //Disable translate to move while turning
            CameraAttachment.smoothFollow = false;

            // Pitch
            transform.rotation *= Quaternion.AngleAxis(
                -(hapticDevice.stylusPositionRaw.y - stylusStartPos.y) / 100 * _rotSense,
                Vector3.right
            );

            // Paw
            transform.rotation = Quaternion.Euler(
                transform.eulerAngles.x,
                transform.eulerAngles.y + (hapticDevice.stylusPositionRaw.x - stylusStartPos.x) / 100 * _rotSense,
                transform.eulerAngles.z
            );
        }

        if (darkButton == 0 && lightButton == 0)
        {
            stylusStartPos = hapticDevice.stylusPositionRaw;
            CameraAttachment.smoothFollow = true;
        }
    }
}
