using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowKillCount : MonoBehaviour
{
    public Transform player;
    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int count = player.GetComponent<MovePlayer>().killCount;
        txt.text = "" + count + " Kills";
    }
}
