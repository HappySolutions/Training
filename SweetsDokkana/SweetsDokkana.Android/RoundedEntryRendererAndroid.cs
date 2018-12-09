using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using SweetsDokkana.Styles;
using SweetsDokkana.Droid;

[assembly: ExportRenderer(typeof(RoundedEntry), typeof(RoundedEntryRendererAndroid))]
namespace SweetsDokkana.Droid
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class RoundedEntryRendererAndroid : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.SetBackgroundResource(Resource.Layout.rounded_shape);
               
            }
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}