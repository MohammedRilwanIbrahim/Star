using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{

    [SerializeField] private LineRenderer _lineRender;

    private Vector3 _previousPosition;

    [SerializeField] private float minDistance = 0.1f;


    private float _pullDistance;

    private float _pullAngle;


    //Settin Initial y position to -3 
    private void Awake()
    {
        transform.position = new Vector3(0, -3, 0);
        
    }

    private void Start()
    {
        _lineRender.positionCount = 1;

        _previousPosition = transform.position;

       
    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 currrentMousePosition = Camera.main.ScreenToWorldPoint(mousePos);
        currrentMousePosition.z = 10f;

        if (Input.GetMouseButtonDown(0))
        {
            _lineRender.SetPosition(0, transform.position);
            
            // calculating the distance between GameObject and mouse poisition in the world space
            _pullDistance = Vector3.Distance(gameObject.transform.position, currrentMousePosition);


            // Calculating the Angle from star game object to mouse poisition
            _pullAngle = Vector3.Angle (gameObject.transform.position , currrentMousePosition);


            _pullDistance = Mathf.Clamp(_pullDistance, 0f, minDistance);

           


        }

    }
}
