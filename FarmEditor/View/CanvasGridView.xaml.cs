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

        //private void GridMouseDown(object sender, MouseButtonEventArgs e) {
        //    SelectionGrid.CaptureMouse();
        //    _isMouseDown = true;
        //    _mouseDownPos = e.GetPosition(SelectionGrid);
            
        //    Canvas.SetLeft(SelectionBox, _mouseDownPos.X);
        //    Canvas.SetTop(SelectionBox, _mouseDownPos.Y);

        //    SelectionBox.Width = 0;
        //    SelectionBox.Height = 0;

        //    SelectionBox.Visibility = Visibility.Visible;
        //}

        //private void GridMouseUp(object sender, MouseButtonEventArgs e) {
        //    SelectionGrid.ReleaseMouseCapture();
        //    _isMouseDown = false;
        //    SelectionBox.Visibility = Visibility.Collapsed;
        //}

        //private void DrawSelectionRect(Point start, Point end) {
        //    var dx = end.X - start.X;
        //    var dy = end.Y - start.Y;
            
        //    Canvas.SetLeft(SelectionBox, start.X + Math.Min(dx, 0));
        //    Canvas.SetTop(SelectionBox, start.Y + Math.Min(dy, 0)) ;

        //    SelectionBox.Width = Math.Abs(dx);
        //    SelectionBox.Height =  Math.Abs(dy);
        //}

        //private void GridMouseMove(object sender, MouseEventArgs e) {
        //    //SelectionBox.Visibility = Visibility.Visible;
        //    //Canvas.SetLeft(SelectionBox, (int)e.GetPosition(SelectionGrid).X / 16 * 16);
        //    //Canvas.SetTop(SelectionBox, (int)e.GetPosition(SelectionGrid).Y / 16 * 16);

        //    //SelectionBox.Width = 16;
        //    //SelectionBox.Height = 16;

        //    if (_isMouseDown) {
        //        DrawSelectionRect(_mouseDownPos, e.GetPosition(SelectionGrid));
        //    }
        //}

        //private Image draggedImage;
        //private Point mousePosition;

        //private void CanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
        //    var image = e.Source as Image;

        //    if (image != null && canvas.CaptureMouse()) {
        //        mousePosition = e.GetPosition(canvas);
        //        draggedImage = image;
        //        Panel.SetZIndex(draggedImage, 1); // in case of multiple images
        //    }
        //}

        //private void CanvasMouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
        //    if (draggedImage != null)
        //    {
        //        canvas.ReleaseMouseCapture();
        //        Panel.SetZIndex(draggedImage, 0);
        //        draggedImage = null;
        //    }
        //}

        //private void CanvasMouseMove(object sender, MouseEventArgs e) {
        //    if (draggedImage != null) {
        //        var position = e.GetPosition(canvas);
        //        var offset = position - mousePosition;
        //        mousePosition = position;
                
        //        Canvas.SetLeft(draggedImage, Canvas.GetLeft(draggedImage) + offset.X);
        //        Canvas.SetTop(draggedImage, Canvas.GetTop(draggedImage) + offset.Y);
        //    }
        //}

        //private Canvas canvas;

        //private void Canvas_Loaded(object sender, RoutedEventArgs e) {
        //    canvas = sender as Canvas;
        //}
    }
}