using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public GameObject NextScene;
    public GameObject ThisScene;
    public float DelayTime = 40f;
    // Start is called before the first frame update
    void Start()
    {
        NextScene.SetActive(false);
        if (ThisScene = transform.Find("Scene2")) ;
        StartCoroutine(NextSceneTime());
    }

    private IEnumerator NextSceneTime()
    {
        Debug.Log("start");
        yield return new WaitForSeconds(DelayTime);
        Debug.Log("stop");
        NextScene.SetActive(true);
        ThisScene.SetActive(false);

    }
}
