using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RangedAttack : MonoBehaviour, IAttack
{
    [SerializeField] GameObject origin,arrow, child;
    float arrowSpeed;
    public RangedAttack(GameObject origin,GameObject arrow,float speed)
    {
        this.arrow = arrow;
        this.arrowSpeed = speed;
        this.origin = origin;
    }
    public void Attack()
    {
        child = Instantiate(arrow, origin.transform.position, Quaternion.Euler(0f,0f, Mathf.Acos(origin.transform.localScale.x) * Mathf.Rad2Deg), null);
        child.GetComponent<Arrow>().Speed = arrowSpeed;
        Debug.Log("Ranged attack");
    }
}
