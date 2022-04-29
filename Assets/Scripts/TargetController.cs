using System.Collections;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public Dummy[] Dummies;
    public GameObject floatingPrefab;
    public Transform floatingParent;
    public Vector2 spawnArea;

    public int aliveDummies
    {
        get
        {
            int val = 0;
            foreach(Dummy d in Dummies)
            {
                if (d.isAlive)
                    val++;
            }

            return val;
        }
    }

    public int aliveFloating
    {
        get
        {
            return floatingParent.childCount;
        }
    }

    private void Update()
    {
        if(aliveDummies + aliveFloating == 0)
        {
            setNewDummies();
            setNewFloating();
        }
    }

    private void setNewFloating()
    {
        int rand = Random.Range(0, 6);

        for(int i = 0; i < rand; i++)
        {
            float rX = Random.Range(-spawnArea.x, spawnArea.x);
            float rZ = Random.Range(-spawnArea.y, spawnArea.y);
            Vector3 pos = new Vector3(rX, 0, rZ);

            GameObject newFloat = Instantiate(floatingPrefab, pos + floatingParent.position, floatingParent.rotation);
            newFloat.transform.parent = floatingParent;
        }
    }

    private void setNewDummies()
    {
        foreach(Dummy d in Dummies)
        {
            if(Random.Range(0, 3) == 1)
            {
                d.Alive();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(floatingParent.position, new Vector3(spawnArea.x, 0, spawnArea.y));
    }
}