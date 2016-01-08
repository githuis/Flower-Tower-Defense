using UnityEngine;
using System.Collections;

public enum TowerType {ArrowTower };

public class Tower : MonoBehaviour
{
    public TowerType towerType;
    public float damage;
    public float range;
    public float shootTime;

    public GameObject projectilePrefab;

    private float nextTime;
    private Mob lastTarget;
    private bool hasTarget;

    void Start ()
    {
        nextTime = Time.time;

    }

    void Update ()
    {
        ShootHandler();

    }

    private void ShootHandler()
    {
        if(!CanShoot())
            return;

        Shoot();
    }

    private void Shoot()
    {

        if(lastTarget == null)
            return;

        //lastTarget.TakeDamage(damage);
        GameObject pj = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
        Projectile p = pj.GetComponent<Projectile>();
        p.damage = damage;
        p.speed = 4;
        p.target = lastTarget.gameObject;

        nextTime = Time.time + shootTime;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(lastTarget != null)
            return;
        if(other.CompareTag("Mob"))
        {

            lastTarget = other.GetComponent<Mob>();
            hasTarget = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == lastTarget.gameObject)
        {
            lastTarget = null;
            hasTarget = false;
        }
    }

    private bool CanShoot()
    {
        return (hasTarget && nextTime <= Time.time);
    }
}
