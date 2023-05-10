using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maximumHealth = 100;
    private int _currentHealth;

    void Start()
    {
        _currentHealth = _maximumHealth;
    }

    public void Damage(int damageValue)
    {
        _currentHealth -= damageValue;

        if (_currentHealth <= 0)
        {
            if (tag == "Player")
            {
                Animator a = GetComponentInChildren<Animator>();
                Destroy(a);
            }
            else
            {
                Animation a = GetComponentInChildren<Animation>();
                a.Stop();
            }
            Destroy(GetComponent<PlayerMovement>());
            Destroy(GetComponent<PlayerAnimation>());
            Destroy(GetComponent<EnemyMovement>());
            Destroy(GetComponent<CharacterController>());
            Ragdoll r = GetComponent<Ragdoll>();
            if (r!=null)
            {
                r.OnDeath();
            }


        }
    }


}
