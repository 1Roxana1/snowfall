using System.Collections.Generic;
using System.Drawing;

namespace snowfall.Classes
{
    public class Snowfall
    {
        private List<Snowflake> snowflakes;
        private int screenHeight;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="screenHeight">Высота экрана (форма) для управления границами падения снежинок.</param>
        public Snowfall(int screenHeight)
        {
            this.screenHeight = screenHeight;
            snowflakes = new List<Snowflake>();
        }

        /// <summary>
        /// Добавляет снежинку в список.
        /// </summary>
        /// <param name="snowflake">Экземпляр снежинки, который будет добавлен.</param>
        public void AddSnowflake(Snowflake snowflake)
        {
            snowflakes.Add(snowflake);
        }

        /// <summary>
        /// Обновляет положение всех снежинок и отрисовывает их на форме.
        /// </summary>
        /// <param name="graphics">Экземпляр <see cref="Graphics"/> для рисования всех снежинок.</param>
        public void UpdateAndDrawSnowflakes(Graphics graphics)
        {
            foreach (var snowflake in snowflakes)
            {
                snowflake.UpdateAndDraw(graphics, screenHeight);
            }
        }
    }
}
