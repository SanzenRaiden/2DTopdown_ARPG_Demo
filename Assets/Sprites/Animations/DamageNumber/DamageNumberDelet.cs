using UnityEngine;
using System.Collections;

public class DamageNumberDelet : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(isDelet());
    }

    private IEnumerator isDelet()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
   
}
