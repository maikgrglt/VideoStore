using System.Windows;
using System.Windows.Controls;

namespace VideoStore.Controls
{
    public class VideoSelectionButton : Button
    {
        static VideoSelectionButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VideoSelectionButton), new FrameworkPropertyMetadata(typeof(VideoSelectionButton)));
        }

        public static readonly DependencyProperty VideoTitleProperty = DependencyProperty.Register(
            "VideoTitle", typeof(object), typeof(VideoSelectionButton), new PropertyMetadata(default(object)));

        public object VideoTitle
        {
            get { return (object) GetValue(VideoTitleProperty); }
            set { SetValue(VideoTitleProperty, value); }
        }

        public static readonly DependencyProperty VideoLengthProperty = DependencyProperty.Register(
            "VideoLength", typeof(object), typeof(VideoSelectionButton), new PropertyMetadata(default(object)));

        public object VideoLength
        {
            get { return (object) GetValue(VideoLengthProperty); }
            set { SetValue(VideoLengthProperty, value); }
        }

        public static readonly DependencyProperty SvgDataProperty = DependencyProperty.Register(
            "SvgData", typeof(object), typeof(VideoSelectionButton), new PropertyMetadata(default(object)));

        public object SvgData
        {
            get { return (object) GetValue(SvgDataProperty); }
            set { SetValue(SvgDataProperty, value); }
        }

        public static readonly DependencyProperty VideoPriceProperty = DependencyProperty.Register(
            "VideoPrice", typeof(object), typeof(VideoSelectionButton), new PropertyMetadata(default(object)));

        public object VideoPrice
        {
            get { return (object) GetValue(VideoPriceProperty); }
            set { SetValue(VideoPriceProperty, value); }
        }
    }
}
