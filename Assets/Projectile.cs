using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public GameObject target;
    public float speed, damage;

	void Start () {

	}

	void Update () {

        try
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, target.transform.position) < 0.05)
            {
                target.GetComponent<Mob>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        catch (UnassignedReferenceException)
        {
            Destroy(gameObject);
        }
        catch (MissingReferenceException)
        {
            Destroy(gameObject);
        }

	}
}
