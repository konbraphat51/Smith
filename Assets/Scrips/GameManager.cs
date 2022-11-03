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

    [SerializeField] private UIManager uiManager;

    [SerializeField] private EventName eventToSelectingSlot;

    void Start()
    {
    }

    void Update()
    {

    }
}