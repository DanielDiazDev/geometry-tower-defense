using Interfaces;
using UnityEngine;

namespace Unit
{
    public class HealthUnit : MonoBehaviour, IDamageable<float>
    {
        [SerializeField] private float _currentHealth;

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                Debug.Log("Murio unit");
                Destroy(gameObject);
            }
        }
    }
}