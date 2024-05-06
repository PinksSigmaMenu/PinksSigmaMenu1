using PinkMenu.Helpers;
using UnityEngine;

namespace PinkMenu.Managers
{
    internal class BallManager
    {
        private static GameObject createdBall1;
        private static GameObject createdBall2;

        public static GameObject[] GetInvisMonkeBalls()
        {
            return new GameObject[] { CreateBall(), CreateBall() };
        }

        private static GameObject CreateBall()
        {
            GameObject ballObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            ballObject.transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);
            Shader shaderObject = Shader.Find("GUI/Text Shader");
            Material mat = new Material(shaderObject);
            ballObject.GetComponent<Renderer>().material = mat;
            UnityEngine.Object.Destroy(ballObject, 0.50f);
            Collider collider = ballObject.GetComponent<Collider>();
            UnityEngine.Object.Destroy(collider);
            float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
            mat.color = Color.Lerp(SigmaColors.hotPink, SigmaColors.deepPink, pingPongValue);
            return ballObject;
        }
    }
}
