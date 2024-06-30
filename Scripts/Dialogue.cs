/*
 * Author: Wang Johnathan Zhiwen
 * Date: 30/06/2024
 * Description: 
 * show text at certain areas
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogue;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(TimedDialogue());
    }

    private IEnumerator TimedDialogue()
    {
        dialogue.SetActive(true);
        yield return new WaitForSeconds(3);
        dialogue.SetActive(false);
        Debug.Log("It works");
        Destroy(gameObject);
    }
}
