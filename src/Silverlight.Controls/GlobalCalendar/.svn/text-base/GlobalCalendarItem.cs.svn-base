// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.
// ReSharper disable PossibleNullReferenceException
namespace Silverlight.Controls.Primitives
{
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Represents the currently displayed month or year on a
    /// <see cref="T:System.Windows.Controls.GlobalCalendar"/>.
    /// </summary>
    /// <QualityBand>Experimental</QualityBand>
    [TemplatePart(Name = ElementRoot, Type = typeof(FrameworkElement))]
    [TemplatePart(Name = ElementHeaderButton, Type = typeof(Button))]
    [TemplatePart(Name = ElementPreviousButton, Type = typeof(Button))]
    [TemplatePart(Name = ElementNextButton, Type = typeof(Button))]
    [TemplatePart(Name = ElementDayTitleTemplate, Type = typeof(DataTemplate))]
    [TemplatePart(Name = ElementMonthView, Type = typeof(Grid))]
    [TemplatePart(Name = ElementYearView, Type = typeof(Grid))]
    [TemplatePart(Name = ElementDisabledVisual, Type = typeof(FrameworkElement))]
    [TemplateVisualState(Name = VisualStates.StateNormal, GroupName = VisualStates.GroupCommon)]
    [TemplateVisualState(Name = VisualStates.StateDisabled, GroupName = VisualStates.GroupCommon)]
    public sealed class GlobalCalendarItem : Control
    {
        #region Constants and Fields

        /// <summary>
        /// The name of the DayTitleTemplate template part.
        /// </summary>
        private const string ElementDayTitleTemplate = "DayTitleTemplate";

        /// <summary>
        /// The name of the DisabledVisual template part.
        /// </summary>
        private const string ElementDisabledVisual = "DisabledVisual";

        /// <summary>
        /// The name of the HeaderButton template part.
        /// </summary>
        private const string ElementHeaderButton = "HeaderButton";

        /// <summary>
        /// The name of the MonthView template part.
        /// </summary>
        private const string ElementMonthView = "MonthView";

        /// <summary>
        /// The name of the NextButton template part.
        /// </summary>
        private const string ElementNextButton = "NextButton";

        /// <summary>
        /// The name of the PreviousButton template part.
        /// </summary>
        private const string ElementPreviousButton = "PreviousButton";

        /// <summary>
        /// The name of the Root template part.
        /// </summary>
        /// <remarks>
        /// TODO: It appears this template part is no longer used.  Verify with
        /// compat whether we can remove the attribute.
        /// </remarks>
        private const string ElementRoot = "Root";

        /// <summary>
        /// The name of the YearView template part.
        /// </summary>
        private const string ElementYearView = "YearView";

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private DateTime _currentMonth;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private DataTemplate _dayTitleTemplate;

        /// <summary>
        /// The overlay for the disabled state.
        /// </summary>
        /// <remarks>
        /// The disabled visual isn't necessary given that we also have a
        /// Disabled visual state.  It's only being left in for compatability
        /// with existing templates.
        /// </remarks>
        private FrameworkElement _disabledVisual;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private MouseButtonEventArgs _downEventArg;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private MouseButtonEventArgs _downEventArgYearView;

        /// <summary>
        /// The button that allows switching between month mode, year mode, and
        /// decade mode. 
        /// </summary>
        private Button _headerButton;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private bool _isMouseLeftButtonDown;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private bool _isMouseLeftButtonDownYearView;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private bool _isTopLeftMostMonth = true;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private bool _isTopRightMostMonth = true;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private GlobalCalendarButton _lastCalendarButton;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private GlobalCalendarDayButton _lastCalendarDayButton;

        /// <summary>
        /// Hosts the content when in month mode.
        /// </summary>
        private Grid _monthView;

        /// <summary>
        /// The button that displays the next page of the calendar when it is
        /// clicked.
        /// </summary>
        private Button _nextButton;

        /// <summary>
        /// The button that displays the previous page of the calendar when it
        /// is clicked.
        /// </summary>
        private Button _previousButton;

        /// <summary>
        /// Hosts the content when in year or decade mode.
        /// </summary>
        private Grid _yearView;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:System.Windows.Controls.Primitives.GlobalCalendarItem" />
        /// class.
        /// </summary>
        public GlobalCalendarItem()
        {
            this.DefaultStyleKey = typeof(GlobalCalendarItem);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets Inherited code: Requires comment.
        /// </summary>
        internal GlobalCalendarDayButton CurrentButton { get; set; }

        /// <summary>
        /// Gets the button that allows switching between month mode, year mode,
        /// and decade mode. 
        /// </summary>
        internal Button HeaderButton
        {
            get { return this._headerButton; }
            private set
            {
                // TODO: Detach event handler
                this._headerButton = value;

                if( this._headerButton != null )
                {
                    this._headerButton.Click += this.HeaderButton_Click;
                    this._headerButton.IsTabStop = false;
                }
            }
        }

        /// <summary>
        /// Gets the CalendarInfo that provides globalized date operations.
        /// </summary>
        internal CalendarInfo Info
        {
            get
            {
                return this.Owner != null ?
                                              this.Owner.Info :
                                                                  GlobalCalendar.DefaultCalendarInfo;
            }
        }

        /// <summary>
        /// Gets the Grid that hosts the content when in month mode.
        /// </summary>
        internal Grid MonthView
        {
            get { return this._monthView; }
            private set
            {
                // TODO: Detach event handler
                this._monthView = value;

                if( this._monthView != null )
                    this._monthView.MouseLeave += this.MonthView_MouseLeave;
            }
        }

        /// <summary>
        /// Gets the button that displays the next page of the calendar when it
        /// is clicked.
        /// </summary>
        internal Button NextButton
        {
            get { return this._nextButton; }
            private set
            {
                // TODO: Detach event handler
                this._nextButton = value;

                if( this._nextButton != null )
                {
                    // If the user does not provide a Content value in template,
                    // we provide a helper text that can be used in
                    // Accessibility this text is not shown on the UI, just used
                    // for Accessibility purposes
                    if( this._nextButton.Content == null )
                        this._nextButton.Content = Assets.Resources.ControlsStrings.Calendar_NextButtonName;

                    if( this._isTopRightMostMonth )
                    {
                        this._nextButton.Visibility = Visibility.Visible;
                        this._nextButton.Click += this.NextButton_Click;
                        this._nextButton.IsTabStop = false;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets Inherited code: Requires comment.
        /// </summary>
        internal GlobalCalendar Owner { get; set; }

        /// <summary>
        /// Gets the button that displays the previous page of the calendar when
        /// it is clicked.
        /// </summary>
        internal Button PreviousButton
        {
            get { return this._previousButton; }
            private set
            {
                // TODO: Detach event handler
                this._previousButton = value;

                if( this._previousButton != null )
                {
                    // If the user does not provide a Content value in template,
                    // we provide a helper text that can be used in
                    // Accessibility this text is not shown on the UI, just used
                    // for Accessibility purposes
                    if( this._previousButton.Content == null )
                        this._previousButton.Content = Assets.Resources.ControlsStrings.Calendar_PreviousButtonName;

                    if( this._isTopLeftMostMonth )
                    {
                        this._previousButton.Visibility = Visibility.Visible;
                        this._previousButton.Click += this.PreviousButton_Click;
                        this._previousButton.IsTabStop = false;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the Grid that hosts the content when in year or decade mode.
        /// </summary>
        internal Grid YearView
        {
            get { return this._yearView; }
            private set
            {
                // TODO: Detach event handler
                this._yearView = value;

                if( this._yearView != null )
                    this._yearView.MouseLeave += this.YearView_MouseLeave;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Builds the visual tree for the
        /// <see cref="T:System.Windows.Controls.Primitives.GlobalCalendarItem"/>
        /// when a new template is applied.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.HeaderButton = this.GetTemplateChild(ElementHeaderButton) as Button;
            this.PreviousButton = this.GetTemplateChild(ElementPreviousButton) as Button;
            this.NextButton = this.GetTemplateChild(ElementNextButton) as Button;
            this._dayTitleTemplate = this.GetTemplateChild(ElementDayTitleTemplate) as DataTemplate;
            this.MonthView = this.GetTemplateChild(ElementMonthView) as Grid;
            this.YearView = this.GetTemplateChild(ElementYearView) as Grid;
            this._disabledVisual = this.GetTemplateChild(ElementDisabledVisual) as FrameworkElement;

            if( this.Owner != null )
                this.UpdateDisabledGrid(this.Owner.IsEnabled);

            this.PopulateGrids();

            if( this.MonthView != null && this.YearView != null )
            {
                if( this.Owner != null )
                {
                    this.Owner.SelectedMonth = this.Owner.DisplayDateInternal;
                    this.Owner.SelectedYear = this.Owner.DisplayDateInternal;

                    if( this.Owner.DisplayMode == CalendarMode.Year )
                        this.UpdateYearMode();
                    else if( this.Owner.DisplayMode == CalendarMode.Decade )
                        this.UpdateDecadeMode();

                    if( this.Owner.DisplayMode == CalendarMode.Month )
                    {
                        this.UpdateMonthMode();
                        this.MonthView.Visibility = Visibility.Visible;
                        this.YearView.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        this.YearView.Visibility = Visibility.Visible;
                        this.MonthView.Visibility = Visibility.Collapsed;
                    }
                }
                else
                {
                    this.UpdateMonthMode();
                    this.MonthView.Visibility = Visibility.Visible;
                    this.YearView.Visibility = Visibility.Collapsed;
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="sender">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="e">
        /// Inherited code: Requires comment 2.
        /// </param>
        internal void Cell_MouseEnter(object sender, MouseEventArgs e)
        {
            if( this.Owner != null )
            {
                var b = sender as GlobalCalendarDayButton;
                if( this._isMouseLeftButtonDown && b != null && b.IsEnabled && !b.IsBlackout )
                {
                    // Update the states of all buttons to be selected starting
                    // from HoverStart to b
                    switch( this.Owner.SelectionMode )
                    {
                        case CalendarSelectionMode.SingleDate:
                        {
                            DateTime selectedDate = b.GetDate();
                            this.Owner.DatePickerDisplayDateFlag = true;
                            if( this.Owner.SelectedDates.Count == 0 )
                                this.Owner.SelectedDates.Add(selectedDate);
                            else
                                this.Owner.SelectedDates[0] = selectedDate;
                            return;
                        }

                        case CalendarSelectionMode.SingleRange:
                        case CalendarSelectionMode.MultipleRange:
                        {
                            Debug.Assert(b.DataContext != null, "The DataContext should not be null!");
                            this.Owner.UnHighlightDays();
                            this.Owner.HoverEndIndex = b.Index;
                            this.Owner.HoverEnd = b.GetDate();

                            // Update the States of the buttons
                            this.Owner.HighlightDays();
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="sender">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="e">
        /// Inherited code: Requires comment 2.
        /// </param>
        internal void Cell_MouseLeave(object sender, MouseEventArgs e)
        {
            if( this._isMouseLeftButtonDown )
            {
                var b = sender as GlobalCalendarDayButton;

                // The button is in Pressed state. Change the state to normal.
                b.ReleaseMouseCapture();

                // null check is added for unit tests
                if( this._downEventArg != null )
                    b.SendMouseLeftButtonUp(this._downEventArg);
                this._lastCalendarDayButton = b;
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="sender">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="e">
        /// Inherited code: Requires comment 2.
        /// </param>
        internal void Cell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if( this.Owner != null )
            {
                if( !this.Owner.HasFocusInternal )
                    this.Owner.Focus();

                bool ctrl, shift;
                CalendarExtensions.GetMetaKeyState(out ctrl, out shift);
                var b = sender as GlobalCalendarDayButton;

                if( b != null )
                {
                    if( b.IsEnabled && !b.IsBlackout )
                    {
                        DateTime selectedDate = b.GetDate();
                        Debug.Assert(selectedDate != null, "selectedDate should not be null!");
                        this._isMouseLeftButtonDown = true;

                        // null check is added for unit tests
                        if( e != null )
                            this._downEventArg = e;

                        switch( this.Owner.SelectionMode )
                        {
                            case CalendarSelectionMode.None:
                            {
                                return;
                            }

                            case CalendarSelectionMode.SingleDate:
                            {
                                this.Owner.DatePickerDisplayDateFlag = true;
                                if( this.Owner.SelectedDates.Count == 0 )
                                    this.Owner.SelectedDates.Add(selectedDate);
                                else
                                    this.Owner.SelectedDates[0] = selectedDate;
                                return;
                            }

                            case CalendarSelectionMode.SingleRange:
                            {
                                // Set the start or end of the selection
                                // range
                                if( shift )
                                {
                                    this.Owner.UnHighlightDays();
                                    this.Owner.HoverEnd = selectedDate;
                                    this.Owner.HoverEndIndex = b.Index;
                                    this.Owner.HighlightDays();
                                }
                                else
                                {
                                    this.Owner.UnHighlightDays();
                                    this.Owner.HoverStart = selectedDate;
                                    this.Owner.HoverStartIndex = b.Index;
                                }

                                return;
                            }

                            case CalendarSelectionMode.MultipleRange:
                            {
                                if( shift )
                                {
                                    if( !ctrl )
                                    {
                                        // clear the list, set the states to
                                        // default
                                        foreach( var item in this.Owner.SelectedDates )
                                        {
                                            this.Owner.RemovedItems.Add(item);
                                        }

                                        this.Owner.SelectedDates.ClearInternal();
                                    }

                                    this.Owner.HoverEnd = selectedDate;
                                    this.Owner.HoverEndIndex = b.Index;
                                    this.Owner.HighlightDays();
                                }
                                else
                                {
                                    if( !ctrl )
                                    {
                                        // clear the list, set the states to
                                        // default
                                        foreach( var item in this.Owner.SelectedDates )
                                        {
                                            this.Owner.RemovedItems.Add(item);
                                        }

                                        this.Owner.SelectedDates.ClearInternal();
                                        this.Owner.UnHighlightDays();
                                    }

                                    this.Owner.HoverStart = selectedDate;
                                    this.Owner.HoverStartIndex = b.Index;
                                }

                                return;
                            }
                        }
                    }
                    else
                    {
                        // If a click occurs on a BlackOutDay we set the
                        // HoverStart to be null
                        this.Owner.HoverStart = null;
                    }
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="sender">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="e">
        /// Inherited code: Requires comment 2.
        /// </param>
        internal void Cell_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if( this.Owner != null )
            {
                bool ctrl, shift;
                CalendarExtensions.GetMetaKeyState(out ctrl, out shift);
                var b = sender as GlobalCalendarDayButton;
                if( b != null && !b.IsBlackout )
                    this.Owner.OnDayButtonMouseUp(e);
                this._isMouseLeftButtonDown = false;
                if( b != null && b.DataContext is DateTime )
                {
                    if( this.Owner.SelectionMode == CalendarSelectionMode.None || this.Owner.SelectionMode == CalendarSelectionMode.SingleDate )
                    {
                        this.Owner.OnDayClick(b.GetDate());
                        return;
                    }

                    if( this.Owner.HoverStart.HasValue )
                    {
                        switch( this.Owner.SelectionMode )
                        {
                            case CalendarSelectionMode.SingleRange:
                            {
                                // Update SelectedDates
                                foreach( var item in this.Owner.SelectedDates )
                                {
                                    this.Owner.RemovedItems.Add(item);
                                }

                                this.Owner.SelectedDates.ClearInternal();
                                this.AddSelection(b);
                                return;
                            }

                            case CalendarSelectionMode.MultipleRange:
                            {
                                // add the selection (either single day or
                                // SingleRange day)
                                this.AddSelection(b);
                                return;
                            }
                        }
                    }
                    else
                    {
                        // If the day is Disabled but a trailing day we should
                        // be able to switch months
                        if( b.IsInactive && b.IsBlackout )
                            this.Owner.OnDayClick(b.GetDate());
                    }
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="sender">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="e">
        /// Inherited code: Requires comment 2.
        /// </param>
        internal void HeaderButton_Click(object sender, RoutedEventArgs e)
        {
            if( this.Owner != null )
            {
                if( !this.Owner.HasFocusInternal )
                    this.Owner.Focus();
                var b = sender as Button;
                DateTime d;

                if( b.IsEnabled )
                {
                    if( this.Owner.DisplayMode == CalendarMode.Month )
                    {
                        if( this.Owner.DisplayDate != null )
                        {
                            d = this.Owner.DisplayDateInternal;
                            this.Owner.SelectedMonth = this.Info.GetFirstDayInMonth(d);
                        }

                        this.Owner.DisplayMode = CalendarMode.Year;
                    }
                    else
                    {
                        Debug.Assert(this.Owner.DisplayMode == CalendarMode.Year, "The Owner GlobalCalendar's DisplayMode should be Year!");

                        if( this.Owner.SelectedMonth != null )
                        {
                            d = this.Owner.SelectedMonth;
                            this.Owner.SelectedYear = this.Info.GetFirstDayInMonth(d);
                        }

                        this.Owner.DisplayMode = CalendarMode.Decade;
                    }
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="sender">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="e">
        /// Inherited code: Requires comment 2.
        /// </param>
        internal void Month_CalendarButtonMouseUp(object sender, MouseButtonEventArgs e)
        {
            this._isMouseLeftButtonDownYearView = false;

            if( this.Owner != null )
            {
                var newmonth = (DateTime)((GlobalCalendarButton)sender).DataContext;

                if( this.Owner.DisplayMode == CalendarMode.Year )
                {
                    this.Owner.DisplayDate = newmonth;
                    this.Owner.DisplayMode = CalendarMode.Month;
                }
                else
                {
                    Debug.Assert(this.Owner.DisplayMode == CalendarMode.Decade, "The owning GlobalCalendar should be in decade mode!");
                    this.Owner.SelectedMonth = newmonth;
                    this.Owner.DisplayMode = CalendarMode.Year;
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="sender">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="e">
        /// Inherited code: Requires comment 2.
        /// </param>
        internal void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if( this.Owner != null )
            {
                if( !this.Owner.HasFocusInternal )
                    this.Owner.Focus();
                var b = sender as Button;

                if( b.IsEnabled )
                    this.Owner.OnNextClick();
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="sender">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="e">
        /// Inherited code: Requires comment 2.
        /// </param>
        internal void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if( this.Owner != null )
            {
                if( !this.Owner.HasFocusInternal )
                    this.Owner.Focus();

                var b = sender as Button;
                if( b.IsEnabled )
                    this.Owner.OnPreviousClick();
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        internal void UpdateDecadeMode()
        {
            DateTime selectedYear;

            if( this.Owner != null )
            {
                Debug.Assert(this.Owner.SelectedYear != null, "The owning GlobalCalendar's selected year should not be null!");
                selectedYear = this.Owner.SelectedYear;
                this._currentMonth = this.Owner.SelectedMonth;
            }
            else
            {
                this._currentMonth = DateTime.Today;
                selectedYear = DateTime.Today;
            }

            CalendarInfo info = this.Info;
            if( this._currentMonth != null )
            {
                int decade = info.GetDecadeStart(selectedYear);
                int decadeEnd = info.GetDecadeEnd(selectedYear);

                this.SetDecadeModeHeaderButton(decade, decadeEnd);
                this.SetDecadeModePreviousButton(decade);
                this.SetDecadeModeNextButton(decadeEnd);

                if( this.YearView != null )
                    this.SetYearButtons(decade, decadeEnd);
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="isEnabled">
        /// Inherited code: Requires comment 1.
        /// </param>
        internal void UpdateDisabledGrid(bool isEnabled)
        {
            if( isEnabled )
            {
                if( this._disabledVisual != null )
                    this._disabledVisual.Visibility = Visibility.Collapsed;
                VisualStates.GoToState(this, true, VisualStates.StateNormal);
            }
            else
            {
                if( this._disabledVisual != null )
                    this._disabledVisual.Visibility = Visibility.Visible;
                VisualStates.GoToState(this, true, VisualStates.StateDisabled, VisualStates.StateNormal);
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        internal void UpdateMonthMode()
        {
            if( this.Owner != null )
            {
                Debug.Assert(this.Owner.DisplayDate != null, "The Owner GlobalCalendar's DisplayDate should not be null!");
                this._currentMonth = this.Owner.DisplayDateInternal;
            }
            else
                this._currentMonth = DateTime.Today;

            if( this._currentMonth != null )
            {
                this.SetMonthModeHeaderButton();
                this.SetMonthModePreviousButton(this._currentMonth);
                this.SetMonthModeNextButton(this._currentMonth);

                if( this.MonthView != null )
                {
                    this.SetDayTitles();
                    this.SetCalendarDayButtons(this._currentMonth);
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        internal void UpdateYearMode()
        {
            if( this.Owner != null )
            {
                Debug.Assert(this.Owner.SelectedMonth != null, "The Owner GlobalCalendar's SelectedMonth should not be null!");
                this._currentMonth = this.Owner.SelectedMonth;
            }
            else
                this._currentMonth = DateTime.Today;

            if( this._currentMonth != null )
            {
                this.SetYearModeHeaderButton();
                this.SetYearModePreviousButton();
                this.SetYearModeNextButton();

                if( this.YearView != null )
                    this.SetMonthButtonsForYearMode();
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="calendarButton">
        /// Inherited code: Requires comment 1.
        /// </param>
        internal void UpdateYearViewSelection(GlobalCalendarButton calendarButton)
        {
            if( this.Owner != null && calendarButton != null && calendarButton.DataContext is DateTime )
            {
                this.Owner.FocusCalendarButton.IsCalendarButtonFocused = false;
                this.Owner.FocusCalendarButton = calendarButton;
                calendarButton.IsCalendarButtonFocused = this.Owner.HasFocusInternal;

                var date = (DateTime)calendarButton.DataContext;
                if( this.Owner.DisplayMode == CalendarMode.Year )
                    this.Owner.SelectedMonth = date;
                else
                    this.Owner.SelectedYear = date;
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="b">
        /// Inherited code: Requires comment 1.
        /// </param>
        private void AddSelection(GlobalCalendarDayButton b)
        {
            if( this.Owner != null )
            {
                DateTime date = b.GetDate();
                this.Owner.HoverEndIndex = b.Index;
                this.Owner.HoverEnd = date;

                if( this.Owner.HoverEnd != null && this.Owner.HoverStart != null )
                {
                    // this is selection with Mouse, we do not guarantee the
                    // range does not include BlackOutDates.  AddRange method
                    // will throw away the BlackOutDates based on the
                    // SelectionMode
                    this.Owner.IsMouseSelection = true;
                    this.Owner.SelectedDates.AddRange(this.Owner.HoverStart.Value, this.Owner.HoverEnd.Value);
                    this.Owner.OnDayClick(date);
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="sender">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="e">
        /// Inherited code: Requires comment 2.
        /// </param>
        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            if( this.Owner != null )
            {
                bool ctrl, shift;
                CalendarExtensions.GetMetaKeyState(out ctrl, out shift);

                if( ctrl && this.Owner.SelectionMode == CalendarSelectionMode.MultipleRange )
                {
                    var b = sender as GlobalCalendarDayButton;
                    Debug.Assert(b != null, "The sender should be a non-null GlobalCalendarDayButton!");

                    if( b.IsSelected )
                    {
                        this.Owner.HoverStart = null;
                        this._isMouseLeftButtonDown = false;
                        b.IsSelected = false;
                        DateTime? date = b.GetDateNullable();
                        if( date != null )
                            this.Owner.SelectedDates.Remove(date.Value);
                    }
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="sender">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="e">
        /// Inherited code: Requires comment 2.
        /// </param>
        private void MonthView_MouseLeave(object sender, MouseEventArgs e)
        {
            if( this._lastCalendarDayButton != null )
                this._lastCalendarDayButton.CaptureMouse();
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="sender">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="e">
        /// Inherited code: Requires comment 2.
        /// </param>
        private void Month_CalendarButtonMouseDown(object sender, MouseButtonEventArgs e)
        {
            var b = sender as GlobalCalendarButton;
            Debug.Assert(b != null, "The sender should be a non-null GlobalCalendarDayButton!");

            this._isMouseLeftButtonDownYearView = true;

            if( e != null )
                this._downEventArgYearView = e;

            this.UpdateYearViewSelection(b);
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="sender">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="e">
        /// Inherited code: Requires comment 2.
        /// </param>
        private void Month_MouseEnter(object sender, MouseEventArgs e)
        {
            if( this._isMouseLeftButtonDownYearView )
            {
                var b = sender as GlobalCalendarButton;
                Debug.Assert(b != null, "The sender should be a non-null GlobalCalendarDayButton!");
                this.UpdateYearViewSelection(b);
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="sender">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="e">
        /// Inherited code: Requires comment 2.
        /// </param>
        private void Month_MouseLeave(object sender, MouseEventArgs e)
        {
            if( this._isMouseLeftButtonDownYearView )
            {
                var b = sender as GlobalCalendarButton;

                // The button is in Pressed state. Change the state to normal.
                b.ReleaseMouseCapture();
                if( this._downEventArgYearView != null )
                    b.SendMouseLeftButtonUp(this._downEventArgYearView);
                this._lastCalendarButton = b;
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private void PopulateGrids()
        {
            if( this.MonthView != null )
            {
                for( int i = 0; i < GlobalCalendar.RowsPerMonth; i++ )
                {
                    if( this._dayTitleTemplate != null )
                    {
                        var cell = (FrameworkElement)this._dayTitleTemplate.LoadContent();
                        cell.SetValue(Grid.RowProperty, 0);
                        cell.SetValue(Grid.ColumnProperty, i);
                        this.MonthView.Children.Add(cell);
                    }
                }

                for( int i = 1; i < GlobalCalendar.RowsPerMonth; i++ )
                {
                    for( int j = 0; j < GlobalCalendar.ColumnsPerMonth; j++ )
                    {
                        var cell = new GlobalCalendarDayButton();

                        if( this.Owner != null )
                        {
                            cell.Owner = this.Owner;
                            this.Owner.ApplyDayButtonStyle(cell);
                        }

                        cell.SetValue(Grid.RowProperty, i);
                        cell.SetValue(Grid.ColumnProperty, j);
                        cell.CalendarDayButtonMouseDown += this.Cell_MouseLeftButtonDown;
                        cell.CalendarDayButtonMouseUp += this.Cell_MouseLeftButtonUp;
                        cell.MouseEnter += this.Cell_MouseEnter;
                        cell.MouseLeave += this.Cell_MouseLeave;
                        cell.Click += this.Cell_Click;
                        this.MonthView.Children.Add(cell);
                    }
                }
            }

            if( this.YearView != null )
            {
                GlobalCalendarButton month;
                int count = 0;
                for( int i = 0; i < GlobalCalendar.RowsPerYear; i++ )
                {
                    for( int j = 0; j < GlobalCalendar.ColumnsPerYear; j++ )
                    {
                        month = new GlobalCalendarButton();

                        if( this.Owner != null )
                        {
                            month.Owner = this.Owner;
                            if( this.Owner.CalendarButtonStyle != null )
                                month.Style = this.Owner.CalendarButtonStyle;
                        }

                        month.SetValue(Grid.RowProperty, i);
                        month.SetValue(Grid.ColumnProperty, j);
                        month.CalendarButtonMouseDown += this.Month_CalendarButtonMouseDown;
                        month.CalendarButtonMouseUp += this.Month_CalendarButtonMouseUp;
                        month.MouseEnter += this.Month_MouseEnter;
                        month.MouseLeave += this.Month_MouseLeave;
                        this.YearView.Children.Add(month);
                        count++;
                    }
                }
            }
        }

        /// <summary>
        /// How many days of the previous month need to be displayed.
        /// </summary>
        /// <param name="firstOfMonth">
        /// Inherited code: Requires comment.
        /// </param>
        /// <returns>
        /// Inherited code: Requires comment 1.
        /// </returns>
        private int PreviousMonthDays(DateTime firstOfMonth)
        {
            CalendarInfo info = this.Info;
            DayOfWeek firstDay = (this.Owner != null) ?
                                                          this.Owner.FirstDay :
                                                                                  info.FirstDayOfWeek;
            int daysPerWeek = info.DaysInWeek;
            DayOfWeek day = info.GetDayOfWeek(firstOfMonth);

            int i = (day - firstDay + daysPerWeek) % daysPerWeek;
            return (i != 0) ?
                                i :
                                      daysPerWeek;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="childButton">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="dateToAdd">
        /// Inherited code: Requires comment 2.
        /// </param>
        private void SetButtonState(GlobalCalendarDayButton childButton, DateTime dateToAdd)
        {
            if( this.Owner == null )
                return;

            CalendarInfo info = this.Info;
            childButton.Opacity = 1;

            // If the day is outside the DisplayDateStart/End boundary, do
            // not show it
            if( info.CompareDays(dateToAdd, this.Owner.DisplayDateRangeStart) < 0 ||
                info.CompareDays(dateToAdd, this.Owner.DisplayDateRangeEnd) > 0 )
            {
                childButton.IsEnabled = false;
                childButton.Opacity = 0;
            }
            else
            {
                // SET IF THE DAY IS SELECTABLE OR NOT
                childButton.IsBlackout = this.Owner.BlackoutDates.Contains(dateToAdd);
                childButton.IsEnabled = true;

                // SET IF THE DAY IS INACTIVE OR NOT: set if the day is a
                // trailing day or not
                childButton.IsInactive = info.GetMonthDifference(dateToAdd, this.Owner.DisplayDateInternal) != 0;

                // SET IF THE DAY IS TODAY OR NOT
                childButton.IsToday = this.Owner.IsTodayHighlighted && this.Info.Compare(dateToAdd, DateTime.Today) == 0;

                // SET IF THE DAY IS SELECTED OR NOT
                // (Since we should be comparing the Date values not DateTime
                // values, we can't use Owner.SelectedDates.Contains(dateToAdd)
                // directly)
                bool selected = false;
                foreach( var item in this.Owner.SelectedDates )
                {
                    if( info.CompareDays(dateToAdd, item) == 0 )
                    {
                        selected = true;
                        break;
                    }
                }

                childButton.IsSelected = selected;

                // SET THE FOCUS ELEMENT
                if( this.Owner.LastSelectedDate != null )
                {
                    if( info.CompareDays(this.Owner.LastSelectedDate.Value, dateToAdd) == 0 )
                    {
                        if( this.Owner.FocusButton != null )
                            this.Owner.FocusButton.IsCurrent = false;
                        this.Owner.FocusButton = childButton;
                        if( this.Owner.HasFocusInternal )
                            this.Owner.FocusButton.IsCurrent = true;
                    }
                    else
                        childButton.IsCurrent = false;
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="firstDayOfMonth">
        /// Inherited code: Requires comment 1.
        /// </param>
        private void SetCalendarDayButtons(DateTime firstDayOfMonth)
        {
            // Debug.Assert(firstDayOfMonth.Day == 1, "firstDayOfMonth should be the first day of the month!");
            CalendarInfo info = this.Info;

            DateTime dateToAdd;
            int lastMonthToDisplay = this.PreviousMonthDays(firstDayOfMonth);
            if( info.GetMonthDifference(firstDayOfMonth, DateTime.MinValue) > 0 )
            {
                // DisplayDate is not equal to DateTime.MinValue we can subtract
                // days from the DisplayDate
                dateToAdd = info.AddDays(firstDayOfMonth, -lastMonthToDisplay).Value;
            }
            else
                dateToAdd = firstDayOfMonth;

            if( this.Owner != null && this.Owner.HoverEnd != null && this.Owner.HoverStart != null )
            {
                this.Owner.HoverEndIndex = null;
                this.Owner.HoverStartIndex = null;
            }

            int count = GlobalCalendar.RowsPerMonth * GlobalCalendar.ColumnsPerMonth;
            for( int childIndex = GlobalCalendar.ColumnsPerMonth; childIndex < count; childIndex++ )
            {
                var childButton = this.MonthView.Children[childIndex] as GlobalCalendarDayButton;
                Debug.Assert(childButton != null, "childButton should not be null!");

                childButton.Index = childIndex;
                this.SetButtonState(childButton, dateToAdd);

                // Update the indexes of hoverStart and hoverEnd
                if( this.Owner != null && this.Owner.HoverEnd != null && this.Owner.HoverStart != null )
                {
                    if( info.CompareDays(dateToAdd, this.Owner.HoverEnd.Value) == 0 )
                        this.Owner.HoverEndIndex = childIndex;

                    if( info.CompareDays(dateToAdd, this.Owner.HoverStart.Value) == 0 )
                        this.Owner.HoverStartIndex = childIndex;
                }

                childButton.IsTabStop = false;
                childButton.Content = info.DayToString(dateToAdd);
                childButton.SetDate(dateToAdd);
                this.Owner.ApplyDayButtonStyle(childButton);

                if( info.Compare(DateTime.MaxValue.Date, dateToAdd) > 0 )
                {
                    // Since we are sure DisplayDate is not equal to
                    // DateTime.MaxValue, it is safe to use AddDays 
                    dateToAdd = info.AddDays(dateToAdd, 1).Value;
                }
                else
                {
                    // DisplayDate is equal to the DateTime.MaxValue, so there
                    // are no trailing days
                    childIndex++;
                    for( int i = childIndex; i < count; i++ )
                    {
                        childButton = this.MonthView.Children[i] as GlobalCalendarDayButton;
                        Debug.Assert(childButton != null, "childButton should not be null!");

                        // button needs a content to occupy the necessary space
                        // for the content presenter
                        DateTime? childDay = info.AddDays(firstDayOfMonth, i - 1);
                        childButton.Content = childDay != null ? info.DayToString(childDay.Value) : null;
                        childButton.IsEnabled = false;
                        childButton.Opacity = 0;
                    }

                    return;
                }
            }

            // If the HoverStart or HoverEndInternal could not be found on the
            // DisplayMonth set the values of the HoverStartIndex or
            // HoverEndIndex to be the first or last day indexes on the current
            // month
            if( this.Owner != null && this.Owner.HoverStart != null && this.Owner.HoverEndInternal != null )
            {
                if( this.Owner.HoverEndIndex == null )
                {
                    if( info.CompareDays(this.Owner.HoverEndInternal.Value, this.Owner.HoverStart.Value) > 0 )
                        this.Owner.HoverEndIndex = GlobalCalendar.ColumnsPerMonth * GlobalCalendar.RowsPerMonth - 1;
                    else
                        this.Owner.HoverEndIndex = GlobalCalendar.ColumnsPerMonth;
                }

                if( this.Owner.HoverStartIndex == null )
                {
                    if( info.CompareDays(this.Owner.HoverEndInternal.Value, this.Owner.HoverStart.Value) > 0 )
                        this.Owner.HoverStartIndex = GlobalCalendar.ColumnsPerMonth;
                    else
                        this.Owner.HoverStartIndex = GlobalCalendar.ColumnsPerMonth * GlobalCalendar.RowsPerMonth - 1;
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private void SetDayTitles()
        {
            CalendarInfo info = this.Info;
            for( int childIndex = 0; childIndex < GlobalCalendar.ColumnsPerMonth; childIndex++ )
            {
                var daytitle = this.MonthView.Children[childIndex] as FrameworkElement;
                if( daytitle != null )
                {
                    DayOfWeek firstDay = (this.Owner != null) ?
                                                                  this.Owner.FirstDay :
                                                                                          info.FirstDayOfWeek;

                    int index = (childIndex + (int)firstDay) % info.DaysInWeek;
                    daytitle.DataContext = info.GetShortestDayName(index);
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="decade">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="decadeEnd">
        /// Inherited code: Requires comment 2.
        /// </param>
        private void SetDecadeModeHeaderButton(int decade, int decadeEnd)
        {
            if( this.HeaderButton != null )
            {
                this.HeaderButton.Content = this.Info.DecadeToString(decade, decadeEnd);
                this.HeaderButton.IsEnabled = false;
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="decadeEnd">
        /// Inherited code: Requires comment 1.
        /// </param>
        private void SetDecadeModeNextButton(int decadeEnd)
        {
            if( this.Owner != null && this.NextButton != null )
                this.NextButton.IsEnabled = this.Owner.DisplayDateRangeEnd.Year > decadeEnd;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="decade">
        /// Inherited code: Requires comment 1.
        /// </param>
        private void SetDecadeModePreviousButton(int decade)
        {
            if( this.Owner != null && this.PreviousButton != null )
                this.PreviousButton.IsEnabled = decade > this.Owner.DisplayDateRangeStart.Year;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private void SetMonthButtonsForYearMode()
        {
            CalendarInfo info = this.Info;

            int count = 0;
            foreach( object child in this.YearView.Children )
            {
                var childButton = child as GlobalCalendarButton;
                Debug.Assert(childButton != null, "childButton should not be null!");

                // There should be no time component. Time is 12:00 AM
                DateTime day = info.AddMonths(info.GetFirstDayInYear(this._currentMonth), count).Value;
                childButton.DataContext = day;

                childButton.Content = info.GetAbbreviatedMonthName(count);
                childButton.Visibility = Visibility.Visible;

                if( this.Owner != null )
                {
                    if( day.Year == this._currentMonth.Year &&
                        day.Month == this._currentMonth.Month &&
                        day.Day == this._currentMonth.Day )
                    {
                        this.Owner.FocusCalendarButton = childButton;
                        childButton.IsCalendarButtonFocused = this.Owner.HasFocusInternal;
                    }
                    else
                        childButton.IsCalendarButtonFocused = false;

                    Debug.Assert(this.Owner.DisplayDateInternal != null, "The Owner GlobalCalendar's DisplayDateInternal should not be null!");
                    childButton.IsSelected = info.GetMonthDifference(day, this.Owner.DisplayDateInternal) == 0;

                    if( info.GetMonthDifference(day, this.Owner.DisplayDateRangeStart) < 0 ||
                        info.GetMonthDifference(day, this.Owner.DisplayDateRangeEnd) > 0 )
                    {
                        childButton.IsEnabled = false;
                        childButton.Opacity = 0;
                    }
                    else
                    {
                        childButton.IsEnabled = true;
                        childButton.Opacity = 1;
                    }
                }

                childButton.IsInactive = false;
                count++;
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private void SetMonthModeHeaderButton()
        {
            if( this.HeaderButton != null )
            {
                DateTime date = DateTime.Today;
                if( this.Owner != null )
                {
                    date = this.Owner.DisplayDateInternal;
                    this.HeaderButton.IsEnabled = true;
                }

                this.HeaderButton.Content = this.Info.MonthAndYearToString(date);
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="firstDayOfMonth">
        /// Inherited code: Requires comment 1.
        /// </param>
        private void SetMonthModeNextButton(DateTime firstDayOfMonth)
        {
            // Debug.Assert(firstDayOfMonth.Day == 1, "firstDayOfMonth should be the first day of the month!");
            if( this.Owner != null && this.NextButton != null )
            {
                this.NextButton.IsEnabled = false;

                // DisplayDate is equal to DateTime.MaxValue
                CalendarInfo info = this.Info;
                if( info.GetMonthDifference(firstDayOfMonth, DateTime.MaxValue) != 0 )
                {
                    // Since we are sure DisplayDate is not equal to
                    // DateTime.MaxValue, it is safe to use AddMonths  
                    DateTime? firstDayOfNextMonth = info.AddMonths(firstDayOfMonth, 1);
                    if( firstDayOfNextMonth != null )
                    {
                        this.NextButton.IsEnabled =
                            info.CompareDays(this.Owner.DisplayDateRangeEnd, firstDayOfNextMonth.Value) > -1;
                    }
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="firstDayOfMonth">
        /// Inherited code: Requires comment 1.
        /// </param>
        private void SetMonthModePreviousButton(DateTime firstDayOfMonth)
        {
            // Debug.Assert(firstDayOfMonth.Day == 1, "firstDayOfMonth should be the first day of the month!");
            if( this.Owner != null && this.PreviousButton != null )
            {
                this.PreviousButton.IsEnabled =
                    this.Info.CompareDays(this.Owner.DisplayDateRangeStart, firstDayOfMonth) < 0;
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="decade">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="decadeEnd">
        /// Inherited code: Requires comment 2.
        /// </param>
        private void SetYearButtons(int decade, int decadeEnd)
        {
            int year;
            int count = -1;
            foreach( object child in this.YearView.Children )
            {
                var childButton = child as GlobalCalendarButton;
                Debug.Assert(childButton != null, "childButton should not be null!");
                year = decade + count;

                if( year <= DateTime.MaxValue.Year && year >= DateTime.MinValue.Year )
                {
                    // There should be no time component. Time is 12:00 AM
                    var day = new DateTime(year, 1, 1);

                    childButton.DataContext = day;
                    childButton.Content = this.Info.YearToString(day);
                    childButton.Visibility = Visibility.Visible;

                    if( this.Owner != null )
                    {
                        if( string.Equals(this.Info.YearToString(this.Owner.SelectedYear), this.Info.YearToString(day)) )
                        {
                            this.Owner.FocusCalendarButton = childButton;
                            childButton.IsCalendarButtonFocused = this.Owner.HasFocusInternal;
                        }
                        else
                            childButton.IsCalendarButtonFocused = false;
                        childButton.IsSelected = string.Equals(this.Info.YearToString(this.Owner.DisplayDate), this.Info.YearToString(day));

                        if( year < this.Owner.DisplayDateRangeStart.Year || year > this.Owner.DisplayDateRangeEnd.Year )
                        {
                            childButton.IsEnabled = false;
                            childButton.Opacity = 0;
                        }
                        else
                        {
                            childButton.IsEnabled = true;
                            childButton.Opacity = 1;
                        }
                    }

                    // SET IF THE YEAR IS INACTIVE OR NOT: set if the year is a
                    // trailing year or not
                    childButton.IsInactive = year < decade || year > decadeEnd;
                }
                else
                {
                    childButton.IsEnabled = false;
                    childButton.Opacity = 0;
                }

                count++;
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private void SetYearModeHeaderButton()
        {
            if( this.HeaderButton != null )
            {
                this.HeaderButton.IsEnabled = true;
                this.HeaderButton.Content = this.Info.YearToString(this._currentMonth);
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private void SetYearModeNextButton()
        {
            if( this.Owner != null && this.NextButton != null )
                this.NextButton.IsEnabled = this.Owner.DisplayDateRangeEnd.Year != this._currentMonth.Year;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private void SetYearModePreviousButton()
        {
            if( this.Owner != null && this.PreviousButton != null )
                this.PreviousButton.IsEnabled = this.Owner.DisplayDateRangeStart.Year != this._currentMonth.Year;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="sender">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="e">
        /// Inherited code: Requires comment 2.
        /// </param>
        private void YearView_MouseLeave(object sender, MouseEventArgs e)
        {
            if( this._lastCalendarButton != null )
                this._lastCalendarButton.CaptureMouse();
        }

        #endregion
    }
}

// ReSharper restore PossibleNullReferenceException