﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyCell : BoardCell
{
    public override void OnObjectPlaced()
    {
        Rigidbody rb = placedObject.GetComponent<Rigidbody>();
        if (rb == null) placedObject.gameObject.AddComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = false;

        if (placedObject.GetNameAsLower() == "laser")
            boardManager.InvokeLevelFailed();
    }

    public override string[] GetArgs()
    {
        return new string[0];
    }
}