using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour
{

    [SerializeField]
    private float speed;

    [SerializeField]
    private float maxHealth;

    private float health;
    private SpriteRenderer bar, emptyBar;
    private Vector2 barScale;

    void Start ()
    {
        health = maxHealth;
        bar = transform.GetChild(0).GetComponent<SpriteRenderer>();
        emptyBar = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    void Update ()
    {
        HealthChecker();
        HealthBarManager();
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        HealthChecker();
    }

    private void HealthChecker()
    {
        if(health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
    }

    private void HealthBarManager()
    {
        barScale = bar.transform.localScale;
        barScale.x = (emptyBar.transform.localScale.x / maxHealth) * health;
        bar.transform.localScale = barScale;
    }
}
