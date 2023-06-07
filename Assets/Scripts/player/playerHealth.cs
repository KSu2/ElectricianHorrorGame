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

    bool delayOn;
    public float damageDelayTime;

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

        if(isDamaged && !delayOn)
        {
            health -= 1;
            updateHeal.updateHealth(health/maxHealth);
            delayOn = true;
            StartCoroutine(DelayFunc());
        }
    }

    IEnumerator DelayFunc()
        {
            yield return new WaitForSeconds(damageDelayTime);
            delayOn = false;
        }
}
