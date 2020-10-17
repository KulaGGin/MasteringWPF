using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;


namespace Kulagin.MasteringWPF.Views.Controls {
    public class SmileyFace : Visual {
        private VisualCollection visuals;

        public SmileyFace() {
            visuals = new VisualCollection(this);
            visuals.Add(GetFaceDrawingVisual());
        }

        private DrawingVisual GetFaceDrawingVisual() {
            RadialGradientBrush radialGradientBrush = new RadialGradientBrush(Colors.Yellow, Colors.Orange);

            radialGradientBrush.RadiusX = 0.8;
            radialGradientBrush.RadiusY = 0.8;
            radialGradientBrush.Freeze();
            Pen outerPen = new Pen(Brushes.Black, 5.25);
            outerPen.Freeze();
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            drawingContext.DrawEllipse(radialGradientBrush, outerPen, new Point(75, 75), 72.375, 72.375);
            drawingContext.DrawEllipse(Brushes.Black, null, new Point(44.25, 49.5), 10.125, 12.75);
            drawingContext.DrawEllipse(Brushes.Black, null, new Point(105.75, 49.5), 10.125, 12.75);
            ArcSegment arcSegment = new ArcSegment(new Point(115.5, 93.75), new Size(61.5, 61.5), 0, false, SweepDirection.Counterclockwise, true);

            PathFigure pathFigure = new PathFigure(new Point(34.5, 93.75), new List<PathSegment>() {arcSegment}, false);
            PathGeometry pathGeometry = new PathGeometry(new List<PathFigure>() {pathFigure});

            pathGeometry.Freeze();
            Pen smilePen = new Pen(Brushes.Black, 10.5);
            smilePen.StartLineCap = PenLineCap.Round;
            smilePen.EndLineCap = PenLineCap.Round;
            smilePen.Freeze();
            drawingContext.DrawGeometry(null, smilePen, pathGeometry);
            drawingContext.Close();

            return drawingVisual;
        }

        protected override int VisualChildrenCount { get { return visuals.Count; } }

        protected override Visual GetVisualChild(int index) {
            if (index < 0 || index >= visuals.Count)
                throw new ArgumentOutOfRangeException();

            return visuals[index];
        }
    }
}