using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushesScript : MonoBehaviour
{
    public GameObject player;

    private void Awake()
    {
        player.GetComponent<PlayerMovement>();
        bool isHidden = player.GetComponent<PlayerMovement>().isHidden;
    }

    void Update()
    {
        
    }
}
