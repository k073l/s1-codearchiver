using System.Collections;
using System.IO;
using UnityEngine;

namespace ScheduleOne.Experimental.TreeCompositor;
public class TreeCompositor : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private ComputeShader _compositorShader;
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private RenderTexture _cameraTexture;
    [SerializeField]
    private Transform _treePivot;
    [SerializeField]
    private Transform _treeStandard;
    [SerializeField]
    private Transform _treeNormal;
    [SerializeField]
    private Transform _treeMask;
    [Header("Settings")]
    [SerializeField]
    private string _savePath;
    [SerializeField]
    private int _resolution;
    [SerializeField]
    private int _columns;
    [SerializeField]
    private int _rows;
    [Header("Debug")]
    [SerializeField]
    private RenderTexture _textureMap;
    [SerializeField]
    private RenderTexture _normalMap;
    [SerializeField]
    private RenderTexture _maskMap;
    private int _kernelID;
    private float _rotationAngle;
    private void Start();
    private void Initialise();
    private IEnumerator RunComposite();
    private void Composite();
    private void CreateSlice(int x, int y);
    private Texture2D RenderTextureToTexture2D(RenderTexture source);
    private void SaveTextureAsPNG(Texture2D tex, string name);
}