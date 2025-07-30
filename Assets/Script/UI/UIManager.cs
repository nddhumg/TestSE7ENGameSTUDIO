using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Button btnKick;
    [SerializeField] private Button btnKickAuto;
    [SerializeField] private Button btnReset;
    public Action OnKick;
    public Action OnKickAuto;

    private void Start()
    {
        btnKick.onClick.AddListener(() => { OnKick?.Invoke(); });
        btnKickAuto.onClick.AddListener(() => { OnKickAuto?.Invoke(); });
        btnReset.onClick.AddListener(ResetScene);
    }

    public void HandleBtnKick(bool canShot)
    {
        btnKick.gameObject.SetActive(canShot);
    }

    public void HandleBtnKickAuto(bool canShot)
    {
        btnKickAuto.gameObject.SetActive(canShot);
    }

    private void ResetScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
