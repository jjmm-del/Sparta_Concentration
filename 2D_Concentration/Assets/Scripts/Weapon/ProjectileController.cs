using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ProjectileController : MonoBehaviour,IPoolable
{
    [SerializeField] private LayerMask levelCollisionLayer;
    private RangeWeaponHandler rangeWeaponHandler;

    private float currentDuration;
    private Vector2 direction;
    private bool isReady;
    private Transform pivot;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer spriteRenderer;
    public bool fxOnDestroy = true;

    ProjectileManager projectileManager;

    private Action<GameObject> returnToPool;


    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _rigidbody  = GetComponent<Rigidbody2D>();
        pivot = transform.GetChild(0);
    }
    private void Update()
    {
        if (!isReady) return;

        currentDuration += Time.deltaTime;
        if (currentDuration > rangeWeaponHandler.Duration)
        {
            DestroyProjectile(transform.position, false);
        }

        _rigidbody.velocity = direction * rangeWeaponHandler.Speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (levelCollisionLayer.value == (levelCollisionLayer.value | (1 << collision.gameObject.layer)))
        {
            DestroyProjectile(collision.ClosestPoint(transform.position) - direction * .2f, fxOnDestroy);
        }
        else if (rangeWeaponHandler.target.value == (rangeWeaponHandler.target.value | 1 << collision.gameObject.layer))
        {

            ResourceController resourcecontroller = collision.GetComponent<ResourceController>();
            if (resourcecontroller != null)
            {
                resourcecontroller.ChangeHealth(-rangeWeaponHandler.Power);
                if (rangeWeaponHandler.IsOnKnockback)
                {
                    BaseController controller = collision.GetComponent<BaseController>();
                    if (controller != null)
                    {
                        controller.ApplyKnockback(transform, rangeWeaponHandler.KnockbackPower, rangeWeaponHandler.KnockbackTime);
                    }
                }
            }


            DestroyProjectile(collision.ClosestPoint(transform.position), fxOnDestroy);

        }
    }

    public void Init(Vector2 direction, RangeWeaponHandler WeaponHandler, ProjectileManager projectileManager)
    {
        this.projectileManager = projectileManager;
        rangeWeaponHandler = WeaponHandler;
        this.direction = direction;
        currentDuration = 0;
        transform.localScale = Vector3.one * WeaponHandler.BulletSize;
        spriteRenderer.color = WeaponHandler.ProjectileColor;

        transform.right = this.direction;

        if (direction.x < 0)
            pivot.localRotation = Quaternion.Euler(180, 0, 0);
        else
            pivot.localRotation = Quaternion.Euler(0, 0, 0);

        isReady = true;

        
    }


    private void DestroyProjectile(Vector3 position, bool createFx)
    {

        if (createFx)
        {
            projectileManager.CreateImpactParticlesAtPosition(position, rangeWeaponHandler);
        }


        //Destroy(this.gameObject);
        OnDespawn();
    }

    public void Initialize(Action<GameObject> returnAction)
    {
        returnToPool = returnAction;
    }

    public void OnSpawn()
    {
        
    }

    public void OnDespawn()
    {
        returnToPool?.Invoke(gameObject);
    }

}
