using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;

public class ExpManager : MonoBehaviour 
{
    public int level;
    public int currentExp;
    public int expTopLevel = 10;
    public float expGrowthMultipliter = 1.2f;

    public Slider expSlider;
    public TMP_Text currentLevelText;

    public static event Action<int> OnLevelUp;


    private void Start()
    {
        UpdateUI();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            GainExperience(2);
        }
    }

    private void OnEnable()
    {
        Enemy_Health.OnMonsterDefeated += GainExperience;
    }

    private void OnDisable()
    {
        Enemy_Health.OnMonsterDefeated -= GainExperience;
    }

    public void GainExperience(int amount)
    {
        currentExp += amount;
        if(currentExp > expTopLevel)
        {
            LevelUp();
        }

        UpdateUI();
    }

    private void LevelUp()
    {
        level++;
        currentExp -= expTopLevel;
        expTopLevel = Mathf.RoundToInt(expTopLevel * expGrowthMultipliter);
        OnLevelUp?.Invoke(1);
    }

    public void UpdateUI()
    {
        expSlider.maxValue = expTopLevel;
        expSlider.value = currentExp;
        currentLevelText.text = "Level:" + level;
    }
}
