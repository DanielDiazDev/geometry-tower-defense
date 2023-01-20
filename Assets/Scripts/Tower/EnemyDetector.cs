using UnityEngine;

namespace Tower
{
    public class EnemyDetector : MonoBehaviour
    {
        public float rangeDistance;
        public float fireRate;
        private Transform _target;
        private Vector3 _closestEnemyRef;
        public Vector2 Direction { get; private set; }
        private bool _detected = false;
        private float _nextTimeToFire = 0;
        private GameObject[] _enemies;
        [SerializeField] private Shooting _shooting;

        private void Start()
        {
            _enemies = GameObject.FindGameObjectsWithTag("Unit");
            InvokeRepeating("UpdateTarget", 0.0f, 0.5f);
        }

        private void Update()
        {
            if (_target != null)
            {
                Direction = _target.transform.position - transform.position;
                RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, rangeDistance);
                if (rayInfo)
                {
                    if (rayInfo.collider.gameObject.CompareTag("Unit"))
                    {
                        if (_detected == false)
                        {
                            _detected = true;
                        }
                    }
                    else
                    {
                        if (_detected == true)
                        {
                            _detected = false;
                        }
                    }
                }
                if (_detected)
                {
                    if (Time.time > _nextTimeToFire)
                    {
                        _nextTimeToFire = Time.time + 1 / fireRate;
                        _shooting.Shoot();
                    }
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            // Draw View Distance
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, rangeDistance);
            // Draw View Draw collision Area
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, .25f);
            // Draw View Draw Enemy distance from player
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, _closestEnemyRef);
        }
        private void UpdateTarget()
        {
            float shortestDistance = Mathf.Infinity;
            GameObject closestEnemy = null;

            foreach (GameObject currentEnemy in _enemies)
            {
                if (currentEnemy != null)
                {
                    float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
                    if (distanceToEnemy < shortestDistance)
                    {
                        shortestDistance = distanceToEnemy;
                        closestEnemy = currentEnemy;
                        _closestEnemyRef = currentEnemy.transform.position;
                    }
                }
                
            }
            // Check that the enemy that is closer to the turret became the main target
            if (closestEnemy != null && shortestDistance <= rangeDistance)
            {
                _target = closestEnemy.transform;
            }
            else
            {
                _target = null;
            }
        }
    }
}
