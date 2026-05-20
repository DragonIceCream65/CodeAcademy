using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CodeAcademy.Models;

namespace CodeAcademy.Controls
{
    public class CourseCardControl : Panel
    {
        private Course _course;
        private bool _isHovered = false;
        public event Action<Course> CourseClicked;

        private static readonly Font TitleFont = new Font("Segoe UI", 11f, FontStyle.Bold);
        private static readonly Font DescFont = new Font("Segoe UI", 8.5f, FontStyle.Regular);
        private static readonly Font TagFont = new Font("Segoe UI", 7.5f, FontStyle.Bold);
        private static readonly Font IconFont = new Font("Segoe UI Emoji", 22f);
        private static readonly Font ProgressFont = new Font("Segoe UI", 7.5f, FontStyle.Regular);

        public CourseCardControl(Course course)
        {
            _course = course;
            Size = new Size(260, 200);
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
            Margin = new Padding(10);

            MouseEnter += (s, e) => { _isHovered = true; Invalidate(); };
            MouseLeave += (s, e) => { _isHovered = false; Invalidate(); };
            Click += (s, e) => CourseClicked?.Invoke(_course);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            var rect = new Rectangle(0, 0, Width - 1, Height - 1);

            // Sombra
            if (_isHovered)
            {
                using (var shadowBrush = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
                    g.FillRoundedRectangle(shadowBrush, new Rectangle(4, 6, Width - 5, Height - 5), 16);
            }

            // Fondo de tarjeta
            Color bgColor = _isHovered ? Color.FromArgb(245, 247, 255) : Color.White;
            using (var bgBrush = new SolidBrush(bgColor))
                g.FillRoundedRectangle(bgBrush, rect, 16);

            // Borde izquierdo de color (acento)
            Color accent = ColorTranslator.FromHtml(_course.AccentColor);
            using (var accentBrush = new SolidBrush(accent))
                g.FillRoundedRectangle(accentBrush, new Rectangle(0, 0, 6, Height - 1), 4);

            // Borde exterior
            Color borderColor = _isHovered ? accent : Color.FromArgb(220, 225, 235);
            using (var borderPen = new Pen(borderColor, _isHovered ? 2f : 1f))
                g.DrawRoundedRectangle(borderPen, rect, 16);

            // Icono
            TextRenderer.DrawText(g, _course.Icon, IconFont, new Rectangle(18, 16, 50, 45),
                Color.Black, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

            // Título
            TextRenderer.DrawText(g, _course.Title, TitleFont, new Rectangle(72, 14, Width - 85, 30),
                Color.FromArgb(20, 25, 45), TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);

            // Descripción
            TextRenderer.DrawText(g, _course.Description, DescFont, new Rectangle(18, 60, Width - 30, 55),
                Color.FromArgb(100, 110, 140), TextFormatFlags.WordBreak);

            // Tags (dificultad y categoría)
            DrawTag(g, _course.DifficultyLabel, 18, 122, GetDifficultyColor(_course.Difficulty));
            DrawTag(g, _course.CategoryLabel, 90 + MeasureTag(_course.DifficultyLabel), 122, accent);

            // Barra de progreso
            int barY = 152;
            int barW = Width - 36;
            using (var trackBrush = new SolidBrush(Color.FromArgb(230, 232, 240)))
                g.FillRoundedRectangle(trackBrush, new Rectangle(18, barY, barW, 7), 4);

            if (_course.Progress > 0)
            {
                int fillW = (int)(barW * _course.Progress / 100);
                using (var fillBrush = new LinearGradientBrush(
                    new Rectangle(18, barY, fillW + 1, 7),
                    accent, LightenColor(accent, 60), LinearGradientMode.Horizontal))
                    g.FillRoundedRectangle(fillBrush, new Rectangle(18, barY, fillW, 7), 4);
            }

            // Texto progreso
            string progressText = $"{_course.CompletedLessons}/{_course.Lessons.Count} lecciones · {_course.TotalMinutes} min";
            TextRenderer.DrawText(g, progressText, ProgressFont, new Rectangle(18, 164, barW, 20),
                Color.FromArgb(140, 150, 175), TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }

        private void DrawTag(Graphics g, string text, int x, int y, Color color)
        {
            Size textSize = TextRenderer.MeasureText(text, TagFont);
            var tagRect = new Rectangle(x, y, textSize.Width + 14, 20);
            Color bgTag = Color.FromArgb(30, color.R, color.G, color.B);
            using (var tagBrush = new SolidBrush(bgTag))
                g.FillRoundedRectangle(tagBrush, tagRect, 6);
            TextRenderer.DrawText(g, text, TagFont, tagRect, color,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private int MeasureTag(string text)
        {
            return TextRenderer.MeasureText(text, TagFont).Width + 14 + 6;
        }

        private Color GetDifficultyColor(DifficultyLevel level)
        {
            return level switch
            {
                DifficultyLevel.Beginner => Color.FromArgb(34, 197, 94),
                DifficultyLevel.Intermediate => Color.FromArgb(245, 158, 11),
                DifficultyLevel.Advanced => Color.FromArgb(239, 68, 68),
                _ => Color.Gray
            };
        }

        private Color LightenColor(Color color, int amount)
        {
            return Color.FromArgb(
                Math.Min(255, color.R + amount),
                Math.Min(255, color.G + amount),
                Math.Min(255, color.B + amount));
        }
    }

    // Extensión para dibujar rectángulos redondeados
    public static class GraphicsExtensions
    {
        public static void FillRoundedRectangle(this Graphics g, Brush brush, Rectangle rect, int radius)
        {
            using var path = GetRoundedPath(rect, radius);
            g.FillPath(brush, path);
        }

        public static void DrawRoundedRectangle(this Graphics g, Pen pen, Rectangle rect, int radius)
        {
            using var path = GetRoundedPath(rect, radius);
            g.DrawPath(pen, path);
        }

        private static GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}