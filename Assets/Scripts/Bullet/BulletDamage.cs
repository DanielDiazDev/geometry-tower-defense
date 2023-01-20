using System;
using Unit;
using UnityEngine;

namespace Bullet
{
    public class BulletDamage : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Unit"))
            {
                col.gameObject.GetComponent<HealthUnit>().TakeDamage(1);
                Destroy(gameObject);
            }
        }
    }
}