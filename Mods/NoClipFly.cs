using UnityEngine;

public class FlyingController : MonoBehaviour
{
    public static float flyingSpeed = 15f;
    public static float noCollisionRadius = 5f;
    private static bool isFlying = false;

    public static void NoClipFly()
    {
        if (ControllerInputPoller.instance.rightControllerPrimaryButton)
        {
            isFlying = true;

            GorillaTagger.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * flyingSpeed;
            GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;

            Collider[] allColliders = GameObject.FindObjectsOfType<Collider>();
            foreach (Collider collider in allColliders)
            {
                collider.enabled = false;
            }
        }
        else if (isFlying)
        {
            isFlying = false;

            Collider[] allColliders = GameObject.FindObjectsOfType<Collider>();
            foreach (Collider collider in allColliders)
            {
                collider.enabled = true;
            }
        }
    }
}
