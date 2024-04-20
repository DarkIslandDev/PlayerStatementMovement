﻿using UnityEngine;

public enum RoomType
{
    Default,
    SafeRoom,
    MonsterRoom,
    BossRoom,
    TreasureRoom,
    MerchantsRoom
}

public class RoomNode : Node
{
    [SerializeField] protected bool spawnNode;
    [SerializeField] protected RoomType roomType;
    
    protected GameObject torchParent;
    
    public bool SpawnNode
    {
        get => spawnNode;
        set => spawnNode = value;
    }

    public RoomType RoomType
    {
        get => roomType;
        set => roomType = value;
    }

    public GameObject TorchParent
    {
        get => torchParent;
        set => torchParent = value;
    }

    public RoomNode() : base(null)
    {
    }

    public RoomNode(Vector2Int bottomLeftAreaCorner, Vector2Int topRightAreaCorner, Node parentNode, int index) :
        base(parentNode)
    {
        BottomLeftAreaCorner = bottomLeftAreaCorner;
        TopRightAreaCorner = topRightAreaCorner;
        BottomRightAreaCorner = new Vector2Int(topRightAreaCorner.x, bottomLeftAreaCorner.y);
        TopLeftAreaCorner = new Vector2Int(bottomLeftAreaCorner.x, topRightAreaCorner.y);
        TreeLayerIndex = index;
    }
}