using UnityEngine;

public class EnemyManager : MonoBehaviour {
        private int _healthpoints;

        private void Awake() {
                _healthpoints = 30;
        }

        public bool TakeHit() {
                _healthpoints -= 10;
                Debug.Log(_healthpoints + " / 30");
                bool isDead = _healthpoints <= 0;
                if (isDead) _Die();
                return isDead;
        }

        private void _Die() {
                Destroy(gameObject);
        }
}