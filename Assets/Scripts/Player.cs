using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : Character{

    [SerializeField] private HealthBar _healthBarPrefab;
    private HealthBar _healthBar;
    [SerializeField] Inventory _inventoryPrefab;
    private Inventory _inventory;
    [SerializeField] protected HitPoints _hitPoints;
    [SerializeField] private PowerUp powerUpPrefab;
    private PowerUp powerUp;
    public float kills;

    public override void ResetCharacter() {
        _inventory = Instantiate(_inventoryPrefab);
        _healthBar = Instantiate(_healthBarPrefab);
        _healthBar.Character = this;
        _hitPoints.Value = _startingHitPoints;
    }
    private void OnEnable() {
        ResetCharacter();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.CompareTag("PickUp")) {
            ItemData hitObject = collision.gameObject.GetComponent<Consumable>().Item;
            if (hitObject != null) {
                print("Hit: " + hitObject.ObjectName);
                bool shouldDisappear = false;
                switch (hitObject.Type) {
                    case ItemData.ItemType.Coin:
                    shouldDisappear = _inventory.AddItem(hitObject);
                    break;
                    case ItemData.ItemType.PowerUp:
                    shouldDisappear = PowerUp();
                    break;
                    case ItemData.ItemType.Health:
                    shouldDisappear = AdjustHitPoints(hitObject.Quantity);
                    break;
                }
                if (shouldDisappear)
                collision.gameObject.SetActive(false);
            }
        }
    }
    public bool AdjustHitPoints(int amount) {
        if (_hitPoints.Value < _maxHitPoints) {
            if(amount == 10)
            {
                _hitPoints.Value = amount;
            }
            else
            {
                _hitPoints.Value = _hitPoints.Value + amount;
            }
            print("Adjusted HP by: " + amount + ". New value: " + _hitPoints.Value);
            return true;
        }
        return false;
    }

    public bool PowerUp() {
        StartCoroutine(stopPowerUp());
        return true;
    }

    public IEnumerator stopPowerUp()
    {
        powerUp = Instantiate(powerUpPrefab);
        yield return new WaitForSeconds(5);
        Destroy(powerUp.gameObject);
    }

    public override IEnumerator DamageCharacter(int damage, float interval){
        while (true) {
            StartCoroutine(FlickerCharacter());
            _hitPoints.Value = _hitPoints.Value - damage;
            if (_hitPoints.Value <= float.Epsilon) {
                KillCharacter();
                break;
            }
            if (interval > float.Epsilon) {
                yield return new WaitForSeconds(interval);
            }
            else {
                break;
            }
        }
    }
    public override void KillCharacter() {
        base.KillCharacter();
        Destroy(_healthBar.gameObject);
        Destroy(_inventory.gameObject);
    }
    public void killCount()
    {
        kills++;
    }
}


