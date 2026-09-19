using System.Collections;
using System.IO;
using ScheduleOne.Core;
using ScheduleOne.Development;
using UnityEngine;

namespace ScheduleOne.Experimental.DanceCompositor;
public class DanceCompositor : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private ComputeShader _compositorShader;
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private AnimationClip _danceClip;
    [SerializeField]
    private DevTesting _devTesting;
    [Header("Settings")]
    [SerializeField]
    private string _savePath;
    [SerializeField]
    private string _fileName;
    [Header("Grid & Resolution")]
    [Tooltip("The width of a single frame (and the Camera's render resolution)")]
    [SerializeField]
    private int _tileWidth;
    [Tooltip("The height of a single frame (e.g., 512 for a 1:2 ratio)")]
    [SerializeField]
    private int _tileHeight;
    [SerializeField]
    private int _columns;
    [SerializeField]
    private int _rows;
    [Header("Animation")]
    [Tooltip("The exact name of the state in the Animator playing the dance clip")]
    [SerializeField]
    private string _animatorStateName;
    [Header("Textures (Debug)")]
    [SerializeField]
    private RenderTexture _cameraTexture;
    [SerializeField]
    private RenderTexture _textureMap;
    private int _kernelID;
    private void Start();
    private void Initialise();
    [Button]
    public void StartCompositing();
    private IEnumerator RunComposite();
    private void CreateSlice(int x, int y);
    private Texture2D RenderTextureToTexture2D(RenderTexture source);
    private void SaveTextureAsPNG(Texture2D tex, string name);
}