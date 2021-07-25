using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seconddiag : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject uiObject;

    void Start()
    {
        uiObject.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter2D (Collider2D Player)
    {
        if(Player.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(15);
        Destroy(uiObject);
        Destroy(gameObject);
    }
}
