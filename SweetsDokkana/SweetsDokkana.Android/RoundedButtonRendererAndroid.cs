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
#pragma warning disable CS0618 // Type or member is obsolete
    public class RoundedButtonRendererAndroid : ButtonRenderer
    {

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
              Control.SetBackgroundResource(Resource.Layout.rounded_Button);
            }
        }


    }
#pragma warning restore CS0618 // Type or member is obsolete
}