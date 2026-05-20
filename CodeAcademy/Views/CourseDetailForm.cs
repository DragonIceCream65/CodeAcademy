using CodeAcademy.Controls;
using CodeAcademy.Models;
using CodeAcademy.Presenters;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CodeAcademy.Views
{
    public class CourseDetailForm : Form, ICourseView
    {
        private Course _course;
        private Lesson _currentLesson;

        // Controles
        private Panel pnlHeader;
        private Panel pnlLeft;
        private Panel pnlRight;
        private ListBox lstLessons;
        private RichTextBox rtbContent;
        private Button btnComplete;
        private ProgressBar pbProgress;
        private Label lblProgress;
        private Label lblLessonTitle;
        private Label lblProgressText;

        public event Action<Lesson> LessonSelected;
        public event Action<Lesson> LessonCompleted;

        private readonly Color ColAccent;
        private readonly Color ColBg = Color.FromArgb(245, 247, 255);
        private readonly Color ColPrimary = Color.FromArgb(15, 23, 42);
        private readonly Color ColMuted = Color.FromArgb(120, 130, 160);

        public CourseDetailForm(Course course)
        {
            _course = course;
            ColAccent = ColorTranslator.FromHtml(course.AccentColor);

            SetupForm();
            BuildHeader();
            BuildBody();

            var presenter = new CoursePresenter(this, course);
        }

        private void SetupForm()
        {
            Text = $"CodeAcademy — {_course.Title}";
            Size = new Size(1100, 720);
            MinimumSize = new Size(900, 600);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = ColBg;
            Font = new Font("Segoe UI", 9f);
            DoubleBuffered = true;
        }

        private void BuildHeader()
        {
            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 90,
                BackColor = ColPrimary
            };
            pnlHeader.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Gradiente de fondo
                using var grad = new LinearGradientBrush(
                    new Rectangle(0, 0, pnlHeader.Width, pnlHeader.Height),
                    ColPrimary, Color.FromArgb(30, 35, 60), LinearGradientMode.Horizontal);
                g.FillRectangle(grad, 0, 0, pnlHeader.Width, pnlHeader.Height);

                // Círculo decorativo
                using var accentBrush = new SolidBrush(Color.FromArgb(30, ColAccent.R, ColAccent.G, ColAccent.B));
                g.FillEllipse(accentBrush, pnlHeader.Width - 120, -40, 160, 160);

                // Icono del curso
                TextRenderer.DrawText(g, _course.Icon, new Font("Segoe UI Emoji", 24f),
                    new Rectangle(20, 15, 56, 60), Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                // Título del curso
                TextRenderer.DrawText(g, _course.Title, new Font("Segoe UI", 16f, FontStyle.Bold),
                    new Rectangle(88, 14, pnlHeader.Width - 200, 38), Color.White,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

                // Subtítulo (descripción corta)
                string sub = $"📚 {_course.Lessons.Count} lecciones  •  ⏱ {_course.TotalMinutes} min  •  🎯 {_course.DifficultyLabel}";
                TextRenderer.DrawText(g, sub, new Font("Segoe UI", 8.5f),
                    new Rectangle(88, 52, pnlHeader.Width - 200, 28),
                    Color.FromArgb(180, 200, 230),
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

                // Etiqueta de categoría
                string catLabel = _course.CategoryLabel;
                var catSize = TextRenderer.MeasureText(catLabel, new Font("Segoe UI", 8f, FontStyle.Bold));
                var catRect = new Rectangle(pnlHeader.Width - catSize.Width - 44, 32, catSize.Width + 24, 26);
                using var catBg = new SolidBrush(Color.FromArgb(60, ColAccent.R, ColAccent.G, ColAccent.B));
                g.FillRoundedRectangle(catBg, catRect, 6);
                TextRenderer.DrawText(g, catLabel, new Font("Segoe UI", 8f, FontStyle.Bold), catRect,
                    ColAccent, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };

            Controls.Add(pnlHeader);
        }

        private void BuildBody()
        {
            var pnlBody = new Panel { Dock = DockStyle.Fill, BackColor = ColBg };

            // ─── Panel izquierdo: lista de lecciones ───
            pnlLeft = new Panel
            {
                Dock = DockStyle.Left,
                Width = 280,
                BackColor = Color.White,
                Padding = new Padding(0)
            };

            var lblLecciones = new Label
            {
                Text = "LECCIONES",
                Dock = DockStyle.Top,
                Height = 44,
                Font = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = ColMuted,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(18, 0, 0, 0),
                BackColor = Color.White
            };

            // Barra de progreso superior
            var pnlProgressBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 48,
                BackColor = Color.White,
                Padding = new Padding(16, 8, 16, 0)
            };
            pnlProgressBar.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                // Texto progreso
                TextRenderer.DrawText(g, $"Progreso: {_course.CompletedLessons}/{_course.Lessons.Count}",
                    new Font("Segoe UI", 8f, FontStyle.Bold),
                    new Rectangle(0, 4, pnlProgressBar.Width - 32, 18),
                    ColPrimary, TextFormatFlags.Left);
                // Track
                int bw = pnlProgressBar.Width - 32;
                g.FillRoundedRectangle(new SolidBrush(Color.FromArgb(230, 232, 245)), new Rectangle(0, 26, bw, 8), 4);
                if (_course.Progress > 0)
                {
                    int fw = (int)(bw * _course.Progress / 100);
                    using var fill = new LinearGradientBrush(
                        new Rectangle(0, 26, fw + 1, 8), ColAccent,
                        LightenColor(ColAccent, 60), LinearGradientMode.Horizontal);
                    g.FillRoundedRectangle(fill, new Rectangle(0, 26, fw, 8), 4);
                }
            };
            pnlProgressBar.Tag = pnlProgressBar; // para repintar

            lblProgressText = new Label
            {
                Dock = DockStyle.Top,
                Height = 0 // Se actualiza desde UpdateProgress
            };

            lstLessons = new ListBox
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                ForeColor = ColPrimary,
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 9.5f),
                ItemHeight = 52,
                DrawMode = DrawMode.OwnerDrawFixed,
                SelectionMode = SelectionMode.One
            };

            foreach (var lesson in _course.Lessons)
                lstLessons.Items.Add(lesson);

            lstLessons.DrawItem += DrawLessonItem;
            lstLessons.SelectedIndexChanged += (s, e) =>
            {
                if (lstLessons.SelectedItem is Lesson lesson)
                {
                    _currentLesson = lesson;
                    LoadLessonContent(lesson);
                    LessonSelected?.Invoke(lesson);
                }
            };

            // Separador derecho
            var sepRight = new Panel
            {
                Dock = DockStyle.Right,
                Width = 1,
                BackColor = Color.FromArgb(220, 225, 240)
            };

            pnlLeft.Controls.Add(lstLessons);
            pnlLeft.Controls.Add(pnlProgressBar);
            pnlLeft.Controls.Add(lblLecciones);
            pnlLeft.Controls.Add(sepRight);

            // ─── Panel derecho: contenido de la lección ───
            pnlRight = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ColBg,
                Padding = new Padding(28, 22, 28, 22)
            };

            lblLessonTitle = new Label
            {
                Dock = DockStyle.Top,
                Height = 44,
                Font = new Font("Segoe UI", 14f, FontStyle.Bold),
                ForeColor = ColPrimary,
                Text = "← Selecciona una lección"
            };

            // Separador decorativo bajo título
            var pnlTitleSep = new Panel
            {
                Dock = DockStyle.Top,
                Height = 3,
                BackColor = Color.Transparent
            };
            pnlTitleSep.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var grad = new LinearGradientBrush(
                    new Rectangle(0, 0, 120, 3),
                    ColAccent, Color.Transparent, LinearGradientMode.Horizontal);
                e.Graphics.FillRectangle(grad, 0, 0, 120, 3);
            };

            rtbContent = new RichTextBox
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                Font = new Font("Consolas", 10.5f),
                BackColor = ColBg,
                ForeColor = Color.FromArgb(30, 40, 70),
                ReadOnly = true,
                ScrollBars = RichTextBoxScrollBars.Vertical,
                Padding = new Padding(0, 12, 0, 0),
                Text = "Selecciona una lección del panel izquierdo para comenzar a estudiar.\n\n💡 Marca las lecciones como completadas para seguir tu progreso."
            };

            // Panel inferior con botón
            var pnlBottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.White,
                Padding = new Padding(0, 10, 0, 10)
            };
            pnlBottom.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(220, 225, 240), 1f);
                e.Graphics.DrawLine(pen, 0, 0, pnlBottom.Width, 0);
            };

            btnComplete = new Button
            {
                Text = "✓  Marcar como completada",
                Size = new Size(220, 40),
                Location = new Point(28, 10),
                FlatStyle = FlatStyle.Flat,
                BackColor = ColAccent,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnComplete.FlatAppearance.BorderSize = 0;
            btnComplete.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnComplete.Width, btnComplete.Height, 10, 10));
            btnComplete.Click += (s, e) =>
            {
                if (_currentLesson != null && !_currentLesson.IsCompleted)
                {
                    LessonCompleted?.Invoke(_currentLesson);
                    lstLessons.Invalidate();
                    pnlProgressBar.Invalidate();
                }
            };

            pnlBottom.Controls.Add(btnComplete);
            pnlRight.Controls.Add(rtbContent);
            pnlRight.Controls.Add(pnlTitleSep);
            pnlRight.Controls.Add(lblLessonTitle);
            pnlRight.Controls.Add(pnlBottom);

            pnlBody.Controls.Add(pnlRight);
            pnlBody.Controls.Add(pnlLeft);
            Controls.Add(pnlBody);

            // Seleccionar primera lección automáticamente
            if (lstLessons.Items.Count > 0)
                lstLessons.SelectedIndex = 0;
        }

        private void DrawLessonItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= _course.Lessons.Count) return;
            var lesson = _course.Lessons[e.Index];
            bool selected = (e.State & DrawItemState.Selected) != 0;
            bool completed = lesson.IsCompleted;

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Fondo
            Color bg = selected
                ? Color.FromArgb(240, 243, 255)
                : Color.White;
            g.FillRectangle(new SolidBrush(bg), e.Bounds);

            // Línea inferior
            using var sepPen = new Pen(Color.FromArgb(235, 238, 248), 1f);
            g.DrawLine(sepPen, e.Bounds.Left + 16, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);

            // Indicador izquierdo si está seleccionado
            if (selected)
            {
                g.FillRectangle(new SolidBrush(ColAccent),
                    e.Bounds.Left, e.Bounds.Top + 4, 3, e.Bounds.Height - 8);
            }

            // Círculo de número/check
            var circleRect = new Rectangle(e.Bounds.Left + 14, e.Bounds.Top + 14, 24, 24);
            if (completed)
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(34, 197, 94)), circleRect);
                TextRenderer.DrawText(g, "✓", new Font("Segoe UI", 8f, FontStyle.Bold),
                    circleRect, Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            else
            {
                Color circBg = selected
                    ? Color.FromArgb(30, ColAccent.R, ColAccent.G, ColAccent.B)
                    : Color.FromArgb(235, 238, 248);
                g.FillEllipse(new SolidBrush(circBg), circleRect);
                TextRenderer.DrawText(g, (e.Index + 1).ToString(),
                    new Font("Segoe UI", 8f, FontStyle.Bold),
                    circleRect, selected ? ColAccent : ColMuted,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }

            // Título
            Color titleColor = completed ? Color.FromArgb(34, 197, 94) : (selected ? ColPrimary : Color.FromArgb(50, 60, 90));
            TextRenderer.DrawText(g, lesson.Title,
                new Font("Segoe UI", 9.5f, FontStyle.Bold),
                new Rectangle(e.Bounds.Left + 46, e.Bounds.Top + 8, e.Bounds.Width - 60, 24),
                titleColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

            // Duración
            TextRenderer.DrawText(g, $"⏱ {lesson.DurationMinutes} min",
                new Font("Segoe UI", 7.5f),
                new Rectangle(e.Bounds.Left + 46, e.Bounds.Top + 30, e.Bounds.Width - 60, 18),
                ColMuted, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }

        private void LoadLessonContent(Lesson lesson)
        {
            lblLessonTitle.Text = $"  {lesson.Title}";
            rtbContent.Text = lesson.Content;
            btnComplete.Text = lesson.IsCompleted
                ? "✓  Lección completada"
                : "✓  Marcar como completada";
            btnComplete.BackColor = lesson.IsCompleted
                ? Color.FromArgb(34, 197, 94)
                : ColAccent;
            btnComplete.Enabled = !lesson.IsCompleted;
        }

        // ─── ICourseView ───
        public void LoadCourse(Course course) { }

        public void UpdateProgress(float progress, int completed, int total)
        {
            if (InvokeRequired) { Invoke(new Action(() => UpdateProgress(progress, completed, total))); return; }
            pnlLeft?.Invalidate(true);
        }

        private Color LightenColor(Color c, int a) =>
            Color.FromArgb(Math.Min(255, c.R + a), Math.Min(255, c.G + a), Math.Min(255, c.B + a));

        [System.Runtime.InteropServices.DllImport("Gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int l, int t, int r, int b, int w, int h);
    }
}