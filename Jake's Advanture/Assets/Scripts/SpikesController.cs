using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpikesController : MonoBehaviour
{
    public GameObject player;
    
    [SerializeField] private Tilemap spikes;
    [SerializeField] private Tile activeSpikes;
    [SerializeField] private Tile nonActiveSpikes;
    
    
    [SerializeField] private bool _isActive;
    void Start()
    {
        StartCoroutine(ActivateSpikeByTime());
        _isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_isActive)
        {
            spikes.GetComponent<TilemapCollider2D>().enabled = true;
            spikes.SwapTile(nonActiveSpikes, activeSpikes);
        }
        else
        {
            spikes.GetComponent<TilemapCollider2D>().enabled = false;
            spikes.SwapTile(activeSpikes, nonActiveSpikes);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }

    IEnumerator ActivateSpikeByTime()
    {
        while (true)
        {
            if (_isActive == true)
            {
                _isActive = false;
            }
            else
            {
                _isActive = true;
            }

            yield return new WaitForSecondsRealtime(3);
        }
    }
}
