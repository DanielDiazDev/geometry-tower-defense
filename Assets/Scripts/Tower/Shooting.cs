using System;
using UnityEngine;

namespace Tower
{
    public class Shooting : MonoBehaviour
    {
        public GameObject bullet;
        public Transform shootpoint;

        public void Shoot()
        {
            GameObject bulletInstance = Instantiate(bullet, shootpoint.position, Quaternion.identity);
            
        }
    }
}