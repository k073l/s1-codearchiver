using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Weather;
public class MaskModificationCreator : MonoBehaviour
{
    public enum EModificationSize
    {
        Small8x8,
        Medium16x16,
        Large32x32
    }

    [Header("Components")]
    [SerializeField]
    private MaskController _maskController;
    [Header("Settings")]
    [SerializeField]
    private string _modificationName;
    [SerializeField]
    private EModificationSize _size;
    [Tooltip("Layers the height raycasts hit. Should match the HeightMaskGenerator.")]
    [SerializeField]
    private LayerMask _heightmapLayerMask;
    [Tooltip("Keep the modification fully inside the mask bounds.")]
    [SerializeField]
    private bool _clampToMask;
    [Header("Output")]
    [Tooltip("Texel index of the modification's min corner (-X, -Z). Refreshed while gizmos draw.")]
    [SerializeField]
    private Vector2Int _startIndex;
    [Header("Texture Array")]
    [Tooltip("Modifications combined into a Texture2DArray, in this order.")]
    [SerializeField]
    private List<MaskModificationData> _modifications;
    [Tooltip("How many slices BuildTextureArrayAsync copies per frame. Higher = faster but more chance of a hitch.")]
    [SerializeField]
    private int _slicesPerFrame;
    [Tooltip("Populated once BuildTextureArrayAsync finishes.")]
    [SerializeField]
    private Texture2DArray _runtimeTextureArray;
    [Header("Debug")]
    [SerializeField]
    private bool _showGizmos;
    [SerializeField]
    private bool _showCellLines;
    [Tooltip("Editor-only preview of the combined Texture2DArray. Not saved to disk.")]
    [SerializeField]
    private Texture2DArray _debugTextureArray;
    private const string TexturePath;
    private const string DataPath;
    public Texture2DArray RuntimeTextureArray => _runtimeTextureArray;
    public Vector2Int StartIndex => _startIndex;

    public Coroutine BuildTextureArrayAsync(Action<Texture2DArray> onComplete = null);
    private IEnumerator BuildTextureArrayRoutine(Action<Texture2DArray> onComplete);
    private static bool TryGetArrayParams(List<MaskModificationData> modifications, out int width, out int height, out TextureFormat format);
    private static bool TryCopySlice(Texture2DArray array, int index, MaskModificationData modification, int width, int height, TextureFormat format);
    private bool IsValid();
    public float GetWorldStep();
    public float GetModificationSize();
    public float ConvertModificationSizeToWorldUnits(EModificationSize size);
    public int GetSizeInTexels();
    public int GetMaxSizeInTexels();
    private Vector3 GetMaskOrigin();
    public Vector2Int CalculateStartIndex();
    public Vector3 GetSnappedCenter(Vector2Int startIndex);
    [ContextMenu("Snap Transform To Grid")]
    public void SnapTransformToGrid();
    private void OnDrawGizmos();
}