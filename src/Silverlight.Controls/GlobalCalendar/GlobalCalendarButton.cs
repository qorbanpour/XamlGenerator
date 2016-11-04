// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

namespace Silverlight.Controls.Primitives
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Represents a button on a
    /// <see cref="T:System.Windows.Controls.GlobalCalendar"/>.
    /// </summary>
    /// <QualityBand>Experimental</QualityBand>
    [TemplateVisualState(Name = VisualStates.StateNormal, GroupName = VisualStates.GroupCommon)]
    [TemplateVisualState(Name = VisualStates.StateMouseOver, GroupName = VisualStates.GroupCommon)]
    [TemplateVisualState(Name = VisualStates.StatePressed, GroupName = VisualStates.GroupCommon)]
    [TemplateVisualState(Name = VisualStates.StateDisabled, GroupName = VisualStates.GroupCommon)]
    [TemplateVisualState(Name = VisualStates.StateUnselected, GroupName = VisualStates.GroupSelection)]
    [TemplateVisualState(Name = VisualStates.StateSelected, GroupName = VisualStates.GroupSelection)]
    [TemplateVisualState(Name = VisualStates.StateCalendarButtonUnfocused, GroupName = VisualStates.GroupCalendarButtonFocus)]
    [TemplateVisualState(Name = VisualStates.StateCalendarButtonFocused, GroupName = VisualStates.GroupCalendarButtonFocus)]
    [TemplateVisualState(Name = VisualStates.StateInactive, GroupName = VisualStates.GroupActive)]
    [TemplateVisualState(Name = VisualStates.StateActive, GroupName = VisualStates.GroupActive)]
    public sealed class GlobalCalendarButton : Button
    {
        #region Constants and Fields

        /// <summary>
        /// A value indicating whether the button is focused.
        /// </summary>
        private bool _isCalendarButtonFocused;

        /// <summary>
        /// A value indicating whether the button is inactive.
        /// </summary>
        private bool _isInactive;

        /// <summary>
        /// A value indicating whether the button is selected.
        /// </summary>
        private bool _isSelected;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:System.Windows.Controls.Primitives.GlobalCalendarButton" />
        /// class.
        /// </summary>
        public GlobalCalendarButton()
        {
            this.DefaultStyleKey = typeof(GlobalCalendarButton);
            this.IsTabStop = false;
            this.Loaded += this.OnLoad;

            this.Content = GlobalCalendar.DefaultCalendarInfo.GetAbbreviatedMonthName(0);
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the left mouse button is pressed (or when the tip of the
        /// stylus touches the tablet PC) while the mouse pointer is over a
        /// UIElement.
        /// </summary>
        public event MouseButtonEventHandler CalendarButtonMouseDown;

        /// <summary>
        /// Occurs when the left mouse button is released (or the tip of the
        /// stylus is removed from the tablet PC) while the mouse (or the
        /// stylus) is over a UIElement (or while a UIElement holds mouse
        /// capture).
        /// </summary>
        public event MouseButtonEventHandler CalendarButtonMouseUp;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the button is focused.
        /// </summary>
        internal bool IsCalendarButtonFocused
        {
            get { return this._isCalendarButtonFocused; }
            set
            {
                this._isCalendarButtonFocused = value;
                this.ChangeVisualState(true);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the button is inactive.
        /// </summary>
        internal bool IsInactive
        {
            get { return this._isInactive; }
            set
            {
                this._isInactive = value;
                this.ChangeVisualState(true);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the button is selected.
        /// </summary>
        internal bool IsSelected
        {
            get { return this._isSelected; }
            set
            {
                this._isSelected = value;
                this.ChangeVisualState(true);
            }
        }

        /// <summary>
        /// Gets or sets the GlobalCalendar associated with this button.
        /// </summary>
        internal GlobalCalendar Owner { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Builds the visual tree for the
        /// <see cref="T:System.Windows.Controls.Primitives.GlobalCalendarButton"/>
        /// when a new template is applied.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.ChangeVisualState(false);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Change to the correct visual state for the button.
        /// </summary>
        /// <param name="useTransitions">
        /// True to use transitions when updating the visual state, false to
        /// snap directly to the new visual state.
        /// </param>
        internal void ChangeVisualState(bool useTransitions)
        {
            // Update the SelectionStates group
            if( this.IsSelected )
                VisualStates.GoToState(this, useTransitions, VisualStates.StateSelected, VisualStates.StateUnselected);
            else
                VisualStates.GoToState(this, useTransitions, VisualStates.StateUnselected);

            // Update the ActiveStates group
            if( this.IsInactive )
                VisualStates.GoToState(this, useTransitions, VisualStates.StateInactive);
            else
                VisualStates.GoToState(this, useTransitions, VisualStates.StateActive, VisualStates.StateInactive);

            // Update the FocusStates group
            if( this.IsCalendarButtonFocused && this.IsEnabled )
                VisualStates.GoToState(this, useTransitions, VisualStates.StateCalendarButtonFocused, VisualStates.StateCalendarButtonUnfocused);
            else
                VisualStates.GoToState(this, useTransitions, VisualStates.StateCalendarButtonUnfocused);
        }

        /// <summary>
        /// We need to simulate the MouseLeftButtonUp event for the
        /// GlobalCalendarButton that stays in Pressed state after MouseCapture is
        /// released since there is no actual MouseLeftButtonUp event for the
        /// release.
        /// </summary>
        /// <param name="e">
        /// Event arguments.
        /// </param>
        internal void SendMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            e.Handled = false;
            base.OnMouseLeftButtonUp(e);
        }

        /// <summary>
        /// Provides class handling for the MouseLeftButtonDown event that
        /// occurs when the left mouse button is pressed while the mouse pointer
        /// is over this control.
        /// </summary>
        /// <param name="e">
        /// The event data. 
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// e is a null reference (Nothing in Visual Basic).
        /// </exception>
        /// <remarks>
        /// This method marks the MouseLeftButtonDown event as handled by
        /// setting the MouseButtonEventArgs.Handled property of the event data
        /// to true when the button is enabled and its ClickMode is not set to
        /// Hover.  Since this method marks the MouseLeftButtonDown event as
        /// handled in some situations, you should use the Click event instead
        /// to detect a button click.
        /// </remarks>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            MouseButtonEventHandler handler = this.CalendarButtonMouseDown;
            if( null != handler )
                handler(this, e);
        }

        /// <summary>
        /// Provides handling for the MouseLeftButtonUp event that occurs when
        /// the left mouse button is released while the mouse pointer is over
        /// this control. 
        /// </summary>
        /// <param name="e">
        /// The event data.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// e is a null reference (Nothing in Visual Basic).
        /// </exception>
        /// <remarks>
        /// This method marks the MouseLeftButtonUp event as handled by setting
        /// the MouseButtonEventArgs.Handled property of the event data to true
        /// when the button is enabled and its ClickMode is not set to Hover.
        /// Since this method marks the MouseLeftButtonUp event as handled in
        /// some situations, you should use the Click event instead to detect a
        /// button click.
        /// </remarks>
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);

            MouseButtonEventHandler handler = this.CalendarButtonMouseUp;
            if( null != handler )
                handler(this, e);
        }

        /// <summary>
        /// Handle the Loaded event.
        /// </summary>
        /// <param name="sender">
        /// The GlobalCalendarButton.
        /// </param>
        /// <param name="e">
        /// Event arguments.
        /// </param>
        private void OnLoad(object sender, RoutedEventArgs e)
        {
            this.ChangeVisualState(false);
        }

        #endregion
    }
}