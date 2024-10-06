using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : TankComponent
{
      [SerializeField] private Bullet bulletPrefab;
      [SerializeField] private Transform firePoint;
   
      public void Shoot()
      {
          Bullet newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            newBullet.InitBullet(tankPawn, firePoint.forward);
            //TankComponent allows TankPawn to be stored by bullet
      }
}
