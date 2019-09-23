using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour {
    [SerializeField] private int breakableBlocks = 0, brokenBlocks = 0;

    // Cached reference
    private SceneLoader sceneLoader;
    // Start is called before the first frame update
    void Start() {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CountBreakableBlocks() {
        breakableBlocks++;
        //Debug.Log(breakableBlocks);
    }

    public void BlockDestroyed() {
        breakableBlocks--;

        if (breakableBlocks <= 0) {
            sceneLoader.LoadNextScene();
        }
    }
}
