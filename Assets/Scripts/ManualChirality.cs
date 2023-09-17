using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManualChirality : MonoBehaviour
{
    public bool LeftHanded;

    // Start is called before the first frame update
    void Awake()
    {
        if(LeftHanded)
            PlayerPrefs.SetInt("LeftHanded", 1);
        else
            PlayerPrefs.SetInt("LeftHanded", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
