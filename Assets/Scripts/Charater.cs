using UnityEngine;

public class Charater : MonoBehaviour
{
    private int _maxHealth;
    private int _currentHealth;
    private const int _attackDamage = 1;

    private bool _isDead;

    protected Animator _animator;
    protected Rigidbody2D _body2D;

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
        _body2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Die()
    {
        if(_isDead)
        {
            //gameOver;
        }
    }

    public virtual void TakeDamage(int damage)
    {
        if (_isDead == false) return;

        _currentHealth -= damage;
        Debug.Log("Take damage");

        if (_currentHealth <= 0)
        {
            _isDead = true;
            Die();
        }
    }
}
