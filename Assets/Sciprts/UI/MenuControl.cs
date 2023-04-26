using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [SerializeField] VisualTreeAsset AudioSetting;
    VisualElement _audioSettingButtons;
    VisualElement _buttonWrapper;
    UIDocument _doc;
    Button _playButton;
    Button _exitButton;
    Button _settingButton;

    void Awake()
    {
        _doc = GetComponent<UIDocument>();
        _playButton = _doc.rootVisualElement.Q<Button>("PlayButton");
        _exitButton = _doc.rootVisualElement.Q<Button>("ExitButton");
        _settingButton = _doc.rootVisualElement.Q<Button>("SettingButton");
        _buttonWrapper = _doc.rootVisualElement.Q<VisualElement>("Buttons");

        _audioSettingButtons = AudioSetting.CloneTree();
        var backButton = _audioSettingButtons.Q<Button>("BackButton");

        _playButton.clicked += PlayButtonOnClicked;
        _exitButton.clicked += ExitButtonOnClicked;
        _settingButton.clicked += SettingButtonOnClicked;
        backButton.clicked += BackButtonButtonOnClicked;
    }

    void PlayButtonOnClicked()
    {
        SceneManager.LoadScene("MainGamingScene");
    }

    void ExitButtonOnClicked()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    void SettingButtonOnClicked()
    {
        _buttonWrapper.Clear();
        _buttonWrapper.Add(_audioSettingButtons);
    }

    void BackButtonButtonOnClicked()
    {
        _buttonWrapper.Clear();
        _buttonWrapper.Add(_playButton);
        _buttonWrapper.Add(_settingButton);
        _buttonWrapper.Add(_exitButton);
    }

}
