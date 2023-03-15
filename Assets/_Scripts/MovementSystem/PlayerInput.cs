using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class PlayerInput : MonoBehaviour
{
    private Movement _movement;
    private WeaponHolder _weaponHolder;
    private Camera _cam;
    
    // Start is called before the first frame update
    void Start()
    {
        _weaponHolder = GetComponentInChildren<WeaponHolder>();
        _movement = GetComponent<Movement>();
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        _movement.MoveInDirection(new Vector2(horizontal,vertical));
        
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        _movement.RotateTowards(mousePos);

        if (Input.GetMouseButton(0))
        {
            _weaponHolder.Fire();
        }
    }
}
