using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.Audio;
using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.Casino;
public class PlayingCard : MonoBehaviour
{
    [Serializable]
    public class CardSprite
    {
        public ECardSuit Suit;
        public ECardValue Value;
        public Sprite Sprite;
    }

    public struct CardData
    {
        public ECardSuit Suit;
        public ECardValue Value;
        public CardData(ECardSuit suit, ECardValue value);
    }

    public enum ECardSuit
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }

    public enum ECardValue
    {
        Blank,
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public string CardID;
    [Header("References")]
    public SpriteRenderer CardSpriteRenderer;
    public CardSprite[] CardSprites;
    public Animation FlipAnimation;
    public AnimationClip FlipFaceUpClip;
    public AnimationClip FlipFaceDownClip;
    [Header("Sound")]
    public AudioSourceController FlipSound;
    public AudioSourceController LandSound;
    private Coroutine moveRoutine;
    private Tuple<Vector3, Quaternion> lastGlideTarget;
    public bool IsFaceUp { get; private set; }
    public ECardSuit Suit { get; private set; }
    public ECardValue Value { get; private set; }
    public CardController CardController { get; private set; }

    private void OnValidate();
    public void SetCardController(CardController cardController);
    public void SetCard(ECardSuit suit, ECardValue value, bool network = true);
    public void ClearCard();
    public void SetFaceUp(bool faceUp, bool network = true);
    public void GlideTo(Vector3 position, Quaternion rotation, float duration = 0.5f, bool network = true);
    private CardSprite GetCardSprite(ECardSuit suit, ECardValue val);
    [Button]
    public void VerifyCardSprites();
}