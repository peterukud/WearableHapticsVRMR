using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ContinueAfterLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("AudioTime"))
            this.GetComponent<AudioSource>().time = PlayerPrefs.GetFloat("AudioTime");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
