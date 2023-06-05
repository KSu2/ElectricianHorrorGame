using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateBars : MonoBehaviour
{ 
    public GameObject stamBar;
    public GameObject healthBar;

    public void updateStam(int val)
    {
        stamBar.GetComponent<Slider>().value = val;
    }

    public void updateHealth(int val)
    {
        healthBar.GetComponent<Slider>().value = val;
    }
}
