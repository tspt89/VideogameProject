using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameMaster : MonoBehaviour
{
    public GameObject WinUI;

    private bool won = false;

    public int points;

    private CameraController camctrl;

    // Start is called before the first frame update
    void Start()
    {
        WinUI.SetActive(false);
        camctrl = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(points > 0)
        {
            won = !won;
        }

        if(won)
        {
            WinUI.SetActive(true);
            camctrl.speed = 0;
        }

        
    }
}
