using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateBars : MonoBehaviour
{ 
    public Slider stamBar;
    public Slider healthBar;

    public void updateStam(float val)
    {
        
        stamBar.value = val * 10;
    }

    public void updateHealth(float val)
    {
        healthBar.value = val*10;
    }
}
