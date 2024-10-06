using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : Pawn
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform firePoint;
    // Start is called before the first frame update

    private float timeSinceLastAttack = 0;
    public override void Start()
    {
        moveSpeed = 0;
    }

    // Update is called once per frame
    public override void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
    }
    
    public override void VerticalInput(float value)
    {
        
    }

    public override void HorizontalInput(float value)
    {
        
    }

    public override void Attack()
    {
        //check if able to attack again
        if (timeSinceLastAttack < attackRate)
        {
            return;
        }
        Bullet newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        timeSinceLastAttack = 0;
        newBullet.InitBullet(this, firePoint.forward);
    }

    public override void cursorInput(Vector3 value)
    {
        transform.LookAt(value);
    }
}
