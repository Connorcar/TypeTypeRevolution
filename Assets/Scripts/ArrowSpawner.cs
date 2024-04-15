/*
Arisa Takenaka Trombley
2375446
trombley@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
Contains methods that handle the spawning of "arrows" with words from the randomized word list
*/
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public WordBank wordBank = null;
    public int SongArrowNum;
    public Queue<GameObject> onScreenArrows = new Queue<GameObject>();
    public List<GameObject> spawnedArrows = new List<GameObject>();
    public List<string> SongArrows = new List<string>();
    
    [SerializeField] private GameObject leftArrowSpawn;
    [SerializeField] private GameObject rightArrowSpawn;
    [SerializeField] private GameObject upArrowSpawn;
    [SerializeField] private GameObject downArrowSpawn;
    
    private Game game;
    private GameObject gc;
    private GameObject Typer;
    private Words words;
    private bool isWaiting;
    private float spawnTime;
    private int count = 0;

    public ParticleSystem particleEffect1;
    public ParticleSystem particleEffect2;
    public ParticleSystem particleEffect3;
    public ParticleSystem particleEffect4;
    public ParticleSystem particleEffect5;
    public ParticleSystem particleEffect6;
    public ParticleSystem particleEffect7;
    public ParticleSystem particleEffect8;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameController");
        game = gc.GetComponent<Game>();
        Typer = GameObject.Find("Typer");
        words = Typer.GetComponent<Words>();
        SongArrows = game.gameStuff.levelArrows[game.song_op];
        SongArrowNum = game.gameStuff.levelArrows[game.song_op].Count;
        game.possibleHits = SongArrowNum;
        spawnTime = game.gameStuff.spawnTimes[game.speed_op];
        game.isOver = false;
        game.GameSceneSetup();
        //particleEffect4.Play();
        StartCoroutine("RepeatSpawnArrows");
    }
    
    private IEnumerator RepeatSpawnArrows()
    {
        while (game.isOver == false)
        {
            SpawnArrows();
            yield return new WaitForSeconds(spawnTime);
        }
    }
    
    private void SpawnArrows()
    {
        // instantiate arrows in a list
        int currIndex = count;
        
        string arrow = SongArrows[count++];
        if (arrow == "Up")
        {
            onScreenArrows.Enqueue((GameObject)Instantiate(upArrowSpawn));
        } 
        else if (arrow == "Down")
        {
            onScreenArrows.Enqueue((GameObject)Instantiate(downArrowSpawn));
        }
        else if (arrow == "Left")
        {
            onScreenArrows.Enqueue((GameObject)Instantiate(leftArrowSpawn));
        }
        else if (arrow == "Right")
        {
            onScreenArrows.Enqueue((GameObject)Instantiate(rightArrowSpawn));
        }
        // set word for newly spawned arrow
        spawnedArrows.Add(onScreenArrows.Last());
        spawnedArrows[currIndex].GetComponent<Arrow>().wordoutput.text = wordBank.GetWord();

        if (count > SongArrowNum - 1)
        {
            print("count is " + count);
            game.isOver = true;
        }
    }

    public void removeArrow()
    {
        // if the arrow is dequeued already 
        onScreenArrows.Dequeue();
        words.ResetCurrentWord();
        print("Removing arrow");
    }

    public void playParticleEffect(int n)
    {
        switch (n)
        {
            case 1:
                particleEffect1.Play();
                particleEffect5.Play();
                break;
            case 2:
                particleEffect2.Play();
                particleEffect6.Play();
                break;
            case 3:
                particleEffect3.Play();
                particleEffect7.Play();
                break;
            case 4:
                particleEffect4.Play();  
                particleEffect8.Play();              
                break;
        }
        particleEffect4.Play();
    }
}
