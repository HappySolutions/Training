using SweetsDokkana.Styles;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SweetsDokkana.Behaviors
{
    public class NumberValidatorBehavior : Behavior<RoundedEntry>
    {

        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(NumberValidatorBehavior), false);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }

        protected override void OnAttachedTo(RoundedEntry bindable)
        {
            bindable.TextChanged += bindable_TextChanged;
        }

        private void bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            int result;
            IsValid = int.TryParse(e.NewTextValue, out result);
            ((RoundedEntry)sender).TextColor = IsValid ? Color.Default : Color.Red;

        }

        protected override void OnDetachingFrom(RoundedEntry bindable)
        {
            bindable.TextChanged -= bindable_TextChanged;
        }
    }

}
