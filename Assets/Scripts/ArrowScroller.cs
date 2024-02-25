/*
Arisa Takenaka Trombley
2375446
trombley@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
Contains methods that handles the scrolling of each "arrow"
*/
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowScroller : MonoBehaviour
{
    public float m_Tempo = 240;
    public GameObject gameController;
    public Game game;
    public bool hasStarted = true;
    
    private Transform pos;
    private ArrowSpawner arrowSpawner;
    private GameObject AS;
    

    // Start is called before the first frame update
    void Start()
    {
        // TutorialArrow();
        gameController = GameObject.Find("GameController");
        game = gameController.GetComponent<Game>();
        m_Tempo = game.gameStuff.tempos[game.speed_op];
        AS = GameObject.Find("ArrowSpawner");
        arrowSpawner = AS.GetComponent<ArrowSpawner>();
        m_Tempo = m_Tempo / 60f;
        pos = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {
        
            transform.position += new Vector3(0f, m_Tempo * Time.deltaTime, 0f);
            if (pos.position.y > 6.3)
            {
                Destroy(this.gameObject);
                arrowSpawner.removeArrow();
            } 
        }
    }
}
