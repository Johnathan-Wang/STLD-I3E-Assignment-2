/*
 * Author: Wang Johnathan Zhiwen
 * Date: 30/06/2024
 * Description: 
 * This is the player character
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject coolTextbox;
    public GameOver gameOver;
    AudioManager audioManager;




    // Health
    public float health;
    public float maxHealth;
    public Image healthBar;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        maxHealth = health;
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }

    public void PlayerTakeDamage(int amount)
    {
        audioManager.PlaySFX(audioManager.takeDamage);
        health -= amount;
        if (health <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }

    //current door
    Door currentDoor;

    //current collectible
    Collectible currentCollectible;


    public void UpdateDoor(Door newDoor)
    {
        currentDoor = newDoor;
    }

    public void UpdateCollectible(Collectible newCollectible)
    {
        currentCollectible = newCollectible;
    }


    //When player interact
    public void OnInteract()
    {
        // with Door
        if (currentDoor != null)
        {
            currentDoor.OpenDoor();
            currentDoor = null;
        }

        // with collectible
        if (currentCollectible != null)
        {
            currentCollectible.Collected();
        }

    }

    //When player Dies
    public void GameOver()
    {
        gameOver.Setup();
    }
}

