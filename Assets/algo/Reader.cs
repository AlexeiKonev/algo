using UnityEngine;

namespace Assets.algo
{
    public class Reader : MonoBehaviour
    {
        public Texture2D image; // Ссылка на черно-белую картинку
        public GameObject pixelPrefab; // Префаб игрового объекта для каждого пикселя

        void Start()
        {
            int width = image.width;
            int height = image.height;
            Read(width, height);
        }

        private void Read(int width, int height)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);

                    // Проверка, является ли цвет черным (близким к черному)
                    if (pixelColor.r <= 0.1f && pixelColor.g <= 0.1f && pixelColor.b <= 0.1f)
                    {
                        // Создание игрового объекта для пикселя
                        GameObject pixel = Instantiate(pixelPrefab, new Vector3(x, y, 0), Quaternion.identity);
                        // Установка цвета пикселя
                        pixel.GetComponent<Renderer>().material.color = pixelColor;
                        // Установка слоя "wall" для игрового объекта
                        pixel.layer = LayerMask.NameToLayer("wall");
                        // Родительский объект для пикселя
                        pixel.transform.parent = transform;
                    }
                }
            }

        }
    }

}
