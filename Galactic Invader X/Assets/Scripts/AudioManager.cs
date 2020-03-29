using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioMixer mixer;
    public Image loading;
    public Button exitButton;
    public Button resetButton;

    public AudioSetting[] audioSettings;

    private enum AudioGroups
    {
        Music,
        SFX
    };

    private AudioMixerSnapshot startingSnapshot;
    private AudioMixerSnapshot musicFocusSnapshot;

    void Awake()
    {
        instance = GetComponent<AudioManager>();
    }

    void Start()
    {
        loading.enabled = false;
        startingSnapshot = mixer.FindSnapshot("Starting");
        musicFocusSnapshot = mixer.FindSnapshot("MusicFocus");

        for (int i = 0; i < audioSettings.Length; i++)
        {
            audioSettings[i].Initialize();
        }
    }

    void Update()
    {
        exitButton.onClick.AddListener(backToProfile);
    }

    private void backToProfile()
    {
        loading.enabled = true;
        SceneManager.LoadScene("Dashboard");
    }

    public void SetMusicVolume(float value)
    {
        audioSettings[(int)AudioGroups.Music].SetExposedParam(value);
    }

    public void SetSFXVolume(float value)
    {
        audioSettings[(int)AudioGroups.SFX].SetExposedParam(value);
    }

    public void SnapshotStarting()
    {
        startingSnapshot.TransitionTo(.5f);
    }

    public void SnapshotMusic()
    {
        musicFocusSnapshot.TransitionTo(.5f);
    }
}

[System.Serializable]
public class AudioSetting
{
    public Slider slider;
    public GameObject redX;
    public string exposedParam;

    public void Initialize()
    {
        slider.value = PlayerPrefs.GetFloat(exposedParam);
    }

    public void SetExposedParam(float value)
    {
        //redX.SetActive(value <= slider.minValue);
        AudioManager.instance.mixer.SetFloat(exposedParam, value);
        PlayerPrefs.SetFloat(exposedParam, value);
    }

}