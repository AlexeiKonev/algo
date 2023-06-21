using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.algo
{
    public class ClickablePixel : MonoBehaviour
    {
        public GameObject pixelObject; // Ссылка на игровой объект пикселя

        void OnMouseDown()
        {
            Renderer renderer = pixelObject.GetComponent<Renderer>();
            Color pixelColor = renderer.material.color;

            // Изменение цвета пикселя при клике
            if (pixelColor.r <= 0.1f && pixelColor.g <= 0.1f && pixelColor.b <= 0.1f)
            {
                renderer.material.color = Color.white;
                gameObject.layer = LayerMask.NameToLayer("Default");
            }
            else
            {
                renderer.material.color = Color.black;
                gameObject.layer = LayerMask.NameToLayer("wall");
            }
        }
    }
}
 





 