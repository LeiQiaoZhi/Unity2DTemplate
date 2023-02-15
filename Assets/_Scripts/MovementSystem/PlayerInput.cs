using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class PlayerInput : MonoBehaviour
{
    private Movement _movement;
    private WeaponHolder _weaponHolder;
    
    // Start is called before the first frame update
    void Start()
    {
        _weaponHolder = GetComponentInChildren<WeaponHolder>();
        _movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        _movement.MoveInDirection(new Vector2(horizontal,vertical));
        
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _movement.RotateTowards(mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            _weaponHolder.Fire();
        }
    }
}
