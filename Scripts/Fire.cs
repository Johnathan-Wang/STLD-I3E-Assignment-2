/*
 * Author: Wang Johnathan Zhiwen
 * Date: 30/06/2024
 * Description: 
 * Fire damage
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Player playerHealth;
    public int damage = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerHealth.PlayerTakeDamage(damage);
        }
    }
}
