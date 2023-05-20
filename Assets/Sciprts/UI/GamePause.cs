using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    [SerializeField] VisualTreeAsset _gamePause;
    [SerializeField] VisualTreeAsset _settingMenu;
    [SerializeField] VisualTreeAsset _audioSetting;
    VisualElement _gameSetting;
    VisualElement _gamePauseVE;
    VisualElement _settingMenuVE;
    VisualElement _audioSettingVE;
    UIDocument _doc;
    Button _pauseButton;
    Button _gprbuttons; //RESU
    Button _gpsbuttons; //SETT
    Button _gpmbuttons; //MAIN
    Button _gpdbuttons; //DESK
    Button _smabuttons; //AUDIO
    Button _smcbuttons; //CONTR
    Button _smgbuttons; //GAMEP
    Button _smbbuttons; //BACK
    Button _asbbuttons; //BACK

    public void Awake()
    {
        _doc = GetComponent<UIDocument>();
        _gameSetting = _doc.rootVisualElement.Q<VisualElement>("MiddleSection");
        _pauseButton = _doc.rootVisualElement.Q<Button>("Pause");
        _pauseButton.clicked += PauseButtonOnClicked;

        _gamePauseVE = _gamePause.CloneTree();
        _gprbuttons = _gamePauseVE.Q<Button>("Resume");
        _gpsbuttons = _gamePauseVE.Q<Button>("Setting");
        _gpmbuttons = _gamePauseVE.Q<Button>("BackToMainMenu");
        _gpdbuttons = _gamePauseVE.Q<Button>("BackToDesktop");
        _gprbuttons.clicked += ResumeButtonOnClicked;
        _gpsbuttons.clicked += SettingButtonOnClicked;
        _gpmbuttons.clicked += BTMainMenuButtonOnClicked;
        _gpdbuttons.clicked += BTDesktopButtonOnClicked;

        _settingMenuVE = _settingMenu.CloneTree();
        _smabuttons = _settingMenuVE.Q<Button>("Audio");
        _smcbuttons = _settingMenuVE.Q<Button>("Control");
        _smgbuttons = _settingMenuVE.Q<Button>("Gameplay");
        _smbbuttons = _settingMenuVE.Q<Button>("Back");
        _smabuttons.clicked += AudioButtonOnClicked;
        _smcbuttons.clicked += ControlButtonOnClicked;
        _smgbuttons.clicked += GameplayButtonOnClicked;
        _smbbuttons.clicked += BTGamePauseButtonOnClicked;

        _audioSettingVE = _audioSetting.CloneTree();
        _asbbuttons = _audioSettingVE.Q<Button>("Back");
        //_asbbuttons.clicked += BTSettingMenuButtonOnClicked;
    }

    void PauseButtonOnClicked()
    {
        _gameSetting.Clear();
        _gameSetting.Add(_gamePauseVE);
    }

    void ResumeButtonOnClicked()
    {
        _gameSetting.Clear();
    }

    void SettingButtonOnClicked()
    {
        _gameSetting.Clear();
        _gameSetting.Add(_settingMenuVE);
    }

    void BTMainMenuButtonOnClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void BTDesktopButtonOnClicked()
    {
        Application.Quit();
    }

    void AudioButtonOnClicked()
    {
        _gameSetting.Clear();
        _gameSetting.Add(_audioSettingVE);
    }

    void ControlButtonOnClicked()
    {
        Debug.Log("1");
    }

    void GameplayButtonOnClicked()
    {
        Debug.Log("1");
    }

    void BTGamePauseButtonOnClicked()
    {
        _gameSetting.Clear();
        _gameSetting.Add(_gamePauseVE);
    }

    void BTSettingMenuButtonOnClicked()
    {
        _gameSetting.Clear();
        _gameSetting.Add(_settingMenuVE);
    }
}

