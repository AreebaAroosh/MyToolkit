﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Phone.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace MyToolkit.Controls
{
	public class NavigationList : ExtendedListBox
	{
		static NavigationList()
		{
			if (!TiltEffect.TiltableItems.Contains(typeof(ContentPresenter)))
				TiltEffect.TiltableItems.Add(typeof(ContentPresenter));
		}

		protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
		{
			base.PrepareContainerForItemOverride(element, item);
			((UIElement)element).Tap += OnTapped; 
		}

		private void OnTapped(object sender, GestureEventArgs e)
		{
			var element = (FrameworkElement)sender;
			OnNavigated(new NavigationListEventArgs(element.DataContext));
		}

		public event EventHandler<NavigationListEventArgs> Navigated;

		protected void OnNavigated(NavigationListEventArgs args)
		{
			var copy = Navigated;
			if (copy != null)
				copy(this, args);
		}
	}
}
