using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ShootType",fileName ="Shoot")]
public class BaseShoot : ScriptableObject
{
    [SerializeField] private Bullet bullet;

    [SerializeField] private int bulletsToFire;

    //[SerializeField] private Transform[] firePoints;

    //public Transform[] FirePoints { get; set; }

    public int BulletDamage { get; set; }
    public virtual void Fire(Transform[] firePoints)
    {
        if (bulletsToFire >= firePoints.Length)
            bulletsToFire = firePoints.Length;

        for(int i = 0; i < bulletsToFire; i++)
        {
            Instantiate(bullet, firePoints[i].position, Quaternion.identity).Damage = BulletDamage;
        }

        //foreach(Transform firePoint in firePoints)
        //{
        //    Instantiate(bullet, firePoint.position, Quaternion.identity).Damage = BulletDamage;
        //}
    }
}
