using System;
using System.Drawing;

namespace snowfall.Classes
{
    /// <summary>
    /// Класс, представляющий снежинку и ее поведение (падение и вращение).
    /// </summary>
    public class Snowflake
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Size { get; private set; }
        public float FallingSpeed { get; private set; }
        public float RotationSpeed { get; private set; }
        private float currentRotation;
        private Image image;

        /// <summary>
        /// Конструктор снежинки; генерирует случайные параметры для снежинки.
        /// </summary>
        /// <param name="screenWidth">Ширина экрана (формы).</param>
        /// <param name="screenHeight">Высота экрана (формы).</param>
        /// <param name="random">Экземпляр Random для генерации случайных значений.</param>
        public Snowflake(int screenWidth, int screenHeight, Random random)
        {
            X = random.Next(0, screenWidth);
            Y = random.Next(-screenHeight, 0); // Координата Y выше видимого экрана
            Size = random.Next(15, 45); // px
            FallingSpeed = (float)(random.NextDouble() * 3 + 1);
            RotationSpeed = (float)(random.NextDouble() * 5 - 2);
            image = Properties.Resources.snow;
        }

        /// <summary>
        /// Обновляет положение и вращение, и отрисовывает снежинку на форме с учетом вращения.
        /// </summary>
        /// <param name="graphics">Экземпляр <see cref="Graphics"/> для рисования снежинки.</param>
        /// <param name="screenHeight">Высота экрана (формы) для проверки выхода за нижнюю границу.</param>
        public void UpdateAndDraw(Graphics graphics, int screenHeight)
        {
            Y += FallingSpeed;
            currentRotation += RotationSpeed;

            if (Y > screenHeight)
            {
                Y = -Size;
            }

            using (var matrix = new System.Drawing.Drawing2D.Matrix())
            {
                matrix.RotateAt(currentRotation, new PointF(X + Size / 2, Y + Size / 2));
                graphics.Transform = matrix;
                graphics.DrawImage(image, X, Y, Size, Size);
                graphics.ResetTransform();
            }
        }
    }
}
