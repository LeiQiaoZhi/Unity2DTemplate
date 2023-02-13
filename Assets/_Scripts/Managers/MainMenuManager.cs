using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Button levelsButton;
    public List<CanvasGroup> achievementCanvasGroups;
    public List<GameObject> views;
    public TextMeshProUGUI deathCountTxt;

    [Header("Sound")]
    [SerializeField] Toggle musicToggle;
    [SerializeField] Toggle soundFxToggle;
    [SerializeField] float defaultMusicVol = -15f;
    [SerializeField] float defaultSoundFxVol;
    [SerializeField] AudioMixerGroup musicOutput;
    [SerializeField] AudioMixerGroup soundEffectOutput;

    private void Start()
    {
        
        // default view is levels
        levelsButton.Select();
        ShowView(0);
        
        // default music and sound vol
        SetMusicVol(defaultMusicVol);
        SetSoundFxVol(defaultSoundFxVol);
        
        // Lock Levels
        SetLevelButtonsLock();
        
        // achievements
        SetAchievementsLock();
        UpdateDeathCount();
    }

    public void UpdateDeathCount()
    {
        deathCountTxt.text = "Deaths: " + AchievementManager.instance.GetDeathCount().ToString();
    }

    public void SetMusicVol(float volume)
    {
       musicOutput.audioMixer.SetFloat("musicVol", volume);
    }

    public void SetSoundFxVol(float volume)
    {
       soundEffectOutput.audioMixer.SetFloat("soundFxVol", volume);
    }

    public void ToggleMusic()
    {
        if (musicToggle.isOn)
        {
            SetMusicVol(defaultMusicVol);
        }
        else
        {
            SetMusicVol(-80);
        }
        AudioManager.Instance.PlaySound("Click");
    }

    public void ToggleSoundFx()
    {
        if (soundFxToggle.isOn)
        {
            SetSoundFxVol(defaultSoundFxVol);
        }
        else
        {
            SetSoundFxVol(-80);
        }
        AudioManager.Instance.PlaySound("Click");
    }
    

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }


    public void ShowView(int index)
    {
        foreach(GameObject view in views)
        {
            view.SetActive(false);
        }
        views[index].SetActive(true);
    }



    public void SetLevelButtonsLock()
    {
        // for(int i = 0; i<buttons.Count; i++)
        // {
        //     bool unlocked = LevelManager.instance.IsLevelUnlocked(i);
        //     buttons[i].interactable = unlocked;
        // }
    }

    public void SetAchievementsLock()
    {
        for (int i = 0; i < achievementCanvasGroups.Count; i++)
        {
            bool unlocked = AchievementManager.instance.IsAchievementUnlocked(i);
            LoggerX.Log(Category.Achievement,$"achievement {i} is unlocked: {unlocked}");
            achievementCanvasGroups[i].alpha = unlocked ? 1 : 0.5f;
        }
    }
}
