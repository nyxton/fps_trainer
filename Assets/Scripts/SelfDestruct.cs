using System.Collections;
using UnityEngine;

namespace Nyxton
{
    public class SelfDestruct : MonoBehaviour
    {
        public float delay = 1.0f;

        private void Start()
        {
            StartCoroutine("Die");
        }

        private IEnumerator Die()
        {
            yield return new WaitForSeconds(delay);
            Destroy(gameObject);
        }
    }
}