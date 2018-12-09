using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using SweetsDokkana.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SweetsDokkana.Styles;


[assembly: ExportRenderer(typeof(RoundedButton), typeof(RoundedButtonRendererAndroid))]

namespace SweetsDokkana.Droid
{
    public class RoundedButtonRendererAndroid : ButtonRenderer
    {
        private GradientDrawable _normal, _pressed;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
              Control.SetBackgroundResource(Resource.Layout.rounded_Button);
            }
        }

        
    }
}