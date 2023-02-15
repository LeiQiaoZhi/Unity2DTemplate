using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.SceneManagement;


// SINGLETON
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public List<int> levelsUnlockedAtTheStart;

    private void Awake()
    {
#if DEBUG
        foreach (var t in levelsUnlockedAtTheStart)
        {
            UnlockLevel(t);
        }
#else
        // don't unlock any levels
#endif

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetLevels()
    {
        for (int i = 1; i <= 3; i++)
        {
            LockLevel(i);
        }
    }

    public void LockLevel(int i)
    {
        XLogger.Log(Category.Level,$"Level {i} is locked");
        PlayerPrefs.SetInt($"level{i}", 0);
    }

    public void UnlockLevel(int i)
    {
        XLogger.Log(Category.Level,$"Level {i} is unlocked");
        PlayerPrefs.SetInt($"level{i}", 1);
    }

    public bool IsLevelUnlocked(int i)
    {
        int unlocked = PlayerPrefs.GetInt($"level{i}", 0);
        XLogger.Log(Category.Level,$"level {i} is unlocked: {unlocked}");
        return unlocked == 1;
    }
}