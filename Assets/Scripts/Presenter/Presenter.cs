using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presenter : MonoBehaviour
{ 

    public void UnitMove(GameObject enemyObject, Vector2 endPosition, Rigidbody2D unitRigidbody)
    {
        Vector2 movement = Vector2.MoveTowards(enemyObject.transform.position, endPosition, 20f * Time.deltaTime);
        unitRigidbody.MovePosition(movement);
    }

    public void UnitGetSprite(Unit unit)
    {
        unit.SpriteRenderer = unit.GetComponent<SpriteRenderer>();
    }

    public void FlipSpriteLeft(Unit unit)
    {
        unit.SpriteRenderer.flipX = true;
    }

    public void FlipSpriteRight(Unit unit)
    {
        unit.SpriteRenderer.flipX = false;
    }
}
