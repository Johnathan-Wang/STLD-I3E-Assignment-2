/*
 * Author: Wang Johnathan Zhiwen
 * Date: 30/06/2024
 * Description: 
 * Go to end after core placed
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeShuttle : MonoBehaviour
{
    // Reference to the area where the 'Core' item needs to be placed
    public Collider corePlacementArea;

    // Reference to the shuttle GameObject
    public GameObject shuttle;

    public SceneChanger sceneChanger;

    private bool corePlaced = false;

    private void OnTriggerEnter(Collider Core)
    {
        Debug.Log("Test");

        // Check if the collider that entered is the Core
        if (Core)
        {
            Debug.Log("Core placed.");

            // Check if the core is placed
            if (Core.bounds.Intersects(corePlacementArea.bounds))
            {
                corePlaced = true;
                Debug.Log("Core placed correctly.");
                StartShuttle();
            }
            else
            {
                Debug.Log("Core placed in the wrong area.");
            }
        }
    }

    private void StartShuttle()
    {
        if (sceneChanger != null)
        {
            sceneChanger.ChangeScene();
        }
        else
        {
            Debug.LogError("SceneChanger script reference not set.");
        }
    }
}
