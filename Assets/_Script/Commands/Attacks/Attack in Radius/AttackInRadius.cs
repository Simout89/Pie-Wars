using System.Collections.Generic;
using UnityEngine;

public class AttackInRadius : ICommand
{
    public IEntity _entity { get; set; }

   
    
    public int radius;
    public float coolDown = 0;
    private float lastAttackTime = -Mathf.Infinity;


    public bool passiveState = false;
    public int bulletType;

    public Bullet bulletPrefab;

    public int poolSize = 100;
    private Queue<Bullet> bulletPool = new Queue<Bullet>();

    public AttackInRadius(IEntity entity, int radius, int _bulletType)
    {
        this._entity = entity;

        this.radius = radius;

        this.bulletType = 1;

        this.coolDown = 1;//= (float)this._entity._characteristics.SP;


        this.bulletPrefab = Resources.Load<Bullet>("Prefabs/Bullet/BulletPrefab");

        for (int i = 0; i < poolSize; i++)
        {
            Bullet bullet = GameObject.Instantiate(bulletPrefab);
            bullet.gameObject.SetActive(false); // Сначала пули не активны
            bulletPool.Enqueue(bullet);
        }

    }


    public Bullet GetBullet()
    {
        foreach (Bullet bullet in bulletPool)
        {
            if (!bullet.gameObject.activeSelf)
            {
                bullet.gameObject.SetActive(true);
                return bullet;
            }
        }


        
        // Если не найдено ни одной неактивной, создаём новую (по желанию — можно не делать)
        Bullet newBullet = GameObject.Instantiate(bulletPrefab);
        newBullet.gameObject.SetActive(true);
        bulletPool.Enqueue(newBullet);
        return newBullet;
    }

    public void ReturnBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
    public bool Execute()
    {
        if (Time.time - lastAttackTime < coolDown)
            return false;

        if (!passiveState)
        {
            Vector3 origin = _entity.transform.position;
            Collider[] colliders = Physics.OverlapSphere(origin, radius);

            IEntity closestEnemy = null;
            float closestDistance = Mathf.Infinity;

            foreach (var col in colliders)
            {
                if (col.gameObject == _entity.transform.gameObject)
                    continue;

                IEntity otherEntity = col.GetComponent<IEntity>();
                if (otherEntity != null && otherEntity.teamNum != this._entity.teamNum)
                {
                    float distance = Vector3.Distance(origin, otherEntity.transform.position);
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestEnemy = otherEntity;
                    }
                }
            }

            if (closestEnemy != null)
            {
                switch (bulletType)
                {
                    case 1:
                        Bullet bullet = GetBullet();

                        if (bullet == null)
                        {
                            Debug.LogError("Bullet not available in pool.");
                            return false;
                        }

                        Vector3 spawnBulletPos = _entity.transform.position + Vector3.up * 3f + new Vector3(0f, 0f, 2f);
                        bullet.transform.position = spawnBulletPos;

                        Vector3 direction = (closestEnemy.transform.position + new Vector3(0f, 2f, 0f) - spawnBulletPos).normalized;
                        _entity.transform.LookAt(closestEnemy.transform.position);
                        bullet.Init(direction, this._entity._characteristics.AT, 0.5f, _entity, this);
                        lastAttackTime = Time.time;
                        break;

                    case 2:
                        // Задел под splash или другой тип пули
                        break;

                    default:
                        Debug.LogWarning("Неизвестный тип пули");
                        break;
                }
            }
        }

        return true;
    }
}
