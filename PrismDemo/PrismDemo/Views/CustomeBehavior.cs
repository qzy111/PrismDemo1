using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PrismDemo.Views
{
    public class CustomeBehavior : Behavior<UIElement>
    {
        private Canvas canvas;
        private bool isdragging = false;
        private Point mouseOffset;
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
            AssociatedObject.MouseMove += AssociatedObject_MouseMove;
            AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseLeftButtonUp;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;
            AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
            AssociatedObject.MouseLeftButtonUp -= AssociatedObject_MouseLeftButtonUp;
        }

        private void AssociatedObject_MouseLeftButtonDown(object sender,MouseButtonEventArgs arg)
        {
            canvas ??= (Canvas)VisualTreeHelper.GetParent(this.AssociatedObject);
            isdragging = true;
            mouseOffset = arg.GetPosition(this.AssociatedObject);
            AssociatedObject.CaptureMouse();
        }
        private void AssociatedObject_MouseMove(object sender, MouseEventArgs arg)
        {
            if (isdragging)
            {
                Point point = arg.GetPosition(canvas);
                AssociatedObject.SetValue(Canvas.TopProperty, point.Y - mouseOffset.Y);
                AssociatedObject.SetValue(Canvas.LeftProperty, point.X - mouseOffset.X);
            }
        }
        private void AssociatedObject_MouseLeftButtonUp(object sender, MouseButtonEventArgs arg)
        {
            if (isdragging)
            {
                AssociatedObject.ReleaseMouseCapture();
                isdragging = false;
            }
        }
    }
}
