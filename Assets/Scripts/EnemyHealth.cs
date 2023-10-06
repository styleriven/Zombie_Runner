<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] AudioSource audioSource;
    bool isDead = false;
    void Start() {
        audioSource = GetComponentInParent<AudioSource>();
    }
    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if(audioSource.isPlaying) { audioSource.Stop(); }
        if (isDead) return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float HP = 100f;
    bool isDead = false;

    public bool IsDead() {
        return isDead;
    }
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamgeTaken");
        HP-=damage;
        if (HP<=0)
        {
            Die();
        }
    }
    private void Die() {
        if(isDead)
            return;
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
>>>>>>> b2eda06f735e198f54162f5219df2f1b70b6202d
