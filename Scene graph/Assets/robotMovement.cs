using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotMovement : MonoBehaviour
{
    public GameObject shoulderR;
    public GameObject shoulderL;

    public GameObject armR;
    public GameObject armL;
    
    public GameObject lowerArmR;
    public GameObject lowerArmL;
    
    public GameObject femurR;
    public GameObject femurL;
    
    public GameObject tibiaR;
    public GameObject tibiaL;
    
    public GameObject footR;
    public GameObject footL;
    
    
    public bool phase1 = true;
    public bool phase2 = true;
    public bool phase3 = true;
    public bool phase4 = true;
    
    private float _speed = 40.0f;
    private const float MinRotation = -20.0f;
    private const float MaxRotation = 20.0f;

    private float _currentRotation;
    
    private bool validRotatrionReset = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (phase1)
        // {
            if (transform.position.x < 15)
            {
                Move();
                ShoulderMovement();
                LegMovement();
                FeetMovement();
            }
            else if (transform.position.x >= 15 && validRotatrionReset)
            {
                ResetShoulderRotation();
                ResetLegRotation();
                validRotatrionReset = false;
            }
            phase1 = false;
        // }

        // if (phase2)
        // {
        //     
        // }
    }

    // private void FeetMovement()
    // {
    //     var dt = Time.deltaTime;
    //     var x1 = _currentRotation + _speed*dt;
    //     if (x1 > MaxRotation )
    //         _speed = -1 * Mathf.Abs(_speed);
    //     else if (x1 < MinRotation)
    //         _speed = Mathf.Abs(_speed);
    //     _currentRotation += _speed*dt;
    //     femurR.transform.localRotation = Quaternion.AngleAxis(_currentRotation, Vector3.forward);
    //     femurL.transform.localRotation = Quaternion.AngleAxis(_currentRotation, Vector3.back);
    // }
    
    private void ShoulderMovement()
    {
        var dt = Time.deltaTime;
        var x1 = _currentRotation + _speed*dt;
        if (x1 > MaxRotation)
            _speed = -1 * Mathf.Abs(_speed);
        else if (x1 < MinRotation)
            _speed = Mathf.Abs(_speed);
        _currentRotation += _speed*dt;
        shoulderR.transform.localRotation = Quaternion.AngleAxis(_currentRotation, Vector3.forward);
        shoulderL.transform.localRotation = Quaternion.AngleAxis(_currentRotation, Vector3.back);
        
        lowerArmR.transform.localRotation = Quaternion.AngleAxis(_currentRotation/4, Vector3.forward);
        lowerArmL.transform.localRotation = Quaternion.AngleAxis(_currentRotation/4, Vector3.back);

    }

    private void LegMovement()
    {
        var MaxRotationLeg = MaxRotation + 5;
        var MinRotationLeg = MinRotation - 5;
        var dt = Time.deltaTime;
        var x1 = _currentRotation + _speed * dt;
        if (x1 > MaxRotationLeg)
            _speed = -1 * Mathf.Abs(_speed);
        else if (x1 < MinRotationLeg)
            _speed = Mathf.Abs(_speed);
        femurL.transform.localRotation = Quaternion.AngleAxis(_currentRotation, Vector3.forward);
        femurR.transform.localRotation = Quaternion.AngleAxis(_currentRotation, Vector3.back);
        
    }

    private void FeetMovement()
    {
        var MasxRotationFeet = MaxRotation - 10;
        var MinRotationFeet = MinRotation + 13;
        var dt = Time.deltaTime;
        var x1 = _currentRotation + _speed * dt;
        if (x1 > MasxRotationFeet)
            _speed = -1 * Mathf.Abs(_speed);
        else if (x1 < MinRotationFeet)
            _speed = Mathf.Abs(_speed);
        footL.transform.localRotation = Quaternion.AngleAxis(_currentRotation, Vector3.back);
        footR.transform.localRotation = Quaternion.AngleAxis(_currentRotation, Vector3.forward);
    }

    private void ResetFootRotation()
    {
        _currentRotation = 0f;
        footR.transform.localRotation = Quaternion.identity;
        footL.transform.localRotation = Quaternion.identity;
    }
    
    private void ResetLegRotation()
    {
        _currentRotation = 0f;
        femurR.transform.localRotation = Quaternion.identity;
        femurL.transform.localRotation = Quaternion.identity;
    }

    private void ResetShoulderRotation()
    {
        _currentRotation = 0f;
        shoulderR.transform.localRotation = Quaternion.identity;
        shoulderL.transform.localRotation = Quaternion.identity;
        lowerArmR.transform.localRotation = Quaternion.identity;
        lowerArmL.transform.localRotation = Quaternion.identity;
    }
    
    private void Move()
    {

        transform.Translate(-1 * Time.deltaTime, 0, 0);
    }
}
