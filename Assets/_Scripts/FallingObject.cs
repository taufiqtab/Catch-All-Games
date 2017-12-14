using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Egg,
    Bomb
}

public class FallingObject : MonoBehaviour {

    public ObjectType type;
    public int effectAmount;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(type == ObjectType.Egg)
            {
                GamesManager.Instance.AddScore(effectAmount);
                Destroy(this.gameObject);
            }
            else if(type == ObjectType.Bomb)
            {
                GamesManager.Instance.DecreaseLives(effectAmount);
                Destroy(this.gameObject);
            }
        }

        if(collision.gameObject.tag == "Cleaner")
        {
            Destroy(this.gameObject);
        }
    }
}
