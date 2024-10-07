using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : Shooter
{
      private TankPawn tankPawn;
      
      private void Awake()
      {
          tankPawn = GetComponent<TankPawn>();
      }
      
      public override void Shoot()
      {
          Bullet newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
          newBullet.InitBullet(tankPawn, firePoint.forward);
      }
}
