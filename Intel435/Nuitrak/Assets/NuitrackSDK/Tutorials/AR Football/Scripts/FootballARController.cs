using System.Collections;
using System.Collections.Generic;
using GoogleARCore;
using UnityEngine;
using UnityEngine.Networking;

public class FootballARController : MonoBehaviour {

    // После того, как ArCore находит точки в реальном мире, за которые может зацепиться (anchor), камера начинает перемещаться по сцене
    public Camera mainCamera;

    // A model to place when a raycast from a user touch hits a plane.
    Environment environment;

    // A gameobject parenting UI for displaying the "searching for planes" snackbar.
    // Сообщение о поиске поверхностей 
    public GameObject searchingForPlaneUI;

    // The rotation in degrees need to apply to model when model is placed.
    private const float modelRotation = 180.0f; // поворачиваем, чтобы environment был повернут лицевой стороной к камере

    // A list to hold all planes ARCore is tracking in the current frame. 
    // This object is used across the application to avoid per-frame allocations.
    private List<DetectedPlane> allPlanes = new List<DetectedPlane>();

    [SerializeField] Transform aRCoreDevice; // должен быть родителем камеры 

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        // Hide snackbar when currently tracking at least one plane.
        // Получаем список найденных поверхностей
        Session.GetTrackables<DetectedPlane>(allPlanes);
        bool showSearchingUI = true;
        for (int i = 0; i < allPlanes.Count; i++)
        {
            //Если хотя бы одна поверхность трекается, то поиск прекращается
            if (allPlanes[i].TrackingState == TrackingState.Tracking)
            {
                showSearchingUI = false;
                break;
            }
        }

        // Убираем или показываем надпись "Searching for surfaces..."
        searchingForPlaneUI.SetActive(showSearchingUI);

        // If the player has not touched the screen, we are done with this update.
        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        // Raycast against the location the player touched to search for planes.
        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
        TrackableHitFlags.FeaturePointWithSurfaceNormal;

        environment = FindObjectOfType<Environment>();

        // Пускаем луч к поверхности, которую нашёл ArCore
        if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
        {
            // Use hit pose and camera pose to check if hittest is from the
            // back of the plane, if it is, no need to create the anchor.
            if ((hit.Trackable is DetectedPlane) &&
                 Vector3.Dot(mainCamera.transform.position - hit.Pose.position,
                       hit.Pose.rotation * Vector3.up) < 0)
            {
                Debug.Log("Hit at back of the current DetectedPlane");
            }
            else
            {
                // Если луч ударился в правильную (не обратную) часть поверхности, то сразу проверяем, нет ли по пути ворот.  Если поверхность "пустая", то ставим ворота на неё. Если по пути встречаются ворота, то "пинаем мяч"
                if (KickBall() == false && environment)
                {
                    environment.transform.position = hit.Pose.position;
                    environment.transform.rotation = hit.Pose.rotation;
                    environment.transform.Rotate(0, modelRotation, 0, Space.Self);
                }
            }
        }
        else
        {
            // Если по пути луча нет ArCore поверхностей, но есть ворота, то "пинаем мяч"
            KickBall();
        }
    }
    // Если можно пнуть мяч, то пинаем и возвращаем true, если нет, то возвращаем false
    bool KickBall()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitRay;

        //Пускаем стандартный луч Unity
        if (Physics.Raycast(ray, out hitRay, 100) && environment)
        {
            //Отправляем сообщение о "пинке" на сервер
            mainCamera.transform.parent = environment.transform; //Временно делаем камеру дочерним объектом для нашего "окружения". Это нужно чтобы получить её локальные координаты относительно игрового объекта "Окружение" (GameObject environment)
            environment.aim.position = hitRay.point;
            FindObjectOfType<PlayerController>().Kick(mainCamera.transform.localPosition, environment.aim.transform.localPosition);

            mainCamera.transform.parent = aRCoreDevice.transform; //возвращаем камеру обратно
            return true;
        }
        return false;
    }
}
