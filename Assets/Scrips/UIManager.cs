using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField] private int slotsN = 6;

    [Header("Main Menu")]
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject perkPanel;

    [SerializeField] private TextButton bashButton;

    [SerializeField] private TextButton[] perkButtons;

    [Header("Bash Field")]
    [SerializeField] private ForgingSlot[] forgingSlots;
    [SerializeField] private GameObject[] focusedSlot;

    [Header("Events - Main Menu")]
    [SerializeField] private EventName eventBashButtonPushed;
    [SerializeField] private EventName eventSwitchMainMenu;
    [SerializeField] private EventName[] eventPerkButtonPushed;
    [SerializeField] private EventName eventPerkUpButtonPushed;
    [SerializeField] private EventName eventPerkDownButtonPushed;

    [Header("Events - Slots")]
    [SerializeField] private EventName eventSlotPointerOn;
    [SerializeField] private EventName eventSlotPointerOff;

    private enum MainPanelState
    {
        main,
        perks
    }

    private MainPanelState mainPanelState = MainPanelState.main;

    private void Start()
    {
        EventManager.StartListening(eventSwitchMainMenu, SwitchMainPanel);
        EventManager.StartListening(eventSlotPointerOn, FocusSlot);
        EventManager.StartListening(eventSlotPointerOff, OnPointerOffSlot);
    }

    private void SwitchMainPanel(string str)
    {
        switch (str)
        {
            case "toPerk":
                mainPanelState = MainPanelState.perks;
                mainPanel.SetActive(false);
                perkPanel.SetActive(true);
                break;
            case "toMain":
                mainPanelState = MainPanelState.main;
                mainPanel.SetActive(true);
                perkPanel.SetActive(false);
                break;
        }
    }

    /// <summary>
    /// lighten up the slot the pointer is on
    /// </summary>
    /// <param name="selectedN"></param>
    public void FocusSlot(string selectedN)
    {
        int number = int.Parse(selectedN);

        switch (GameManager.Instance.selection)
        {
            case GameManager.Selection.bash:
                //single slot
                focusedSlot[number].SetActive(true);

                //disable else
                for (int cnt = 0; cnt < slotsN; cnt++)
                {
                    if (cnt == number)
                    {
                        continue;
                    }
                    focusedSlot[cnt].SetActive(false);
                }

                break;
        }
    }

    /// <summary>
    /// to clear focus slot when pointer is off the forgin area
    /// </summary>
    private void OnPointerOffSlot(string number)
    {
        bool pointerOnSlot = false;
        for (int cnt = 0; cnt < slotsN; cnt++)
        {
            if (forgingSlots[cnt].IsPointerOn())
            {
                pointerOnSlot = true;
                break;
            }
        }

        if (!pointerOnSlot)
        {
            for (int cnt = 0; cnt < slotsN; cnt++)
            {
                focusedSlot[cnt].SetActive(false);
            }
        }
    }
}
