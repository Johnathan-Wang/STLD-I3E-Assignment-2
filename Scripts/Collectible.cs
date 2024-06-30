/*
 * Author: Wang Johnathan Zhiwen
 * Date: 19/05/2024
 * Description: 
 * The Collectible will destroy itself after being collided with.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Collectible : MonoBehaviour
{
    // worth of a collectible
    public int myScore = 1;

    // What happens when collected
    public void Collected()
    {
        GameManager.instance.IncreaseScore(myScore);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if 'Player'
        if (collision.gameObject.tag == "Player")
        {
            // Update player that this is the current collectible.
            collision.gameObject.GetComponent<Player>().UpdateCollectible(this);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if 'Player'
        if (collision.gameObject.tag == "Player")
        {
            // Update the player that there is no current collectible.
            collision.gameObject.GetComponent<Player>().UpdateCollectible(null);
        }
    }



}
