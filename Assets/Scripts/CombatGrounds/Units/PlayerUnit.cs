using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    public Action plannedAction;

    private void Awake() {
        plannedAction = new BasicAttack(this);
    }
}
