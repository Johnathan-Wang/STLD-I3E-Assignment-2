/*
 * Author: Wang Johnathan Zhiwen
 * Date: 30/06/2024
 * Description: 
 * What the Ui does
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIinteractions : MonoBehaviour
{
    public void ClickFunction()
    {
        Debug.Log("works");
    }

    public void SliderChange(float sliderValue)
    {
        Debug.Log(sliderValue);
    }

    public void ToggleChange(bool toggleValue)
    {
        Debug.Log(toggleValue);
    }
}
