using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Mammal : MonoBehaviour {
    public GameObject target;
    public Slider healthbar;
    public Text statusText;

    public NavMeshAgent agent;

    public float health;
    public float maxHealth = 100;


	private void Awake () {
        health = maxHealth;
        healthbar.value = health / maxHealth;
    }

    public void TakeDamage (float amount) {
        health -= amount;
        if (health <= 0) {
            Die();
        }
        healthbar.value = health / maxHealth;
    }

    public void Heal (float amount) {
        health += amount;
        healthbar.value = health / maxHealth;
    }

    private void Die () {
        Destroy(this.gameObject);
    }
}
