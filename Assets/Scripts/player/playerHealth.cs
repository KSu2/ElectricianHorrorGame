using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float maxHealth;
    public float health;

    public Transform player;

    bool isDamaged;
    public LayerMask damageMask;

    public static bool delayOn;
    public float damageDelayTime = 1;

    public updateBars updateHeal;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        delayOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        isDamaged = Physics.CheckSphere(player.position, 1f, damageMask);

        if(health>maxHealth)
        {
            health = maxHealth;
        }

        if(isDamaged && !delayOn)
        {
            health -= 1;
            delayOn = true;
            StartCoroutine(DelayFunc());
        }
        updateHeal.updateHealth(health / maxHealth);
    }

    IEnumerator DelayFunc()
        {
            yield return new WaitForSeconds(damageDelayTime);
            delayOn = false;
        }
}
