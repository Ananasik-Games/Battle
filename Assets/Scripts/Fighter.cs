using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] private Slider _healthBar;
        [SerializeField] private TMP_Text _phisicalDamageResistanceText, _magicDamageResistanceText;
        [SerializeField] private string _name;
        public enum TypesDamage { Phisical, Magical }
        [field: SerializeField] public TypesDamage TypeDamage;
        [field: SerializeField] public int Damage { get; private set; }
        [SerializeField] private int _maxHealth;
        [SerializeField] private float _phisicalDamageResistance, _magicDamageResistance;
        private int _currentHealth, _maxDamage, _minDamage;
        readonly System.Random rand = new();

        private void Start()
        {
            _currentHealth = _maxHealth;
            _healthBar.maxValue = _maxHealth;
            _healthBar.value = _maxHealth;
            if (_phisicalDamageResistanceText != null) { _phisicalDamageResistanceText.text = Convert.ToString(_phisicalDamageResistance) + "%"; }
            if (_magicDamageResistanceText != null) { _magicDamageResistanceText.text = Convert.ToString(_magicDamageResistance) + "%"; }
        }

        public void TakeDamage(int damage, TypesDamage typeDamage)
        {
            //Count Damage
            float damageFloat = damage;
            _maxDamage = damage + Convert.ToInt32(damageFloat * 0.25f);
            damageFloat = damage;
            _minDamage = damage - Convert.ToInt32(damageFloat * 0.25f);
            damage = rand.Next(_minDamage, _maxDamage);
            damageFloat = damage;
            //
            switch (typeDamage)
            {
                case TypesDamage.Phisical: _currentHealth -= Convert.ToInt32(damage * _phisicalDamageResistance / 100); break;
                case TypesDamage.Magical: _currentHealth -= Convert.ToInt32(damage * _magicDamageResistance / 100); break;
            }
            //Update Health Bar value
            _healthBar.value = _currentHealth;
        }
    }
}