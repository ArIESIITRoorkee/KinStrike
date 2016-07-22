using UnityEngine;
using System.Collections;

public class KinectOverlayer : MonoBehaviour 
{
//	public Vector3 TopLeft;
//	public Vector3 TopRight;
//	public Vector3 BottomRight;
//	public Vector3 BottomLeft;
	private KinectWrapper.NuiSkeletonPositionIndex TrackedJoint = KinectWrapper.NuiSkeletonPositionIndex.HandRight;
    private KinectWrapper.NuiSkeletonPositionIndex TrackedJoint2 = KinectWrapper.NuiSkeletonPositionIndex.HandLeft;
    public GameObject Sphere;
    public GameObject Sphere2;
    public float smoothFactor = 5f;
	private float distanceToCamera = 10f;
    private float distanceToCamera2 = 10f;


    void Start()
	{

        if (Sphere2 && Sphere)
		{
			distanceToCamera = (Sphere.transform.position - Camera.main.transform.position).magnitude;
            distanceToCamera2 = (Sphere2.transform.position - Camera.main.transform.position).magnitude;
        }
    }
	
	void Update() 
	{	

		KinectManager manager = KinectManager.Instance;
		
		if (manager && manager.IsInitialized ()) {
//			Vector3 vRight = BottomRight - BottomLeft;
//			Vector3 vUp = TopLeft - BottomLeft;
			
			int b = (int)TrackedJoint;
            int a = (int)TrackedJoint2;
            if (manager.IsUserDetected ()) {
				uint userId = manager.GetPlayer1ID ();
				
				if (manager.IsJointTracked (userId, b) && manager.IsJointTracked(userId, a)) {
					Vector3 B = manager.GetRawSkeletonJointPos (userId, b);
                    Vector3 A = manager.GetRawSkeletonJointPos(userId, a);
                    Vector3 posJoint = new Vector3(4.3f * A.x - 3.3f * B.x, 4.3f * A.y - 3.3f * B.y, 4.3f * A.z - 3.3f * B.z);

                    if (posJoint != Vector3.zero) {
						// 3d position to depth
						Vector2 posDepth = manager.GetDepthMapPosForJointPos (posJoint);
						
						// depth pos to color pos
						Vector2 posColor = manager.GetColorMapPosForDepthPos (posDepth);
						
						float scaleX = ((float)posColor.x / KinectWrapper.Constants.ColorImageWidth);
						float scaleY = 0.85f * (1.0f - (float)posColor.y / KinectWrapper.Constants.ColorImageHeight);

						float scaleX2 = ((float)posColor.x / KinectWrapper.Constants.ColorImageWidth);
						float scaleY2 = 0.85f * (1.0f - (float)posColor.y / KinectWrapper.Constants.ColorImageHeight);

						//						Vector3 localPos = new Vector3(scaleX * 10f - 5f, 0f, scaleY * 10f - 5f); // 5f is 1/2 of 10f - size of the plane
						//						Vector3 vPosOverlay = backgroundImage.transform.TransformPoint(localPos);
						//Vector3 vPosOverlay = BottomLeft + ((vRight * scaleX) + (vUp * scaleY));

						if (Sphere2 && Sphere) {
							Vector3 vPosOverlay = Camera.main.ViewportToWorldPoint (new Vector3 (scaleX, scaleY, distanceToCamera));
							Vector3 vPosOverlay2 = Camera.main.ViewportToWorldPoint (new Vector3 (scaleX2, scaleY2, distanceToCamera2));

							Sphere.transform.position = Vector3.Lerp (Sphere.transform.position, vPosOverlay, smoothFactor * Time.deltaTime);
							Sphere2.transform.position = Vector3.Lerp (Sphere2.transform.position, vPosOverlay2, smoothFactor * Time.deltaTime);
						}
					}
				}
				
			}
			
		}


	}
    
}
