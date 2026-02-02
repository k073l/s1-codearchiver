using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.DevUtilities;
[CreateAssetMenu(fileName = "SpriteFont", menuName = "ScriptableObjects/Fonts/SpriteFont")]
public class SpriteFont : ScriptableObject
{
    [Serializable]
    public class SpriteFontItem
    {
        public string Name;
        public Sprite Sprite;
    }

    [SerializeField]
    private List<SpriteFontItem> SpriteFontItems;
    public Sprite GetSprite(string name);
}