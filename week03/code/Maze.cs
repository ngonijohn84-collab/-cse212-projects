
using System;
using System.Collections.Generic;

/// <summary>
/// Defines a maze using a dictionary.
/// Each coordinate maps to four possible movements:
/// [left, right, up, down].
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Move left if there is no wall.
    /// </summary>
    public void MoveLeft()
    {
        if (!_mazeMap[(_currX, _currY)][0])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX--;
    }

    /// <summary>
    /// Move right if there is no wall.
    /// </summary>
    public void MoveRight()
    {
        if (!_mazeMap[(_currX, _currY)][1])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX++;
    }

    /// <summary>
    /// Move up if there is no wall.
    /// </summary>
    public void MoveUp()
    {
        if (!_mazeMap[(_currX, _currY)][2])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currY--;
    }

    /// <summary>
    /// Move down if there is no wall.
    /// </summary>
    public void MoveDown()
    {
        if (!_mazeMap[(_currX, _currY)][3])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currY++;
    }

    /// <summary>
    /// Return the current location in the maze.
    /// </summary>
    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
