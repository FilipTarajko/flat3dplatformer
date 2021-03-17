using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPlayer : MonoBehaviour
{
    private GameObject target = null;
    private Vector3 offset;
    void Start()
    {
        target = null;
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            col.gameObject.TryGetComponent<Player>(out Player player);
            target = player.playerParent.gameObject;
            offset = target.transform.position - transform.position;
        }    
    }
    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            target = null;
        }
    }
    void FixedUpdate()
    {
        if (target != null)
        {
            target.transform.position = transform.position + offset;
        }
    }
}
