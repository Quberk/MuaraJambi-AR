using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MuaraJambi.SplashScreen
{
    public class ObjectManipulationBasedOnPhoneRotation : MonoBehaviour
    {
        [SerializeField] private ObjectManipulationType objectManipulationType;

        [SerializeField] private GameObject objectTarget;

        [SerializeField] private float speed;

        [Header("Rotation Range")]
        [SerializeField] private float xMin;
        [SerializeField] private float xMax;
        [SerializeField] private float yMin;
        [SerializeField] private float yMax;
        [SerializeField] private float zMin;
        [SerializeField] private float zMax;

        // Start is called before the first frame update
        void Start()
        {
            if (SystemInfo.supportsGyroscope)
            {
                Input.gyro.enabled = true;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (SystemInfo.supportsGyroscope)
            {
                if (objectManipulationType == ObjectManipulationType.Rotate)
                    objectTarget.transform.rotation = GyroToQuaternion(Input.gyro.attitude);
                else
                {
                    objectTarget.GetComponent<RectTransform>().localPosition = GyroToPosition(Input.gyro.attitude);

                    //objectTarget.GetComponent<RectTransform>().offsetMin.x
                }
                    
            }


        }

        //Position Change
        private Vector2 GyroToPosition(Quaternion q)
        {
            float xPos = q.x * speed;
            float yPos = q.y * speed;

            float clampedX = Mathf.Clamp(xPos, xMin, xMax);
            float clampedY = Mathf.Clamp(yPos, yMin, yMax);

            return new Vector2(clampedX, clampedY);
        }

        //Rotation Change
        private Quaternion GyroToQuaternion(Quaternion q)
        {
            float xQuaternion = q.x * speed;
            float yQuaternion = q.y * speed;
            float zQuaternion = q.z * speed;

            float clampedX = Mathf.Clamp(xQuaternion, xMin, xMax);
            float clampedY = Mathf.Clamp(yQuaternion, yMin, yMax);
            float clampedZ = Mathf.Clamp(zQuaternion, zMin, zMax);

            return new Quaternion(clampedX, clampedY, clampedZ, 1f);
        }
    }

    public enum ObjectManipulationType
    {
        Rotate,
        Move
    }
}
