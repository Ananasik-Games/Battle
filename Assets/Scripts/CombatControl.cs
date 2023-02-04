using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class CombatControl : MonoBehaviour
    {
        [SerializeField] private Fighter[] _fighters;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) { _fighters[0].TakeDamage(_fighters[1].Damage, _fighters[1].TypeDamage); }
            if (Input.GetKeyDown(KeyCode.Mouse1)) { _fighters[1].TakeDamage(_fighters[0].Damage, _fighters[0].TypeDamage); }
        }
    }
}