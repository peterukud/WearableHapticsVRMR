using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class PlayOnCollision : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        audio = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Grabber")
            audio.PlayOneShot(audioClip);
    }
}
