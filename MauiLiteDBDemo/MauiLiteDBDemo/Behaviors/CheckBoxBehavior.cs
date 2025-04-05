using System;
using System.Windows.Input;

namespace MauiLiteDBDemo.Behaviors
{
	public class CheckBoxBehavior: Behavior<CheckBox>
    {
        public static readonly BindableProperty CommandProperty =
        BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(CheckBoxBehavior));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        protected override void OnAttachedTo(CheckBox checkBox)
        {
            base.OnAttachedTo(checkBox);
            checkBox.CheckedChanged += OnCheckedChanged;
        }

        protected override void OnDetachingFrom(CheckBox checkBox)
        {
            base.OnDetachingFrom(checkBox);
            checkBox.CheckedChanged -= OnCheckedChanged;
        }

        private void OnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (Command?.CanExecute(sender) ?? false)
            {
                Command.Execute((sender as CheckBox)?.BindingContext);
            }
        }
    }
}

