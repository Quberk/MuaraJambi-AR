using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/// <summary>
/// Listens for touch events and performs an AR raycast from the screen touch point.
/// AR raycasts will only hit detected trackables like feature points and planes.
///
/// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
/// and moved to the hit position.
/// </summary>

namespace MuaraJambi
{
    namespace Markerless
    {
        [RequireComponent(typeof(ARRaycastManager))]
        public class PlaceOnPlane : MonoBehaviour
        {
            private bool deactivating = false;

            [Tooltip("Instantiates this prefab on a plane at the touch location.")]
            public GameObject m_PlacedPrefab;

            UnityEvent placementUpdate;

            [SerializeField]
            GameObject visualObject;

            /// <summary>
            /// The prefab to instantiate on touch.
            /// </summary>
            public GameObject placedPrefab
            {
                get { return m_PlacedPrefab; }
                set { m_PlacedPrefab = value; }
            }

            /// <summary>
            /// The object instantiated as a result of a successful raycast intersection with a plane.
            /// </summary>
            public GameObject spawnedObject { get; private set; }

            [Header("Buttons Activate")]
            [SerializeField] private GameObject nonActiveButtons;
            [SerializeField] private GameObject kontenSejarah_Btn;
            [SerializeField] private GameObject faktaUnik_Btn;
            [SerializeField] private GameObject spesifikasiCandi_Btn;
            [SerializeField] private ContentParameterCatcher contentParameterCatcher; 

            void Awake()
            {
                m_RaycastManager = GetComponent<ARRaycastManager>();

                if (placementUpdate == null)
                    placementUpdate = new UnityEvent();

                placementUpdate.AddListener(DiableVisual);
            }

            bool TryGetTouchPosition(out Vector2 touchPosition)
            {
                if (Input.touchCount > 0)
                {
                    touchPosition = Input.GetTouch(0).position;
                    return true;
                }

                touchPosition = default;
                return false;
            }

            void Update()
            {
                if (deactivating == true)
                    return;

                if (!TryGetTouchPosition(out Vector2 touchPosition))
                    return;

                if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon) && Input.touchCount < 2)
                {
                    // Raycast hits are sorted by distance, so the first one
                    // will be the closest hit.
                    var hitPose = s_Hits[0].pose;

                    if (spawnedObject == null)
                    {
                        spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);
                        spawnedObject.transform.localScale = new Vector3(0.005512986f, 0.005512986f, 0.005512986f);

                        //Activating Buttons
                        nonActiveButtons.SetActive(true);
                        kontenSejarah_Btn.SetActive(true);

                        if (contentParameterCatcher.objectTypes == ObjectTypes.Artefak)
                            faktaUnik_Btn.SetActive(true);
                        else
                            spesifikasiCandi_Btn.SetActive(true);

                        

                    }
                    else
                    {
                        //repositioning of the object 
                        spawnedObject.transform.position = hitPose.position;
                    }
                    
                }

                placementUpdate.Invoke();
            }

            public void DiableVisual()
            {
                visualObject.SetActive(false);
            }

            public void DeactivatingPlaceOnPlane()
            {
                deactivating = true;
            }

            public void ActivatingPlaceOnPlane()
            {
                deactivating = false;
            }

            static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

            ARRaycastManager m_RaycastManager;
        }
    }
}
