using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Text debugText;
    public bool doDebug = false;
    public float firingGracePeriod = 0.1f;

    bool isFiring = false;

    private void Update()
    {
        DoRaycast();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine("fire");
        }
    }

    private void DoRaycast()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1000.0f))
        {
            if (doDebug)
            {
                SetDebugText("");
                switch (hit.transform.tag)
                {
                    case ("dummy_main"):
                        SetDebugText(hit.transform.name);
                        break;
                    case ("dummy_crit"):
                        SetDebugText(hit.transform.name);
                        break;
                    case ("floating_target"):
                        SetDebugText(hit.transform.name);
                        break;
                }
            }

            if (isFiring)
            {
                switch (hit.transform.tag)
                {
                    case ("dummy_main"):
                        hit.transform.parent.SendMessage("Die");
                        break;
                    case ("dummy_crit"):
                        hit.transform.parent.SendMessage("Die");
                        break;
                    case ("floating_target"):
                        hit.transform.SendMessage("Die");
                        break;
                }
            }
        }
    }

    private void SetDebugText(string s)
    {
        debugText.text = s;
    }

    private IEnumerator fire()
    {
        isFiring = true;
        yield return new WaitForSecondsRealtime(firingGracePeriod);
        isFiring = false;
    }
}