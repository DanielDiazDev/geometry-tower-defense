using System;
using Tower;
using UnityEngine;

namespace Unit
{
    public class AIMovement : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        public float speed;
        private float _distance;
        private float _angle;
        private Vector2 _direction;
        private HealthSystem _healthSystem;

        private void Start()
        {
            _healthSystem = GameObject.FindGameObjectWithTag("Tower").GetComponent<HealthSystem>();
        }

        // Update is called once per frame
        void Update()
        {
            _distance = Vector2.Distance(transform.position, _player.transform.position);
            _direction = _player.transform.position - transform.position;
            _direction.Normalize();
            _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            Move();
            ClosePlayer();
            
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawLine(transform.position, _player.transform.position);
        }
        void Move()
        {
            transform.position = Vector2.MoveTowards(this.transform.position, _player.transform.position,
                speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * _angle);
        }
        void ClosePlayer()
        {
            float distanceToPlayer = (_player.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToPlayer <= 0.12f)
            {
               _healthSystem.TakeDamage(1);
               Destroy(gameObject);
            }
        }
    }
}
