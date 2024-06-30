/*
 * Author: Wang Johnathan Zhiwen
 * Date: 30/06/2024
 * Description: 
 * The Door will Open after interacted with
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool opened = false;
    bool locked = false;

    Vector3 openedPosition;

    public AudioSource myAudio;

    //When player enter in range for the specific door
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !opened || other.gameObject.tag == "Boulder" && !opened)
            other.gameObject.GetComponent<Player>().UpdateDoor(this);
    }

    //When player exit the range for the specific door
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            other.gameObject.GetComponent<Player>().UpdateDoor(null);
    }

    // What happens when door opens
    public void OpenDoor()
    {
        if (!locked)
        {
            StartCoroutine(SlideDoor(openedPosition));

            opened = true;
            myAudio.Play();
        }
    }

    // Coroutine to smoothly slide the door to the target position
    private IEnumerator SlideDoor(Vector3 targetPosition)
    {
        float duration = 1.0f; // Adjust the duration of the slide
        float elapsedTime = 0.0f;
        Vector3 startingPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; // Ensure exact position at the end
    }

    public void SetLock(bool lockStatus)
    {
        locked = lockStatus;
    }

}
