﻿using SweetsDokkana.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SweetsDokkana.Behaviors
{
    public class MaxLengthValidator : Behavior<RoundedEntry>
    {
        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create("MaxLength", typeof(int), typeof(MaxLengthValidator), 0);

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        protected override void OnAttachedTo(RoundedEntry bindable)
        {
            bindable.TextChanged += bindable_TextChanged;
        }

        private void bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (MaxLength != null && MaxLength.HasValue)
            if (e.NewTextValue.Length > 0 && e.NewTextValue.Length > MaxLength)
                ((RoundedEntry)sender).Text = e.NewTextValue.Substring(0, MaxLength);
        }

        protected override void OnDetachingFrom(RoundedEntry bindable)
        {
            bindable.TextChanged -= bindable_TextChanged;

        }
    }
}

