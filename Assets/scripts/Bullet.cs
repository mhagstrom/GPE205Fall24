using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{

    [SerializeField] private Rigidbody bulletrb;

    [SerializeField] private int damage = 10;
    [SerializeField] private float velocity = 20;
    [SerializeField] private int bulletLifetimeSecs = 10;
    CancellationTokenSource src = new CancellationTokenSource();
    [SerializeField] private GameObject bulletVFX;
    private Pawn player;
    //later i want to use scriptable objects to have different kinds of bullets i.e. High Explosive, Armor Piercing, etc.
    public void InitBullet(Pawn firingplayer, Vector3 direction)
    {
        player = firingplayer;
        bulletrb.velocity = direction * velocity;
        DestroyStrayBullet();
    }
    
    //upon bullet colliding with another object, check if object has health component and if so run ondamagetaken subtracting health equal to damage value of this bullet
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Health health))
        {
            health.OnDamageTaken(damage);
        }
        Instantiate(bulletVFX, transform.position, Quaternion.identity);
        //Quaternion.Identity is no rotation
        src.Cancel();
        Destroy(gameObject);
    }

    //coroutines aren't allowed so I'm using async for this
    #pragma warning disable CS0168 
    //Not using the exception
    //later i can use a queue for valid reference check to avoid null reference exceptions
    private async void DestroyStrayBullet()
    {
        CancellationToken ct = src.Token;
        try
        {
            await Task.Delay(bulletLifetimeSecs * 1000, ct);
        }
        catch (Exception e)
        {
            src.Dispose();
            return;
        }

        if (gameObject != null)
        {
            Destroy(gameObject);
        }
        
    }
    #pragma warning restore CS0168
    
    /*
     Extra math every frame to check if the bullet is still alive is unnecessary when the OS can handle it on another thread
    private float lifetimeTimer = 10;
    public virtual void Update()
    {
        lifetimeTimer -= Time.deltaTime;
        if (lifetimeTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
    */
}
