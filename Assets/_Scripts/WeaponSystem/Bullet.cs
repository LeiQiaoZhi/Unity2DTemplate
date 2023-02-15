using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public BulletProperties bulletProperties;
    public LayerMask layersToDestroy;
    public LayerMask targetLayers;

    private Rigidbody2D _rb;

    // Start is called before the first frame update

    public void Init(Vector2 direction)
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = direction.normalized * bulletProperties.speed;
        Destroy(gameObject, bulletProperties.lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (LayerMaskHelper.IsLayerInLayerMask(col.gameObject.layer, targetLayers))
        {
            OnTargetHit();
        }
        if (LayerMaskHelper.IsLayerInLayerMask(col.gameObject.layer, layersToDestroy))
        {
            Destroy(gameObject);
        }
    }

    private void OnTargetHit()
    {
        XLogger.Log(Category.Weapon,"Bullet hit target");
    }
}