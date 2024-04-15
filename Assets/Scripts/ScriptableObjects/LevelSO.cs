using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level")]
public class LevelSO : ScriptableObject
{
    public string SceneName;
    public bool HasEnemies;
    public bool HasTraps;
    public bool HasBoss;
}
