using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maximumHealth = 100;
    private int _currentHealth;

    private Animation _animation;
    public GameObject enemy;
    void Start()
    {
        _animation = GetComponentInChildren<Animation>();
        _currentHealth = _maximumHealth;
    }

    public void Damage(int damageValue)
    {
        _currentHealth -= damageValue;

        if (_currentHealth <= 0)
        {
            _animation.Stop("Move1");
            _animation.Stop("Move2");
            _animation.Stop("Move3");
            enemy.GetComponent<EnemyMovement>()._moveSpeed = 0f;
            _animation.Play("Die");
            

        }
    }


}
