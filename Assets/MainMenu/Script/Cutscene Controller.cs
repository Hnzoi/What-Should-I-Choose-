using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{

    public GameObject Transition;
    public GameObject Scene1, Scene2;

    public void Start()
    {
        Transition.SetActive(true);
        StartCoroutine(LoadTransition());
        
    }

    public IEnumerator LoadTransition()
    {
        Scene1.SetActive(false);
        Debug.Log("tunngu");
        yield return new WaitForSeconds(1f);
        Debug.Log("tunngu selesai"); 
        Transition.SetActive(false);
        Scene2.SetActive(true);
    }

}
