using System;
using Interfaces;
using UnityEngine;

namespace Tower
{
    public class HealthSystem : MonoBehaviour, IHealeable<int>, IDamageable<int>
    {
        [SerializeField] private int _currentHealth;
        [SerializeField] private int _maxHealth;

        public int CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }

        public int MaxHealth
        {
            get => _maxHealth;
            set => _maxHealth = value;
        }

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        public void Heal(int heal)
        {
            if (_currentHealth < _maxHealth)
            {
                _currentHealth += heal;
            }
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
        }
    }
}