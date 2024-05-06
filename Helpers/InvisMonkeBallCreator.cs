using PinkMenu.Helpers;
using UnityEngine;

namespace StupidTemplate.Helpers.InvisMonkeBallCreator
{
    internal class InvisMonkeBallCreator
    {
        private static GameObject createdBall1;
        private static GameObject createdBall2;

        public static GameObject CreateInvisMonkeBall()
        {
            createdBall1 = CreateBall();
            createdBall2 = CreateBall();
            return createdBall1;
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

        public static GameObject GetCreatedBall1()
        {
            return createdBall1;
        }

        public static GameObject GetCreatedBall2()
        {
            return createdBall2;
        }
    }
}
