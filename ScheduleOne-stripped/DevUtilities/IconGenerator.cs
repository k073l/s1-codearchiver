using System;
using System.Collections.Generic;
using System.IO;
using EasyButtons;
using ScheduleOne.ItemFramework;
using ScheduleOne.Product;
using UnityEngine;
using UnityEngine.Rendering;

namespace ScheduleOne.DevUtilities;
public class IconGenerator : Singleton<IconGenerator>
{
    [Serializable]
    public class PackagingVisuals
    {
        public string PackagingID;
        public MultiTypeVisualsSetter ProductVisuals;
        public Transform TopLevelTransform;
    }

    public int IconSize;
    public string OutputPath;
    public bool ModifyLighting;
    [Header("References")]
    public Registry Registry;
    public Camera CameraPosition;
    public Transform MainContainer;
    public Transform ItemContainer;
    public GameObject Canvas;
    public List<PackagingVisuals> Visuals;
    protected override void Awake();
    [Button]
    public void GenerateIcon();
    public Texture2D GeneratePackagingIcon(string packagingID, string productID);
    public Texture2D GetTexture(Transform model);
}