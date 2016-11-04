// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

namespace Silverlight.Controls.Primitives
{
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Represents a day on a <see cref="T:System.Windows.Controls.GlobalCalendar"/>.
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
    [TemplateVisualState(Name = GlobalCalendarDayButton.StateRegularDay, GroupName = GlobalCalendarDayButton.GroupDay)]
    [TemplateVisualState(Name = GlobalCalendarDayButton.StateToday, GroupName = GlobalCalendarDayButton.GroupDay)]
    [TemplateVisualState(Name = GlobalCalendarDayButton.StateNormalDay, GroupName = GlobalCalendarDayButton.GroupBlackout)]
    [TemplateVisualState(Name = GlobalCalendarDayButton.StateBlackoutDay, GroupName = GlobalCalendarDayButton.GroupBlackout)]
    public sealed class GlobalCalendarDayButton : Button
    {
        #region Constants and Fields

        /// <summary>
        /// Name of the BlackoutDay state group.
        /// </summary>
        internal const string GroupBlackout = "BlackoutDayStates";

        /// <summary>
        /// Name of the Day state group.
        /// </summary>
        internal const string GroupDay = "DayStates";

        /// <summary>
        /// Identifies the BlackoutDay state.
        /// </summary>
        internal const string StateBlackoutDay = "BlackoutDay";

        /// <summary>
        /// Identifies the NormalDay state.
        /// </summary>
        internal const string StateNormalDay = "NormalDay";

        /// <summary>
        /// Identifies the RegularDay state.
        /// </summary>
        internal const string StateRegularDay = "RegularDay";

        /// <summary>
        /// Identifies the Today state.
        /// </summary>
        internal const string StateToday = "Today";

        /// <summary>
        /// Default content for the GlobalCalendarDayButton.
        /// </summary>
        private const int DefaultContent = 1;

        /// <summary>
        /// A value indicating whether the button should ignore the MouseOver
        /// visual state.
        /// </summary>
        // REMOVE_RTM: This field should be removed after Jolt Bug#20180 is fixed.
        private bool _ignoringMouseOverState;

        /// <summary>
        /// A value indicating whether this is a blackout date.
        /// </summary>
        private bool _isBlackout;

        /// <summary>
        /// A value indicating whether the button is the focused element on the
        /// GlobalCalendar control.
        /// </summary>
        private bool _isCurrent;

        /// <summary>
        /// A value indicating whether the button is inactive.
        /// </summary>
        private bool _isInactive;

        /// <summary>
        /// A value indicating whether the button is selected.
        /// </summary>
        private bool _isSelected;

        /// <summary>
        /// A value indicating whether this button represents today.
        /// </summary>
        private bool _isToday;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:System.Windows.Controls.Primitives.GlobalCalendarDayButton" />
        /// class.
        /// </summary>
        public GlobalCalendarDayButton()
        {
            this.DefaultStyleKey = typeof(GlobalCalendarDayButton);
            this.IsTabStop = false;
            this.Loaded += this.OnLoad;

            this.Content = DefaultContent.ToString(CultureInfo.CurrentCulture);
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the left mouse button is pressed (or when the tip of the
        /// stylus touches the tablet PC) while the mouse pointer is over a
        /// UIElement.
        /// </summary>
        public event MouseButtonEventHandler CalendarDayButtonMouseDown;

        /// <summary>
        /// Occurs when the left mouse button is released (or the tip of the
        /// stylus is removed from the tablet PC) while the mouse (or the
        /// stylus) is over a UIElement (or while a UIElement holds mouse
        /// capture).
        /// </summary>
        public event MouseButtonEventHandler CalendarDayButtonMouseUp;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets Inherited code: Requires comment.
        /// </summary>
        internal int Index { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is a blackout date.
        /// </summary>
        internal bool IsBlackout
        {
            get { return this._isBlackout; }
            set
            {
                this._isBlackout = value;
                this.ChangeVisualState(true);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the button is the focused
        /// element on the GlobalCalendar control.
        /// </summary>
        internal bool IsCurrent
        {
            get { return this._isCurrent; }
            set
            {
                this._isCurrent = value;
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
        /// Gets or sets a value indicating whether this button represents
        /// today.
        /// </summary>
        internal bool IsToday
        {
            get { return this._isToday; }
            set
            {
                this._isToday = value;
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
        /// <see cref="T:System.Windows.Controls.Primitives.GlobalCalendarDayButton"/>
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
            if( this._ignoringMouseOverState )
            {
                if( this.IsPressed )
                    VisualStates.GoToState(this, useTransitions, VisualStates.StatePressed);
                if( this.IsEnabled )
                    VisualStates.GoToState(this, useTransitions, VisualStates.StateNormal);
                else
                    VisualStates.GoToState(this, useTransitions, VisualStates.StateDisabled);
            }

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

            // Update the DayStates group
            if( this.IsToday )
                VisualStates.GoToState(this, useTransitions, StateToday, StateRegularDay);
            else
                VisualStates.GoToState(this, useTransitions, StateRegularDay);

            // Update the BlackoutDayStates group
            if( this.IsBlackout )
                VisualStates.GoToState(this, useTransitions, StateBlackoutDay, StateNormalDay);
            else
                VisualStates.GoToState(this, useTransitions, StateNormalDay);

            // Update the CalendarButtonFocusStates group (IsCurrent means the
            // button is the focused element on the GlobalCalendar control).
            if( this.IsCurrent && this.IsEnabled )
                VisualStates.GoToState(this, useTransitions, VisualStates.StateCalendarButtonFocused, VisualStates.StateCalendarButtonUnfocused);
            else
                VisualStates.GoToState(this, useTransitions, VisualStates.StateCalendarButtonUnfocused);
        }

        /// <summary>
        /// Ensure the button is not in the MouseOver state.
        /// </summary>
        /// <remarks>
        /// If a button is in the MouseOver state when a Popup is closed (as is
        /// the case when you select a date in the DatePicker control), it will
        /// continue to think it's in the mouse over state even when the Popup
        /// opens again and it's not.  This method is used to forcibly clear the
        /// state by changing the CommonStates state group.
        /// </remarks>
        internal void IgnoreMouseOverState()
        {
            // TODO: Investigate whether this needs to be done by changing the
            // state everytime we change any state, or if it can be done once
            // to properly reset the control.
            this._ignoringMouseOverState = false;

            // If the button thinks it's in the MouseOver state (which can
            // happen when a Popup is closed before the button can change state)
            // we will override the state so it shows up as normal.
            if( this.IsMouseOver )
            {
                this._ignoringMouseOverState = true;
                this.ChangeVisualState(true);
            }
        }

        /// <summary>
        /// We need to simulate the MouseLeftButtonUp event for the
        /// GlobalCalendarDayButton that stays in Pressed state after MouseCapture is
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

            MouseButtonEventHandler handler = this.CalendarDayButtonMouseDown;
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

            MouseButtonEventHandler handler = this.CalendarDayButtonMouseUp;
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