using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelChanger : MonoBehaviour
{
    private Animator animator;
    private GameObject mainCamera;

    [SerializeField]
    public UnityEvent onFadeComplete;

    //private int levelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        animator = GameObject.FindGameObjectWithTag("FadeAnimator").GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //FadeToLevel(1);
        if(mainCamera != null)
            this.transform.position = mainCamera.transform.position;
    }

    public void FadeToLevel()
    {
        //levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        onFadeComplete?.Invoke();
    }
}
