using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace xCubeApplication.Views.Dashboard
{
    public partial class MapView : UserControl
    {
        private Point _startPoint;
        private bool _isDragging;
        private double _minZoom = 0.5;  // Minimum zoom level
        private double _maxZoom = 3.0;  // Maximum zoom level

        public MapView()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(MapScrollViewer);
            _isDragging = true;
            MapScrollViewer.CaptureMouse();
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Point currentPoint = e.GetPosition(MapScrollViewer);

                double deltaX = currentPoint.X - _startPoint.X;
                double deltaY = currentPoint.Y - _startPoint.Y;

                MapScrollViewer.ScrollToHorizontalOffset(MapScrollViewer.HorizontalOffset - deltaX);
                MapScrollViewer.ScrollToVerticalOffset(MapScrollViewer.VerticalOffset - deltaY);
            }
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;
            MapScrollViewer.ReleaseMouseCapture();
        }

        private void Image_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var scaleTransform = (ScaleTransform)((Image)sender).RenderTransform;

            // Determine the new zoom scale
            double newScale = e.Delta > 0
                ? scaleTransform.ScaleX + 0.1
                : scaleTransform.ScaleX - 0.1;

            // Clamp the zoom level between the min and max limits
            newScale = Math.Max(_minZoom, Math.Min(_maxZoom, newScale));

            // Apply the new scale to both ScaleX and ScaleY
            scaleTransform.ScaleX = newScale;
            scaleTransform.ScaleY = newScale;

            // Adjust the scroll offset to keep the image centered during zoom
            var mousePosition = e.GetPosition(MapScrollViewer);
            double scrollHorizontalOffset = (mousePosition.X + MapScrollViewer.HorizontalOffset) * (newScale / scaleTransform.ScaleX);
            double scrollVerticalOffset = (mousePosition.Y + MapScrollViewer.VerticalOffset) * (newScale / scaleTransform.ScaleY);

            // Update scroll viewer's offset after zooming
            MapScrollViewer.ScrollToHorizontalOffset(scrollHorizontalOffset - mousePosition.X);
            MapScrollViewer.ScrollToVerticalOffset(scrollVerticalOffset - mousePosition.Y);
        }
    }
}
