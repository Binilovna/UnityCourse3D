using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgradeButton : MonoBehaviour
{
    private enum UpgradeType
    {
        Speed,
        Jump
    }

    [SerializeField] private UpgradeType upgradeType;
    [SerializeField] private GameObject player;
    private PlayerManager _playerManager;
    private PlayerController _playerController;
    [SerializeField] private EventsController _eventsController;
    private void Start()
    {
        _playerManager = player.GetComponent<PlayerManager>();
        _playerController = player.GetComponent<PlayerController>();
        
        gameObject.GetComponent<Button>().onClick.AddListener(BuyUpgradeOnClick);
    }

    private void BuyUpgradeOnClick()
    {
        if (upgradeType == UpgradeType.Speed)
        {
            if (PlayerPrefs.GetInt("monet") >= 2)
            {
                _playerController._velocity = _playerController._velocity + 5;
                PlayerPrefs.SetInt("monet", PlayerPrefs.GetInt("monet") - 2);
                _eventsController.UpdateMonetInfo.Invoke();
            }
        }
        if (upgradeType == UpgradeType.Jump)
        {
            if (PlayerPrefs.GetInt("monet") >= 2)
            {
                _playerManager.jumpForce = _playerManager.jumpForce + 4;
                PlayerPrefs.SetInt("monet", PlayerPrefs.GetInt("monet") - 2);
                _eventsController.UpdateMonetInfo.Invoke();
            }
        }
    }
}
