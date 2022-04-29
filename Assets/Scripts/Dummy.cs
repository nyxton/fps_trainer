using UnityEngine;

public class Dummy : MonoBehaviour
{
    public bool isAlive;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("is_alive", isAlive);
    }

    public void Die()
    {
        if (isAlive)
            isAlive = false;
    }

    public void Alive()
    {
        isAlive = true;
    }
}