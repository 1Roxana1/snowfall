using System;
using System.Collections.Generic;
using System.Windows.Forms;
using snowfall.Classes;

namespace snowfall
{
    /// <summary>
    /// Главная форма приложения, отображающая снегопад.
    /// </summary>
    public partial class SnowfallForm : Form
    {
        private Timer timer;
        private Snowfall snowfall;
        private Random random;

        /// <summary>
        /// Конструктор формы снегопада. Инициализирует объекты снегопада, таймера и генерации снежинок.
        /// </summary>
        public SnowfallForm()
        {
            InitializeComponent();
            snowfall = new Snowfall(ClientSize.Height);
            random = new Random();

            List<Snowflake> snowflakes = CreateSnowflakes(60);
            foreach (var snowflake in snowflakes)
            {
                snowfall.AddSnowflake(snowflake);
            }

            InitializeTimer();
        }

        /// <summary>
        /// Создает снежинки.
        /// </summary>
        /// <param name="count">Количество снежинок, которые необходимо создать.</param>
        /// <returns>Список созданных снежинок.</returns>
        private List<Snowflake> CreateSnowflakes(int count)
        {
            var snowflakes = new List<Snowflake>();
            for (int i = 0; i < count; i++)
            {
                snowflakes.Add(new Snowflake(ClientSize.Width, ClientSize.Height, random));
            }
            return snowflakes;
        }

        /// <summary>
        /// Инициализирует и запускает таймер для анимации снежинок.
        /// </summary>
        private void InitializeTimer()
        {
            timer = new Timer
            {
                Interval = 50 // мс
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        /// <summary>
        /// Событие таймера, которое инициирует перерисовку формы.
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            Invalidate(); // Перерисовка формы
        }

        /// <summary>
        /// Обработчик события перерисовки формы. Отвечает за обновление и отрисовку снежинок.
        /// </summary>
        /// <param name="e">Аргументы события рисования.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            snowfall.UpdateAndDrawSnowflakes(e.Graphics);
        }
    }
}
