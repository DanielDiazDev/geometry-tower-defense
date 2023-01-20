using System;
using Tower;
using UnityEngine;

namespace Bullet
{
    public class Bullet : MonoBehaviour
    {
        public float force;
        public float speed;
        private Rigidbody2D _rigidbody;
        private EnemyDetector _enemyDetector;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _enemyDetector = GameObject.FindGameObjectWithTag("Tower").GetComponent<EnemyDetector>();
        }

        private void Update()
        {
            Destroy(gameObject, 2.5f);
            _rigidbody.AddForce(_enemyDetector.Direction * (force * speed));
        }
    }
}