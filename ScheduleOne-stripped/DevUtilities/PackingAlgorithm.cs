using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.ItemFramework;
using UnityEngine;

namespace ScheduleOne.DevUtilities;
public class PackingAlgorithm : Singleton<PackingAlgorithm>
{
    [Serializable]
    public class Rectangle
    {
        public string name;
        public int sizeX;
        public int sizeY;
        public bool flipped;
        public int actualSizeX { get; }
        public int actualSizeY { get; }

        public Rectangle(string _name, int x, int y);
    }

    public class StoredItemData : Rectangle
    {
        public ItemInstance item;
        public int xPos;
        public int yPos;
        public float rotation { get; }

        public StoredItemData(string _name, int x, int y, ItemInstance _item);
    }

    public class Coordinate
    {
        public int x;
        public int y;
        public Rectangle occupant;
        public Coordinate(int _x, int _y);
    }

    public List<Rectangle> rectsToPack;
    public List<StoredItemData> PackItems(List<ItemInstance> datas, int gridX, int gridY);
    public List<StoredItemData> AttemptPack(List<StoredItemData> rects, int gridX, int gridY);
    private bool DoesCoordinateHaveOccupiedAdjacent(Coordinate[, ] grid, Coordinate coord, int gridX, int gridY);
    private bool IsCoordinateInBounds(Coordinate coord, int gridX, int gridY);
    private void PrintGrid(Coordinate[, ] grid, int gridX, int gridY);
    private int GetRegionSize(Coordinate[, ] grid, int gridX, int gridY);
    private Coordinate TransformCoordinatePoint(Coordinate[, ] grid, Coordinate baseCoordinate, Coordinate offset, int gridX, int gridY);
}