using UnityEngine;

public class Charater : MonoBehaviour
{
    protected int _maxHealth;
    protected int _currentHealth;
    private int _attackDamage = 1;

    protected bool _isDead = false;

    protected Animator _animator;
    protected Rigidbody2D _body2D;

    public int getAttackDamage()
    {
        return _attackDamage;
    }
    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
        _body2D = GetComponent<Rigidbody2D>();
    }

    public virtual void Die()
    {
        _isDead = true;
    }

    public virtual void TakeDamage(int damage)
    {
        if (_isDead == false) return;

        _currentHealth -= damage;
        Debug.Log("Take damage");

        if (_currentHealth <= 0)
        {
            Die();
        }
    }
}
