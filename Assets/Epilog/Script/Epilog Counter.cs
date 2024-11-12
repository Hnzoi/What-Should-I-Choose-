using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EpilogCounter : MonoBehaviour
{
    public float TimeDelay = 40f;

    public void Start()
    {
        StartCoroutine(StartEpilogTimer());
    }

    public void Timer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator StartEpilogTimer()
    {
        yield return new WaitForSeconds(TimeDelay);
        Timer();
    }
}
