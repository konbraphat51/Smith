using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public enum Sequence
    {
        selecting,
    }

    public enum Selection
    {
        bash,
    }

    public Sequence sequence { get; private set; }
        = Sequence.selecting;

    public Selection selection { get; private set; }
        = Selection.bash;

    [Header("Values")]
    [SerializeField] private int stamina = 30;
    [SerializeField] private int slotN = 6;

    [Header("Objects")]
    [SerializeField] private UIManager uiManager;
    [SerializeField] private ForgingSlot[] forgingSlots;

    [Header("Event")]
    [SerializeField] private EventName eventBashButtonPushed;

    private void Start()
    {
        EventManager.StartListening(eventBashButtonPushed, OnBashClicked);
    }

    void Update()
    {

    }

    /// <summary>
    /// Operate bashing
    /// </summary>
    /// <param name="number"></param>
    private void OnBashClicked(string number)
    {
        int focusedNumber = int.Parse(number);

        foreach(int slotNumber in GetSelectedSlot(focusedNumber))
        {
            forgingSlots[slotNumber].Bash(GetHitPoint(slotNumber, focusedNumber));
        }
    }

    /// <summary>
    /// Return hitted point based on selection
    /// </summary>
    /// <param name="targetNumber"></param>
    /// <param name="focusedNumber"></param>
    /// <returns></returns>
    private int GetHitPoint(int targetNumber, int focusedNumber)
    {
        int hitPoint = 0;

        switch (Instance.selection)
        {
            case Selection.bash:
                hitPoint = 10;
                break;
            default:
                Debug.LogWarning("GetHitPoint: no hit point allocated");
                break;
        }

        return hitPoint;
    }

    /// <summary>
    /// Return list of selected slots
    /// </summary>
    /// <param name="focused"></param>
    /// <returns></returns>
    public int[] GetSelectedSlot(int focused)
    {
        switch (Instance.selection)
        {
            case Selection.bash:
                return new int[1] { focused };
        }

        return null;
    }
}