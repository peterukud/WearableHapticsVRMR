using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Microsoft.MixedReality.Toolkit.Input;

public class HapticAttachToCamera : MonoBehaviour
{
    public HapticPlugin hapticDevice;
    public HapticGrabber hapticGrabber;
    public GameObject stylusOffsetRoot;
    public Vector3 stylusOffsetedPosition;

    public float smoothFollowSpeed, updatePositionLimit, alignGazeWithStylusLimit;
    public bool smoothFollow;

    private Vector3 newRotationEuler, velocity;

    // Start is called before the first frame update
    void Start()
    {
        stylusOffsetRoot.transform.localPosition = stylusOffsetedPosition;
        velocity = Vector3.zero;
        UpdatePosition();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hapticDevice.touching == null && hapticGrabber.touching == null)
        {
            if(smoothFollow && hapticDevice.Buttons[1] == 1)
                ForcedAlignGazeWithStylus();

            if(smoothFollow && hapticDevice.Buttons[1] == 0)
                AlignGazeWithStylus();

            if(smoothFollow && hapticDevice.Buttons[0] == 0)
                UpdatePosition();
        }
    }

    void UpdatePosition()
    {
        if(Vector3.Distance(this.gameObject.transform.position, stylusOffsetRoot.transform.position) > updatePositionLimit)
            this.gameObject.transform.position = Vector3.SmoothDamp(this.gameObject.transform.position, stylusOffsetRoot.transform.position, ref velocity, smoothFollowSpeed);
        //this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, stylusOffsetRoot.transform.position, smoothFollowSpeed * Time.deltaTime);
        //this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, stylusOffsetRoot.transform.position, smoothFollowSpeed * Time.deltaTime);
    }

    void AlignGazeWithStylus()
    {
        if(Mathf.Abs(this.gameObject.transform.eulerAngles.y - stylusOffsetRoot.transform.eulerAngles.y) > alignGazeWithStylusLimit)
        {
            newRotationEuler = new Vector3(this.gameObject.transform.eulerAngles.x, stylusOffsetRoot.transform.eulerAngles.y, this.gameObject.transform.eulerAngles.z);
            this.transform.eulerAngles = newRotationEuler;
        }   
    }

    void ForcedAlignGazeWithStylus()
    {
        newRotationEuler = new Vector3(this.gameObject.transform.eulerAngles.x, stylusOffsetRoot.transform.eulerAngles.y, this.gameObject.transform.eulerAngles.z);
        this.transform.eulerAngles = newRotationEuler;
    }

}
