using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CheckpointStorage
{
    public static Vector3 CheckpointLocation { get; private set; }
    public static string CheckpointScene { get; private set; }
    public static void SetCheckpoint(Checkpoint checkpoint)
    {
        CheckpointLocation = checkpoint.gameObject.transform.position;
        CheckpointScene = SceneChanger.CurrentScene;
    }
}
