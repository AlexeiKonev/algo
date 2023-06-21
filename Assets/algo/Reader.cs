using UnityEngine;

namespace Assets.algo
{
    public class Reader : MonoBehaviour
    {
        public Texture2D image; // ������ �� �����-����� ��������
        public GameObject pixelPrefab; // ������ �������� ������� ��� ������� �������

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

                    // ��������, �������� �� ���� ������ (������� � �������)
                    if (pixelColor.r <= 0.1f && pixelColor.g <= 0.1f && pixelColor.b <= 0.1f)
                    {
                        // �������� �������� ������� ��� �������
                        GameObject pixel = Instantiate(pixelPrefab, new Vector3(x, y, 0), Quaternion.identity);
                        // ��������� ����� �������
                        pixel.GetComponent<Renderer>().material.color = pixelColor;
                        // ��������� ���� "wall" ��� �������� �������
                        pixel.layer = LayerMask.NameToLayer("wall");
                        // ������������ ������ ��� �������
                        pixel.transform.parent = transform;
                    }
                }
            }

        }
    }

}
