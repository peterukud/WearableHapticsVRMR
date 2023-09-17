using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class HandinessSave : MonoBehaviour
{
    //public GameObject rightHand, leftHand;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("LeftHanded", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RightHanded")
        {
            PlayerPrefs.SetInt("LeftHanded", 0);
            //if (leftHand.activeInHierarchy)
            //{
              //  leftHand.SetActive(false);
              //  rightHand.SetActive(true);
            //}

        }
        else
        {
            if (collision.gameObject.tag == "LeftHanded")
            {
                PlayerPrefs.SetInt("LeftHanded", 1);
               // if (rightHand.activeInHierarchy)
               //{
                 //  rightHand.SetActive(false);
                 //  leftHand.SetActive(true);
                //}
            }
                
        }
        //Debug.Log(PlayerPrefs.GetInt("LeftHanded"));
    }
}
