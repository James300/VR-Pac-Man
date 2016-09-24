using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class Pulse : MonoBehaviour
    {
        private const float MinAlpha = 0f;
        private const float MaxAlpha = .15f;

        public Image Image;
        public Color Color;
        public static float PowerTime = 10f;
        public float PulseTime = 1f;

        private Color _maxAlpha;
        private Color _minAlpha;

        private static bool _powered;
        private static float _powerLeft;

        void Start ()
        {
            _maxAlpha = new Color(Color.r, Color.g, Color.b, MaxAlpha);
            _minAlpha = new Color(Color.r, Color.g, Color.b, MinAlpha);
        }

        void Update ()
        {
            if(_powerLeft < 0)
            {
                _powered = false;
            }
            else if(_powerLeft < 3f)
            {
                PulseTime = .5f;
            }
            else
            {
                PulseTime = 1f;
            }

            if(_powered)
            {
                Image.color = Color.Lerp(_minAlpha, _maxAlpha, Mathf.PingPong(Time.time, PulseTime));
            }
            else
            {
                Image.color = _minAlpha;
            }

            _powerLeft -= Time.deltaTime;
        }

        public static void PowerUp()
        {
            _powerLeft = PowerTime;
            _powered = true;
        }

        public static bool GetPowered()
        {
            return _powered;
        }
    }
}