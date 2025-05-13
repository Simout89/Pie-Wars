using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 0.5f;
    public double damage = 10;
    public float lifeTime = 50f;

    public float startTime;

    private Vector3 direction;

    private IEntity creator; // ������, ������� ������� ����

    private AttackInRadius command;

    public void Init(Vector3 direction, double damage, float speed, IEntity creator, AttackInRadius _command)
    {
        this.direction = direction.normalized;
        this.damage = damage;
        //this.lifeTime = speed;
        this.creator = creator;
        command = _command;

        startTime = Time.time;
        //Destroy(gameObject, lifeTime); // ����������� ����� ����� �� ������ ������
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (startTime - Time.time >= lifeTime) { command.ReturnBullet(this); }

    }

    void OnTriggerEnter(Collider other)
    {
        // ���������, ��� �� ����������� � ���������� ����
        if (other.GetComponent<IEntity>() != creator)
        {
            IEntity entity = other.GetComponent<IEntity>();
            if (entity != null)
            {
                
                entity.TakeDamage(damage);
                //Destroy(gameObject);
                command.ReturnBullet(this);

            }
        }

       
       
    }


}
