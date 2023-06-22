using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EventsController : MonoBehaviour
{ 
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject deathParticles;

    [SerializeField] private List<GameObject> spawnPoints = new List<GameObject>();
    
    private AudioSource _deathSource;
    private AudioSource _mainMusic;
    
    public UnityEvent OnPlayerDeath;
    public UnityEvent RespawnPlayer;
    public UnityEvent UpdateKeyInfo;
    public UnityEvent UpdateHealthInfo;
    public UnityEvent UpdateMonetInfo;
    
    [SerializeField] private GameObject Camera;
    private Camera _camera;
    private List<Vector3> _cameraPositions;


    [SerializeField] private GameObject level1;
    [SerializeField] private GameObject level2;
    [SerializeField] private GameObject level3;
    [SerializeField] private GameObject _level1Original;
    [SerializeField] private GameObject _level2Original;
    [SerializeField] private GameObject _level3Original;

    [SerializeField] private TMP_Text healthShowerText;
    [SerializeField] private TMP_Text commonKeyShowerText;
    [SerializeField] private TMP_Text monetText;
    private void Awake()
    {
        _deathSource = GameObject.Find("Death").GetComponent<AudioSource>();
        _mainMusic = GameObject.Find("Music").GetComponent<AudioSource>();

        _camera = Camera.GetComponent<Camera>();
        _cameraPositions = _camera.cameraPositions;
    }

    private void SetOriginalLevels()
    {
        _level1Original = level1;
        _level2Original = level2;
        _level3Original = level3;
    }
    private void Start()
    {
        OnPlayerDeath.AddListener(_OnPlayerDeathMusic);
        OnPlayerDeath.AddListener(_OnPlayerDeath);
        
        RespawnPlayer.AddListener(_Respawn);
        
        UpdateKeyInfo.AddListener(_UpdateKeysInfo);
        UpdateHealthInfo.AddListener(_UpdateHeathInfo);
        UpdateMonetInfo.AddListener(_UpdateKeyInfo);
    }

    private void _OnPlayerDeathMusic()
    {
        _mainMusic.Stop();
        _deathSource.Play();
    }

    private void _OnPlayerDeath()
    {
        GameObject particle = Instantiate(deathParticles, player.transform.position, Quaternion.identity );
        StartCoroutine(DestroyParticle(particle));
        player.SetActive(false);
        
        KeysCount();
        MonetCount();
        
        UpdateHealthInfo.Invoke();
        UpdateKeyInfo.Invoke();
        UpdateMonetInfo.Invoke();
        
        RespawnPlayer.Invoke(); // заглушка
    }

    private IEnumerator DestroyParticle(GameObject particle)
    {
        yield return new WaitForSeconds(1);
        Destroy(particle);
    }

    private void KeysCount()
    {
        PlayerPrefs.SetInt("commonKeysCount_prefs", PlayerPrefs.GetInt("commonKeysCount_prefs") - PlayerPrefs.GetInt("current_commonKeysCount_prefs"));
        PlayerPrefs.SetInt("current_commonKeysCount_prefs", 0);
        PlayerPrefs.SetInt("mainKeysCount_prefs", PlayerPrefs.GetInt("mainKeysCount_prefs") - PlayerPrefs.GetInt("current_mainKeysCount_prefs"));
        PlayerPrefs.SetInt("current_mainKeysCount_prefs", 0);
    }
    private void MonetCount()
    {
        PlayerPrefs.SetInt("monet", PlayerPrefs.GetInt("monet") - PlayerPrefs.GetInt("current_monet"));
        PlayerPrefs.SetInt("current_monet", 0);
    }
    
    private void _Respawn()
    {
        int health = player.GetComponent<PlayerManager>().healthPoints--;
        if (health > 0)
        {
            int index = PlayerPrefs.GetInt("currentLevelIndex", 1);
            Debug.Log("index: " + index);
            player.transform.position = spawnPoints[index].transform.position;
            Camera.transform.position = _cameraPositions[index];
            player.SetActive(true);
            
            ResetGameLevel();
            UpdateHealthInfo.Invoke();
        }
        else
        {
            ResetProgress();
        }
    }

    private void ResetProgress()
    {
        PlayerPrefs.SetInt("currentLevelIndex", 1);
        player.GetComponent<PlayerManager>().healthPoints = 3;
        
        player.transform.position = spawnPoints[1].transform.position;
        Camera.transform.position = _cameraPositions[1];
        player.SetActive(true);
        
        ResetGameLevel();
        UpdateHealthInfo.Invoke();
        
    }

    private void ResetGameLevel()
    {
        //level 1
        foreach (Transform child in level1.transform) 
            Destroy(child.gameObject);
        foreach (Transform child in _level1Original.transform)
            Instantiate(child.gameObject, level1.transform);
        //level 2
        foreach (Transform child in level2.transform) 
            Destroy(child.gameObject);
        foreach (Transform child in _level2Original.transform)
            Instantiate(child.gameObject, level2.transform);
        //level 2
        foreach (Transform child in level3.transform) 
            Destroy(child.gameObject);
        foreach (Transform child in _level3Original.transform)
            Instantiate(child.gameObject, level3.transform);
        //music
        _mainMusic.Play();
    }

    private void _UpdateKeysInfo()
    {
        commonKeyShowerText.text = PlayerPrefs.GetInt("commonKeysCount_prefs").ToString();
    }
    private void _UpdateHeathInfo()
    {
        healthShowerText.text = player.GetComponent<PlayerManager>().healthPoints.ToString();
    }

    private void _UpdateKeyInfo()
    {
        monetText.text = PlayerPrefs.GetInt("monet").ToString();
    }
    
}
