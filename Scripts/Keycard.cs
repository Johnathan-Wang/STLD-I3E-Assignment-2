/*
 * Author: Wang Johnathan Zhiwen
 * Date: 19/05/2024
 * Description: 
 * The Keycard will Be collected and can open the locked door
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour
{
    /// <summary>
    /// Door that this keycard unlocks
    /// </summary>
    public Door linkedDoor;

    // at the start lock door with keycards
    private void Start()
    {
        if(linkedDoor != null)
        {
            linkedDoor.SetLock(true);
        }
    }

    // collect the keycard when player touches it
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            linkedDoor.SetLock(false);
            Destroy(gameObject);
        }
    }
}
