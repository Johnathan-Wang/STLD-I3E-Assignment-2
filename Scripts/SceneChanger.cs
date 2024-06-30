/*
 * Author: Wang Johnathan Zhiwen
 * Date: 30/06/2024
 * Description: 
 * Changes Scene
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int targetSceneIndex;
    public Animator transition;
    public float transitionTime = 1f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(targetSceneIndex);
        }
    }

    public void ChangeScene()
    {
        Debug.Log("ChangeScene() called.");

        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        Debug.Log("Starting scene transition.");

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(targetSceneIndex);

    }
}
