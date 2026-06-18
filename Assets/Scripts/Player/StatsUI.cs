using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class StatsUI : MonoBehaviour
{
    public GameObject[] statsSlots;
    public CanvasGroup statsCanvas;

    public InputActionAsset toggleStats;
    private InputAction statsAction;
    


    private void Start()
    {
        UpdateAllStats();
    }

    private void Awake()
    {
        statsAction = toggleStats.FindAction("UI/ToggleStats");
    }

    private void OnEnable()
    {
        statsAction.Enable();
        statsAction.performed += ToggleStatsCanvas;

    }

    private void OnDisable()
    {
        statsAction.performed -= ToggleStatsCanvas;
        statsAction.Disable();
    }

    private void ToggleStatsCanvas(InputAction.CallbackContext context)
    {
        if (statsCanvas.alpha == 0)
        {
            statsCanvas.alpha = 1;
            Time.timeScale = 0;
        }
        else
        {
            statsCanvas.alpha = 0;
            Time.timeScale = 1;
        }
    }

    public void UpdateDamage()
    {
        statsSlots[0].GetComponentInChildren<TMP_Text>().text = "Damage:" + StatsManager.Instance.damage;
    }

    public void UpdateSpeed()
    {
        statsSlots[1].GetComponentInChildren<TMP_Text>().text = "Speed:" + StatsManager.Instance.speed;
    }

    public void UpdateAllStats()
    {
        statsCanvas.alpha = 0;

        UpdateDamage();
        UpdateSpeed();
    }
}
