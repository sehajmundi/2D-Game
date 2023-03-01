using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {
    [SerializeField] protected float _maxHitPoints = 10;
    [SerializeField] protected float _startingHitPoints = 5;
    public CharacterCategory characterCategory;

    public float MaxHitPoints {
        get {
            return _maxHitPoints;
        }
        set {
            _maxHitPoints = value;
        }
    }

    public enum CharacterCategory{
        Player,
        Enemy
    }
    public virtual void KillCharacter() {
        Destroy(gameObject);
    }

    public abstract void ResetCharacter();
    
    public abstract IEnumerator DamageCharacter(int damage, float interval);

    public virtual IEnumerator FlickerCharacter() {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}