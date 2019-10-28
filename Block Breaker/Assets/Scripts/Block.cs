using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField] private AudioClip break_sound, hit_sound;
    [SerializeField] private GameObject block_vfx;
    [SerializeField] private Sprite[] dmg_affordance;
    
    // Cached reference
    private LevelHandler level;

    [SerializeField] private int times_hit = 0;

    private void Start() {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks() {
        level = FindObjectOfType<LevelHandler>();

        if (tag == "Breakable") {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (tag == "Breakable") {
            times_hit++;
            HandleHits();
        }
        //Debug.Log(collision.gameObject.name);
    }

    private void HandleHits() {
        int max_hits = dmg_affordance.Length + 1;
        if (times_hit >= max_hits)
            DestroyBlock();
        else 
            ShowNextSprite();
    }

    private void ShowNextSprite() {
        int index = times_hit - 1;
        if (dmg_affordance[index] != null)
            GetComponent<SpriteRenderer>().sprite = dmg_affordance[index];
        else 
            Debug.Log("SPRITE MISSING");
        
        AudioSource.PlayClipAtPoint(hit_sound, Camera.main.transform.position);
    }

    private void DestroyBlock() {
        DestroySFX();
        DestroyVFX();
        Destroy(gameObject);
        level.BlockDestroyed();
    }

    private void DestroySFX() {
        FindObjectOfType<GameStatus>().AddScore();
        AudioSource.PlayClipAtPoint(break_sound, Camera.main.transform.position);
    }

    private void DestroyVFX() {
        GameObject vfx = Instantiate(block_vfx, transform.position, transform.rotation);
        Destroy(vfx, 2f);
    }
}
