using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneRev : MonoBehaviour
{

    public GameObject TransitionRev;
    public GameObject Scene1, Scene2;

    public void Start()
    {
        TransitionRev.SetActive(true);
        StartCoroutine(LoadRevTransition());

    }

    public IEnumerator LoadRevTransition()
    {
        Scene2.SetActive(false);
        Debug.Log("tunngu");
        yield return new WaitForSeconds(1f);
        Debug.Log("tunngu selesai");
        TransitionRev.SetActive(false);
        Scene1.SetActive(true);
    }
}
