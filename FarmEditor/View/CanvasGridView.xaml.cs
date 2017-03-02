using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FarmEditor.View {
    public partial class CanvasGridView  {
        public CanvasGridView() {
            InitializeComponent();
        }

        private bool _isMouseDown;
        private Point _mouseDownPos;

        private void GridMouseDown(object sender, MouseButtonEventArgs e) {
            SelectionGrid.CaptureMouse();
            _isMouseDown = true;
            _mouseDownPos = e.GetPosition(SelectionGrid);
            
            Canvas.SetLeft(SelectionBox, _mouseDownPos.X);
            Canvas.SetTop(SelectionBox, _mouseDownPos.Y);

            SelectionBox.Width = 0;
            SelectionBox.Height = 0;

            SelectionBox.Visibility = Visibility.Visible;
        }

        private void GridMouseUp(object sender, MouseButtonEventArgs e) {
            SelectionGrid.ReleaseMouseCapture();
            _isMouseDown = false;
            SelectionBox.Visibility = Visibility.Collapsed;
        }

        private void DrawSelectionRect(Point start, Point end) {
            var dx = end.X - start.X;
            var dy = end.Y - start.Y;
            
            Canvas.SetLeft(SelectionBox, start.X + Math.Min(dx, 0));
            Canvas.SetTop(SelectionBox, start.Y + Math.Min(dy, 0)) ;

            SelectionBox.Width = Math.Abs(dx);
            SelectionBox.Height =  Math.Abs(dy);
        }

        private void GridMouseMove(object sender, MouseEventArgs e) {
            if (_isMouseDown) {
                DrawSelectionRect(_mouseDownPos, e.GetPosition(SelectionGrid));
            }
        }
    }
}