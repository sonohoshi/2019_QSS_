﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackBTN : MonoBehaviour
{
    public Image coolDown;

    public GameObject Player;
    private GameObject _pistol;
    private GameObject _rifle;
    private GameObject _shotgun;
    private GameObject _crossbow;
    private GameObject _bat;

    private bool _nowReloading = false;
    private int _weapon;
    private Transform _bulletLocation;
    private Transform _gunRotation;
    private Button _attackButton;
    private static float reloadTime;
    private static bool reloadCheck = false;
    private readonly Vector3 addAngle = new Vector3(0, 0, -90);

    public static void SetReloadTime(float thatTime)
    {
        reloadTime = thatTime;
        reloadCheck = true;
    }

    private void Start()
    {
        _attackButton = this.transform.GetComponent<Button>();
        _attackButton.onClick.AddListener(UserAttack);
        
    }

    private void Update() // 현재 업데이트에서는 재장전 버튼 UI 조작 이외의 행동을 하지 않음.
    {
        if (reloadCheck)
        {
            reloadCheck = false;
            _nowReloading = true;
            coolDown.fillAmount = 0;
        }
        if (_nowReloading)
        {
            if (coolDown.fillAmount < 1)
                coolDown.fillAmount += 1f/reloadTime*Time.deltaTime;
            else
                _nowReloading = false;
        }
    }

    public void Selector() //해당 함수는 무기가 바뀔때마다 실행될 수 있도록 만들어야 함.
    {
        _pistol = Player.transform.GetChild(0).gameObject;
        _crossbow = Player.transform.GetChild(1).gameObject;
        _rifle = Player.transform.GetChild(2).gameObject;
        _shotgun = Player.transform.GetChild(3).gameObject;
        _bat = Player.transform.GetChild(4).gameObject;
        if (_pistol.activeSelf)
        {
            PistolBaseBullet.Initalize(_pistol.transform.GetChild(0), _pistol.transform);
            PistolBaseBullet.StartCoroutine();
            _weapon = 1;
            Handgun.cnt++;
            return;
        }
        if (_rifle.activeSelf)
        {
            RifleBaseBullet.Initalize(_rifle.transform.GetChild(0), _rifle.transform);
            RifleBaseBullet.StartCoroutine();
            _weapon = 2;
            AssaultRifle.cnt++;
            return;
        }
        if (_shotgun.activeSelf)
        {
            ShotgunBaseBullet.Initalize(_shotgun.transform.GetChild(0), _shotgun.transform);
            ShotgunBaseBullet.StartCoroutine();
            _weapon = 3;
            Shotgun.cnt++;
            return;
        }
        if (_crossbow.activeSelf)
        {
            CrosbowBaseBullet.Initalize(_crossbow.transform.GetChild(0), _crossbow.transform);
            CrosbowBaseBullet.StartCoroutine();
            _weapon = 4;
            Crossbow.cnt++;
            return;
        }
        if (_bat.activeSelf)
        {
            _weapon = 5;
            Bat.cnt = 1;
        }
        _weapon = 0;
    }
    
    public void UserAttack()
    {
#if UNITY_EDITOR
        Debug.Log(_weapon);
#endif
        switch (_weapon)
        {
            case 1:PistolBaseBullet.StartPistolDelayCoroutine(); break;
            case 2:RifleBaseBullet.StartRifleDelayCoroutine(); break;
            case 3:ShotgunBaseBullet.StartshotgunDelayCoroutine(); break;
            case 4:CrosbowBaseBullet.StartCrosbowDelayCoroutine(); break;
        }
    }
}