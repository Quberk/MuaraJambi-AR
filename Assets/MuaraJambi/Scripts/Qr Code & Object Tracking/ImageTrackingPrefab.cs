using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;
using UnityEngine.UI;

namespace MuaraJambi
{
    namespace QrCodeObjectTracking
    {
        [RequireComponent(typeof(ARTrackedImageManager))]
        public class ImageTrackingPrefab : MonoBehaviour
        {
            /*
            [Header("The length of this list must match the number of images in Reference Image Library")]
            public List<GameObject> ObjectsToPlace;

            private int refImageCount;
            private Dictionary<string, GameObject> allObjects;
            private ARTrackedImageManager arTrackedImageManager;
            private IReferenceImageLibrary refLibrary;

            private bool alreadyTrackingObject;

            void Awake()
            {
                arTrackedImageManager = GetComponent<ARTrackedImageManager>();
            }

            private void OnEnable()
            {
                arTrackedImageManager.trackedImagesChanged += OnImageChanged;
            }

            private void OnDisable()
            {
                arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
            }

            private void Start()
            {
                refLibrary = arTrackedImageManager.referenceLibrary;
                refImageCount = refLibrary.count;
                LoadObjectDictionary();
            }

            void LoadObjectDictionary()
            {
                allObjects = new Dictionary<string, GameObject>();
                for (int i = 0; i < refImageCount; i++)
                {
                    allObjects.Add(refLibrary[i].name, ObjectsToPlace[i]);
                    ObjectsToPlace[i].SetActive(false);
                }
            }

            void ActivateTrackedObject(string _imageName)
            {
                allObjects[_imageName].SetActive(true);
            }

            public void OnImageChanged(ARTrackedImagesChangedEventArgs _args)
            {
                if (alreadyTrackingObject == false)
                {
                    alreadyTrackingObject = true;

                    foreach (var addedImage in _args.added)
                    {
                        ActivateTrackedObject(addedImage.referenceImage.name);
                    }

                    foreach (var updated in _args.updated)
                    {
                        allObjects[updated.referenceImage.name].transform.position = updated.transform.position;
                        allObjects[updated.referenceImage.name].transform.rotation = updated.transform.rotation;
                    }
                }


                foreach (var updated in _args.removed)
                {
                    allObjects[updated.referenceImage.name].SetActive(false);
                }
            }*/

            /// <summary>
            /// Yang lama
            /// </summary>

            private ButtonsPopUpController buttonsPopUpController;

            [SerializeField] private GameObject[] placeablePrefabs;

            private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
            private ARTrackedImageManager trackedImageManager;

            

            //private GameObject previousActivePrefab;

            private void Awake()
            {
                buttonsPopUpController = FindObjectOfType<ButtonsPopUpController>();
                trackedImageManager = FindObjectOfType<ARTrackedImageManager>();

                foreach(GameObject prefab in placeablePrefabs)
                {
                    GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
                    newPrefab.name = prefab.name;
                    newPrefab.SetActive(false);
                    spawnedPrefabs.Add(prefab.name, newPrefab);
                }
            }

            private void OnEnable()
            {
                trackedImageManager.trackedImagesChanged += ImageChanged;
            }

            private void OnDisable()
            {
                trackedImageManager.trackedImagesChanged -= ImageChanged;

                //if (previousActivePrefab != null)
                    //spawnedPrefabs[previousActivePrefab.name].SetActive(false);
            }

            private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
            {
                foreach(ARTrackedImage trackedImage in eventArgs.added)
                {
                    buttonsPopUpController.ObjectDetected();
                    UpdateImage(trackedImage, false);
                }
                foreach (ARTrackedImage trackedImage in eventArgs.updated)
                {
                    UpdateImage(trackedImage, true);
                }
                foreach (ARTrackedImage trackedImage in eventArgs.removed)
                {
                    spawnedPrefabs[trackedImage.name].SetActive(false);
                }   
            }

            private void UpdateImage(ARTrackedImage trackedImage, bool justUpdate)
            {
                //previousActivePrefab.SetActive(false);

                string name = trackedImage.referenceImage.name;
                Vector3 position = trackedImage.transform.position;

                if (!justUpdate)
                {
                    GameObject prefab = spawnedPrefabs[name];
                    prefab.transform.position = position;
                    prefab.SetActive(true);
                    prefab.transform.localScale = new Vector3(0.001992446f, 0.001992446f, 0.001992446f);
                    //previousActivePrefab = prefab;
                }


                foreach (GameObject go in spawnedPrefabs.Values)
                {
                    if (go.name != name)
                    {
                        go.SetActive(false);
                    }
                }
            }
            
        }

        [System.Serializable]
        public class ObjectStats
        {
            public Image objectImage;



            public string kontenSejarahContent;
            public string faktaUnikContent;
            public string spesifikasiCandiContent;

        }
    }
}
