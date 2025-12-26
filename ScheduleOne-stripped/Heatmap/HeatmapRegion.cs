using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Heatmap;
public class HeatmapRegion : MonoBehaviour
{
    public int _textureIndex;
    private MeshRenderer _renderer;
    public void Create(Grid grid, int textureIndex, Material heatmapMat);
}