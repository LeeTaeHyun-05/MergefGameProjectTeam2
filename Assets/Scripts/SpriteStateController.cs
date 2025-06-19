using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteStateController : MonoBehaviour
{
    [Header("�������� �����̴�")]
    public Slider hungryGuage;

    [Header("��������Ʈ")]
    public Image bearImage;
    public Image characterImage;

    [Header("�� ��������Ʈ")]
    public Sprite bearNormal;
    public Sprite bearHungry;
    public Sprite bearEating;
    public Sprite bearFull;

    [Header("ĳ���� ��������Ʈ")]
    public Sprite characterNormal;
    public Sprite characterScared;
    public Sprite characterSurprised;
    public Sprite characterSad;

    public enum Stage { Stage1, Stage2, Stage3 }
    public Stage CurrentStage;

    private float timerMax;

    void Start()
    {
        if (hungryGuage != null)
        {
            timerMax = hungryGuage.maxValue;
        }
        else
        {
            Debug.LogError("��� ������ �����̴��� ������� �ʾҽ��ϴ�.");
        }
    }
    void Update()
    {
        if (hungryGuage == null) return;

        float currentTime = hungryGuage.value;

        switch (CurrentStage)
        {
            case Stage.Stage1:
                UpdateSprites(currentTime, 45f, 20f, 3f, 2f, 0f);
                break;
            case Stage.Stage2:
                UpdateSprites(currentTime, 35f, 16f, 3f, 2f, 0f);
                break;
            case Stage.Stage3:
                UpdateSprites(currentTime, 30f, 14f, 3f, 2f, 0f);
                break;
        }
    }
    void UpdateSprites(float time, float max, float normalThreshold, float hungryThreshold, float eatingThreshold, float fullThreshold)
    {
        if (time >= normalThreshold)
        {
            bearImage.sprite = bearNormal;
            characterImage.sprite = characterNormal;
        }
        else if (time > hungryThreshold)
        {
            bearImage.sprite = bearHungry;
            characterImage.sprite = characterScared;
        }
        else if (time > fullThreshold)
        {
            bearImage.sprite = bearEating;
            characterImage.sprite = characterSurprised;
        }
        else
        {
            bearImage.sprite = bearFull;
            characterImage.sprite = characterSad;
        }
    }
}
