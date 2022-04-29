using System.Collections;
using UnityEngine;

public class FloatingTarget : MonoBehaviour
{
    public GameObject death_particles;
    public bool isAlive = true;

    public float speed = 0;
    public float currentScale = 0;

    public float delayBeforeSelfDestruct = 5;
    public float timeOfLastReversal;

    private void Start()
    {
        currentScale = 0;
        speed = Random.Range(-0.05f, 0.05f);
        StartCoroutine("autodie");
    }

    public void Die()
    {
        if (isAlive)
            isAlive = false;
    }

    private void Update()
    {
        if (!isAlive)
        {
            Instantiate(death_particles, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if(Time.time > timeOfLastReversal + 2)
        {
            if(Mathf.Abs(transform.position.x) > 6)
            {
                speed *= -1;
                timeOfLastReversal = Time.time;
            }
        }
    }

    private void FixedUpdate()
    {
        currentScale = Mathf.MoveTowards(currentScale, 1, 0.1f);
        transform.localScale = Vector3.one * currentScale;

        transform.Translate(speed, 0, 0);
    }

    private IEnumerator autodie()
    {
        yield return new WaitForSeconds(delayBeforeSelfDestruct);

        Die();
    }
}