using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour {
    [SerializeField] private int breakableBlocks = 0, brokenBlocks = 0;

    // Cached reference
    private SceneLoader sceneLoader;

    //private GameStatus gameStatus;
    // Start is called before the first frame update
    void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
        //gameStatus = FindObjectOfType<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CountBlocks() {
        breakableBlocks++;
        //Debug.Log(breakableBlocks);
    }

    public void BlockDestroyed() {
        breakableBlocks--;
        //gameStatus.AddScore();
        
        if (breakableBlocks <= 0) {
            //new WaitForSeconds(5);
            TimeDelay();
            sceneLoader.LoadNextScene();
            
        }
    }

    IEnumerator TimeDelay() {
        yield return new WaitForSeconds(3);
    }

    void EscGame() {
        if (Input.GetKeyDown(KeyCode.Escape))
            sceneLoader.QuitGame();
    }
}
