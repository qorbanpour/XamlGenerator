// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

// ReSharper disable PossibleNullReferenceException
namespace Silverlight.Controls
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;
    using System.Windows.Media;

    using Calendar = System.Globalization.Calendar;

    /// <summary>
    /// Represents a control that allows the user to select a date.
    /// </summary>
    /// <QualityBand>Mature</QualityBand>
    [TemplatePart(Name = ElementRoot, Type = typeof(FrameworkElement))]
    [TemplatePart(Name = ElementTextBox, Type = typeof(DatePickerTextBox))]
    [TemplatePart(Name = ElementButton, Type = typeof(Button))]
    [TemplatePart(Name = ElementPopup, Type = typeof(Popup))]
    [TemplateVisualState(Name = VisualStates.StateNormal, GroupName = VisualStates.GroupCommon)]
    [TemplateVisualState(Name = VisualStates.StateDisabled, GroupName = VisualStates.GroupCommon)]
    [TemplateVisualState(Name = VisualStates.StateValid, GroupName = VisualStates.GroupValidation)]
    [TemplateVisualState(Name = VisualStates.StateInvalidFocused, GroupName = VisualStates.GroupValidation)]
    [TemplateVisualState(Name = VisualStates.StateInvalidUnfocused, GroupName = VisualStates.GroupValidation)]
    [StyleTypedProperty(Property = "CalendarStyle", StyleTargetType = typeof(Calendar))]
    public class DatePicker : Control
    {
        #region Constants and Fields

        /// <summary>
        /// Identifies the
        /// <see cref="P:System.Windows.Controls.DatePicker.CalendarStyle" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:System.Windows.Controls.DatePicker.CalendarStyle" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty CalendarStyleProperty =
            DependencyProperty.Register(
                                        "CalendarStyle", 
                typeof(Style), 
                typeof(DatePicker), 
                new PropertyMetadata(OnCalendarStyleChanged));

        /// <summary>
        /// Identifies the
        /// <see cref="P:System.Windows.Controls.DatePicker.DisplayDateEnd" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:System.Windows.Controls.DatePicker.DisplayDateEnd" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty DisplayDateEndProperty =
            DependencyProperty.Register(
                                        "DisplayDateEnd", 
                typeof(DateTime?), 
                typeof(DatePicker), 
                new PropertyMetadata(OnDisplayDateEndChanged));

        /// <summary>
        /// Identifies the
        /// <see cref="P:System.Windows.Controls.DatePicker.DisplayDate" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:System.Windows.Controls.DatePicker.DisplayDate" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty DisplayDateProperty =
            DependencyProperty.Register(
                                        "DisplayDate", 
                typeof(DateTime), 
                typeof(DatePicker), 
                new PropertyMetadata(OnDisplayDateChanged));

        /// <summary>
        /// Identifies the
        /// <see cref="P:System.Windows.Controls.DatePicker.DisplayDateStart" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:System.Windows.Controls.DatePicker.DisplayDateStart" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty DisplayDateStartProperty =
            DependencyProperty.Register(
                                        "DisplayDateStart", 
                typeof(DateTime?), 
                typeof(DatePicker), 
                new PropertyMetadata(OnDisplayDateStartChanged));

        /// <summary>
        /// Identifies the
        /// <see cref="P:System.Windows.Controls.DatePicker.FirstDayOfWeek" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:System.Windows.Controls.DatePicker.FirstDayOfWeek" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty FirstDayOfWeekProperty =
            DependencyProperty.Register(
                                        "FirstDayOfWeek", 
                typeof(DayOfWeek), 
                typeof(DatePicker), 
                new PropertyMetadata(OnFirstDayOfWeekChanged));

        /// <summary>
        /// Identifies the
        /// <see cref="P:System.Windows.Controls.DatePicker.IsDropDownOpen" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:System.Windows.Controls.DatePicker.IsDropDownOpen" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty IsDropDownOpenProperty =
            DependencyProperty.Register(
                                        "IsDropDownOpen", 
                typeof(bool), 
                typeof(DatePicker), 
                new PropertyMetadata(false, OnIsDropDownOpenChanged));

        /// <summary>
        /// Identifies the
        /// <see cref="P:System.Windows.Controls.DatePicker.IsTodayHighlighted" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:System.Windows.Controls.DatePicker.IsTodayHighlighted" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty IsTodayHighlightedProperty =
            DependencyProperty.Register(
                                        "IsTodayHighlighted", 
                typeof(bool), 
                typeof(DatePicker), 
                new PropertyMetadata(true, OnIsTodayHighlightedChanged));

        /// <summary>
        /// Identifies the
        /// <see cref="P:System.Windows.Controls.DatePicker.SelectedDateFormat" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:System.Windows.Controls.DatePicker.SelectedDateFormat" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty SelectedDateFormatProperty =
            DependencyProperty.Register(
                                        "SelectedDateFormat", 
                typeof(DatePickerFormat), 
                typeof(DatePicker), 
                new PropertyMetadata(DatePickerFormat.Short, OnSelectedDateFormatChanged));

        /// <summary>
        /// Identifies the
        /// <see cref="P:System.Windows.Controls.DatePicker.SelectedDate" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:System.Windows.Controls.DatePicker.SelectedDate" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty SelectedDateProperty =
            DependencyProperty.Register(
                                        "SelectedDate", 
                typeof(DateTime?), 
                typeof(DatePicker), 
                new PropertyMetadata(OnSelectedDateChanged));

        /// <summary>
        /// Identifies the
        /// <see cref="P:System.Windows.Controls.DatePicker.SelectionBackground" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:System.Windows.Controls.DatePicker.SelectionBackground" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty SelectionBackgroundProperty =
            DependencyProperty.Register(
                                        "SelectionBackground", 
                typeof(Brush), 
                typeof(DatePicker), 
                null);

        /// <summary>
        /// Identifies the
        /// <see cref="P:System.Windows.Controls.DatePicker.Text" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:System.Windows.Controls.DatePicker.Text" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                                        "Text", 
                typeof(string), 
                typeof(DatePicker), 
                new PropertyMetadata(string.Empty, OnTextChanged));

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private const string ElementButton = "Button";

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private const string ElementPopup = "Popup";

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private const string ElementRoot = "Root";

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private const string ElementTextBox = "TextBox";

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private GlobalCalendar _calendar;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private string _defaultText;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private Button _dropDownButton;

        /// <summary>
        /// The value of the SelectedDate just before the Calendar Popup is opened.
        /// This is used for cancelling the date selection with ESC key.
        /// </summary>
        private DateTime? _onOpenSelectedDate;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private Canvas _outsideCanvas;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private Canvas _outsidePopupCanvas;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private Popup _popUp;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private FrameworkElement _root;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private bool _settingSelectedDate;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private Primitives.DatePickerTextBox _textBox;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:System.Windows.Controls.DatePicker" /> class.
        /// </summary>
        public DatePicker()
        {
            this.InitializeCalendar();
            this.IsEnabledChanged += this.OnIsEnabledChanged;
            this.FirstDayOfWeek = this.CalendarInfo.FirstDayOfWeek;
            this._defaultText = string.Empty;
            this.DisplayDate = DateTime.Today;
            this.GotFocus += this.DatePicker_GotFocus;
            this.LostFocus += this.DatePicker_LostFocus;
            this.BlackoutDates = this._calendar.BlackoutDates;
            this.DefaultStyleKey = typeof(DatePicker);
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the drop-down
        /// <see cref="T:System.Windows.Controls.Calendar" /> is closed.
        /// </summary>
        public event RoutedEventHandler CalendarClosed;

        /// <summary>
        /// Occurs when the drop-down
        /// <see cref="T:System.Windows.Controls.Calendar" /> is opened.
        /// </summary>
        public event RoutedEventHandler CalendarOpened;

        /// <summary>
        /// Occurs when <see cref="P:System.Windows.Controls.DatePicker.Text" />
        /// is assigned a value that cannot be interpreted as a date.
        /// </summary>
        public event EventHandler<DatePickerDateValidationErrorEventArgs> DateValidationError;

        /// <summary>
        /// Occurs when the
        /// <see cref="P:System.Windows.Controls.DatePicker.SelectedDate" />
        /// property is changed.
        /// </summary>
        public event EventHandler<SelectionChangedEventArgs> SelectedDateChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets a collection of dates that are marked as not selectable.
        /// </summary>
        /// <value>
        /// A collection of dates that cannot be selected. The default value is
        /// an empty collection.
        /// </value>
        public GlobalCalendarBlackoutDatesCollection BlackoutDates { get; private set; }

        /// <summary>
        /// Gets or sets the CalendarInfo that provides globalized date
        /// operations.
        /// </summary>
        public CalendarInfo CalendarInfo
        {
            get { return this._calendar.CalendarInfo ?? GlobalCalendar.DefaultCalendarInfo; }
            set
            {
                if( this._calendar.CalendarInfo == value )
                    return;

                this._calendar.CalendarInfo = value;
                this.FirstDayOfWeek = value.FirstDayOfWeek;
                this.BlackoutDates = this._calendar.BlackoutDates;
            }
        }

        /// <summary>
        /// Gets or sets the style that is used when rendering the calendar.
        /// </summary>
        /// <value>
        /// The style that is used when rendering the calendar.
        /// </value>
        public Style CalendarStyle
        {
            get { return (Style)this.GetValue(CalendarStyleProperty); }
            set { this.SetValue(CalendarStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the date to display.
        /// </summary>
        /// <value>
        /// The date to display. The default 
        /// <see cref="P:System.DateTime.Today" />.
        /// </value>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// The specified date is not in the range defined by
        /// <see cref="P:System.Windows.Controls.DatePicker.DisplayDateStart" />
        /// and
        /// <see cref="P:System.Windows.Controls.DatePicker.DisplayDateEnd" />.
        /// </exception>
        [TypeConverter(typeof(DateTimeTypeConverter))]
        public DateTime DisplayDate
        {
            get { return (DateTime)this.GetValue(DisplayDateProperty); }
            set { this.SetValue(DisplayDateProperty, value); }
        }

        /// <summary>
        /// Gets or sets the last date to be displayed.
        /// </summary>
        /// <value>The last date to display.</value>
        [TypeConverter(typeof(DateTimeTypeConverter))]
        public DateTime? DisplayDateEnd
        {
            get { return (DateTime?)this.GetValue(DisplayDateEndProperty); }
            set { this.SetValue(DisplayDateEndProperty, value); }
        }

        /// <summary>
        /// Gets or sets the first date to be displayed.
        /// </summary>
        /// <value>The first date to display.</value>
        [TypeConverter(typeof(DateTimeTypeConverter))]
        public DateTime? DisplayDateStart
        {
            get { return (DateTime?)this.GetValue(DisplayDateStartProperty); }
            set { this.SetValue(DisplayDateStartProperty, value); }
        }

        /// <summary>
        /// Gets or sets the day that is considered the beginning of the week.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.DayOfWeek" /> representing the beginning of
        /// the week. The default is <see cref="F:System.DayOfWeek.Sunday" />.
        /// </value>
        public DayOfWeek FirstDayOfWeek
        {
            get { return (DayOfWeek)this.GetValue(FirstDayOfWeekProperty); }
            set { this.SetValue(FirstDayOfWeekProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the drop-down
        /// <see cref="T:System.Windows.Controls.Calendar" /> is open or closed.
        /// </summary>
        /// <value>
        /// True if the <see cref="T:System.Windows.Controls.Calendar" /> is
        /// open; otherwise, false. The default is false.
        /// </value>
        public bool IsDropDownOpen
        {
            get { return (bool)this.GetValue(IsDropDownOpenProperty); }
            set { this.SetValue(IsDropDownOpenProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the current date will be
        /// highlighted.
        /// </summary>
        /// <value>
        /// True if the current date is highlighted; otherwise, false. The
        /// default is true.
        /// </value>
        public bool IsTodayHighlighted
        {
            get { return (bool)this.GetValue(IsTodayHighlightedProperty); }
            set { this.SetValue(IsTodayHighlightedProperty, value); }
        }

        /// <summary>
        /// Gets or sets the currently selected date.
        /// </summary>
        /// <value>
        /// The date currently selected. The default is null.
        /// </value>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// The specified date is not in the range defined by
        /// <see cref="P:System.Windows.Controls.DatePicker.DisplayDateStart" />
        /// and
        /// <see cref="P:System.Windows.Controls.DatePicker.DisplayDateEnd" />,
        /// or the specified date is in the
        /// <see cref="P:System.Windows.Controls.DatePicker.BlackoutDates" />
        /// collection.
        /// </exception>
        [TypeConverter(typeof(DateTimeTypeConverter))]
        public DateTime? SelectedDate
        {
            get { return (DateTime?)this.GetValue(SelectedDateProperty); }
            set { this.SetValue(SelectedDateProperty, value); }
        }

        /// <summary>
        /// Gets or sets the format that is used to display the selected date.
        /// </summary>
        /// <value>
        /// The format that is used to display the selected date. The default is
        /// <see cref="F:System.Windows.Controls.DatePickerFormat.Short" />.
        /// </value>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// An specified format is not valid.
        /// </exception>
        public DatePickerFormat SelectedDateFormat
        {
            get { return (DatePickerFormat)this.GetValue(SelectedDateFormatProperty); }
            set { this.SetValue(SelectedDateFormatProperty, value); }
        }

        /// <summary>
        /// Gets or sets the background used for selected dates.
        /// </summary>
        /// <value>
        /// The background used for selected dates.
        /// </value>
        public Brush SelectionBackground
        {
            get { return (Brush)this.GetValue(SelectionBackgroundProperty); }
            set { this.SetValue(SelectionBackgroundProperty, value); }
        }

        /// <summary>
        /// Gets or sets the text that is displayed by the
        /// <see cref="T:System.Windows.Controls.DatePicker" />.
        /// </summary>
        /// <value>
        /// The text displayed by the
        /// <see cref="T:System.Windows.Controls.DatePicker" />.
        /// </value>
        /// <exception cref="T:System.FormatException">
        /// The text entered cannot be parsed to a valid date, and the exception
        /// is not suppressed.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// The text entered parses to a date that is not selectable.
        /// </exception>
        public string Text
        {
            get { return (string)this.GetValue(TextProperty); }
            set { this.SetValue(TextProperty, value); }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Builds the visual tree for the
        /// <see cref="T:System.Windows.Controls.DatePicker"/> control when a
        /// new template is applied.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if( this._popUp != null )
                this._popUp.Child = null;

            this._popUp = this.GetTemplateChild(ElementPopup) as Popup;

            if( this._popUp != null )
            {
                if( this._outsideCanvas == null )
                {
                    this._outsideCanvas = new Canvas();
                    this._outsidePopupCanvas = new Canvas();
                    this._outsidePopupCanvas.Background = new SolidColorBrush(Colors.Transparent);
                    this._outsideCanvas.Children.Add(this._outsidePopupCanvas);
                    this._outsideCanvas.Children.Add(this._calendar);
                    this._outsidePopupCanvas.MouseLeftButtonDown += this.OutsidePopupCanvas_MouseLeftButtonDown;
                }

                this._popUp.Child = this._outsideCanvas;
                this._root = this.GetTemplateChild(ElementRoot) as FrameworkElement;

                if( this.IsDropDownOpen )
                    this.OpenDropDown();
            }

            if( this._dropDownButton != null )
                this._dropDownButton.Click -= this.DropDownButton_Click;

            this._dropDownButton = this.GetTemplateChild(ElementButton) as Button;
            if( this._dropDownButton != null )
            {
                this._dropDownButton.Click += this.DropDownButton_Click;
                this._dropDownButton.IsTabStop = false;

                // If the user does not provide a Content value in template, we
                // provide a helper text that can be used in Accessibility this
                // text is not shown on the UI, just used for Accessibility
                // purposes
                if( this._dropDownButton.Content == null )
                    this._dropDownButton.Content = Assets.Resources.ControlsStrings.DatePicker_DropDownButtonName;
            }

            if( this._textBox != null )
            {
                this._textBox.KeyDown -= this.TextBox_KeyDown;
                this._textBox.TextChanged -= this.TextBox_TextChanged;
                this._textBox.GotFocus -= this.TextBox_GotFocus;
            }

            this._textBox = this.GetTemplateChild(ElementTextBox) as Primitives.DatePickerTextBox;

            this.UpdateDisabledVisual();
            if( this.SelectedDate == null )
                this.SetWaterMarkText();

            if( this._textBox != null )
            {
                this._textBox.KeyDown += this.TextBox_KeyDown;
                this._textBox.TextChanged += this.TextBox_TextChanged;
                this._textBox.GotFocus += this.TextBox_GotFocus;

                if( this.SelectedDate == null )
                {
                    if( !string.IsNullOrEmpty(this._defaultText) )
                    {
                        this._textBox.Text = this._defaultText;
                        this.SetSelectedDate();
                    }
                }
                else
                    this._textBox.Text = this.DateTimeToString((DateTime)this.SelectedDate);
            }
        }

        /// <summary>
        /// Provides a text representation of the selected date.
        /// </summary>
        /// <returns>
        /// A text representation of the selected date, or an empty string if
        /// <see cref="SelectedDate"/> is a <c>null</c> reference.
        /// </returns>
        public override string ToString()
        {
            return this.SelectedDate != null ? this.CalendarInfo.DateToString(this.SelectedDate.Value) : string.Empty;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Raises the
        /// <see cref="E:System.Windows.Controls.DatePicker.DateValidationError"/>
        /// event.
        /// </summary>
        /// <param name="e">
        /// A
        /// <see cref="T:System.Windows.Controls.DatePickerDateValidationErrorEventArgs"/>
        /// that contains the event data.
        /// </param>
        protected virtual void OnDateValidationError(DatePickerDateValidationErrorEventArgs e)
        {
            EventHandler<DatePickerDateValidationErrorEventArgs> handler = this.DateValidationError;
            if( handler != null )
                handler(this, e);
        }

        /// <summary>
        /// Default mouse wheel handler for the DatePicker control.
        /// </summary>
        /// <param name="e">
        /// Mouse wheel event args.
        /// </param>
        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
            if( !e.Handled && this.SelectedDate.HasValue )
            {
                DateTime selectedDate = this.SelectedDate.Value;
                DateTime? newDate = this.CalendarInfo.AddDays(selectedDate, e.Delta > 0 ? -1 : 1);
                if( newDate.HasValue && GlobalCalendar.IsValidDateSelection(this._calendar, newDate.Value) )
                {
                    this.SelectedDate = newDate;
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="d">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <returns>
        /// Inherited code: Requires comment 2.
        /// </returns>
        private static DateTime DiscardDayTime(DateTime d)
        {
            int year = d.Year;
            int month = d.Month;
            var newD = new DateTime(year, month, 1, 0, 0, 0);
            return newD;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="d">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <returns>
        /// Inherited code: Requires comment 2.
        /// </returns>
        private static DateTime? DiscardTime(DateTime? d)
        {
            if( d == null )
                return null;
            else
            {
                var discarded = (DateTime)d;
                int year = discarded.Year;
                int month = discarded.Month;
                int day = discarded.Day;
                var newD = new DateTime(year, month, day, 0, 0, 0);
                return newD;
            }
        }

        /// <summary>
        /// Sets the matrix to its inverse.
        /// </summary>
        /// <param name="matrix">
        /// Matrix to be inverted.
        /// </param>
        /// <returns>
        /// True if the Matrix is invertible, false otherwise.
        /// </returns>
        private static bool InvertMatrix(ref Matrix matrix)
        {
            double determinant = matrix.M11 * matrix.M22 - matrix.M12 * matrix.M21;

            if( determinant == 0.0 )
                return false;

            Matrix matCopy = matrix;
            matrix.M11 = matCopy.M22 / determinant;
            matrix.M12 = -1 * matCopy.M12 / determinant;
            matrix.M21 = -1 * matCopy.M21 / determinant;
            matrix.M22 = matCopy.M11 / determinant;
            matrix.OffsetX = (matCopy.OffsetY * matCopy.M21 - matCopy.OffsetX * matCopy.M22) / determinant;
            matrix.OffsetY = (matCopy.OffsetX * matCopy.M12 - matCopy.OffsetY * matCopy.M11) / determinant;

            return true;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="value">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <returns>
        /// Inherited code: Requires comment 2.
        /// </returns>
        private static bool IsValidSelectedDateFormat(DatePickerFormat value)
        {
            DatePickerFormat format = value;
            return format == DatePickerFormat.Long
                   || format == DatePickerFormat.Short;
        }

        /// <summary>
        /// CalendarStyleProperty property changed handler.
        /// </summary>
        /// <param name="d">
        /// DatePicker that changed its CalendarStyle.
        /// </param>
        /// <param name="e">
        /// The DependencyPropertyChangedEventArgs.
        /// </param>
        private static void OnCalendarStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newStyle = e.NewValue as Style;
            if( newStyle != null )
            {
                var dp = d as DatePicker;

                if( dp != null )
                {
                    var oldStyle = e.OldValue as Style;

                    // Set the style for the calendar if it has not already been
                    // set
                    if( dp._calendar != null )
                    {
                        // REMOVE_RTM: Remove null check when Silverlight allows us to re-apply styles
                        // Apply the newCalendarDayStyle if the DayButton was
                        // using the oldCalendarDayStyle before
                        if( dp._calendar.Style == null || dp._calendar.Style == oldStyle )
                            dp._calendar.Style = newStyle;
                    }
                }
            }
        }

        /// <summary>
        /// DisplayDateProperty property changed handler.
        /// </summary>
        /// <param name="d">
        /// DatePicker that changed its DisplayDate.
        /// </param>
        /// <param name="e">
        /// The DependencyPropertyChangedEventArgs.
        /// </param>
        private static void OnDisplayDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dp = d as DatePicker;
            Debug.Assert(dp != null, "The DatePicker should not be null!");

            if( dp.CalendarInfo.GetMonthDifference(dp._calendar.DisplayDate, (DateTime)e.NewValue) != 0 )
            {
                dp._calendar.DisplayDate = dp.DisplayDate;

                if( DateTime.Compare(dp._calendar.DisplayDate, dp.DisplayDate) != 0 )
                    dp.DisplayDate = dp._calendar.DisplayDate;
            }
        }

        /// <summary>
        /// DisplayDateEndProperty property changed handler.
        /// </summary>
        /// <param name="d">
        /// DatePicker that changed its DisplayDateEnd.
        /// </param>
        /// <param name="e">
        /// The DependencyPropertyChangedEventArgs.
        /// </param>
        private static void OnDisplayDateEndChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dp = d as DatePicker;
            Debug.Assert(dp != null, "The DatePicker should not be null!");

            dp._calendar.DisplayDateEnd = dp.DisplayDateEnd;

            if( dp._calendar.DisplayDateEnd.HasValue && dp.DisplayDateEnd.HasValue && DateTime.Compare(dp._calendar.DisplayDateEnd.Value, dp.DisplayDateEnd.Value) != 0 )
                dp.DisplayDateEnd = dp._calendar.DisplayDateEnd;
        }

        /// <summary>
        /// DisplayDateStartProperty property changed handler.
        /// </summary>
        /// <param name="d">
        /// DatePicker that changed its DisplayDateStart.
        /// </param>
        /// <param name="e">
        /// The DependencyPropertyChangedEventArgs.
        /// </param>
        private static void OnDisplayDateStartChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dp = d as DatePicker;
            Debug.Assert(dp != null, "The DatePicker should not be null!");

            dp._calendar.DisplayDateStart = dp.DisplayDateStart;

            if( dp._calendar.DisplayDateStart.HasValue && dp.DisplayDateStart.HasValue && DateTime.Compare(dp._calendar.DisplayDateStart.Value, dp.DisplayDateStart.Value) != 0 )
                dp.DisplayDateStart = dp._calendar.DisplayDateStart;
        }

        /// <summary>
        /// FirstDayOfWeekProperty property changed handler.
        /// </summary>
        /// <param name="d">
        /// DatePicker that changed its FirstDayOfWeek.
        /// </param>
        /// <param name="e">
        /// The DependencyPropertyChangedEventArgs.
        /// </param>
        private static void OnFirstDayOfWeekChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dp = d as DatePicker;
            Debug.Assert(dp != null, "The DatePicker should not be null!");

            dp._calendar.FirstDayOfWeek = dp.FirstDayOfWeek;
        }

        /// <summary>
        /// IsDropDownOpenProperty property changed handler.
        /// </summary>
        /// <param name="d">
        /// DatePicker that changed its IsDropDownOpen.
        /// </param>
        /// <param name="e">
        /// The DependencyPropertyChangedEventArgs.
        /// </param>
        private static void OnIsDropDownOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dp = d as DatePicker;
            Debug.Assert(dp != null, "The DatePicker should not be null!");
            var newValue = (bool)e.NewValue;
            var oldValue = (bool)e.OldValue;

            if( dp._popUp != null && dp._popUp.Child != null )
            {
                if( newValue != oldValue )
                {
                    if( dp._calendar.DisplayMode != CalendarMode.Month )
                        dp._calendar.DisplayMode = CalendarMode.Month;

                    if( newValue )
                        dp.OpenDropDown();
                    else
                    {
                        Debug.Assert(!newValue, "The drop down should be closed!");
                        dp._popUp.IsOpen = false;
                        dp.OnCalendarClosed(new RoutedEventArgs());
                    }
                }
            }
        }

        /// <summary>
        /// IsTodayHighlightedProperty property changed handler.
        /// </summary>
        /// <param name="d">
        /// DatePicker that changed its IsTodayHighlighted.
        /// </param>
        /// <param name="e">
        /// The DependencyPropertyChangedEventArgs.
        /// </param>
        private static void OnIsTodayHighlightedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dp = d as DatePicker;
            Debug.Assert(dp != null, "The DatePicker should not be null!");

            dp._calendar.IsTodayHighlighted = dp.IsTodayHighlighted;
        }

        /// <summary>
        /// SelectedDateProperty property changed handler.
        /// </summary>
        /// <param name="d">
        /// DatePicker that changed its SelectedDate.
        /// </param>
        /// <param name="e">
        /// The DependencyPropertyChangedEventArgs.
        /// </param>
        private static void OnSelectedDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DateTime? addedDate;
            DateTime? removedDate;
            var dp = d as DatePicker;
            Debug.Assert(dp != null, "The DatePicker should not be null!");

            addedDate = (DateTime?)e.NewValue;
            removedDate = (DateTime?)e.OldValue;

            if( addedDate != dp._calendar.SelectedDate )
                dp._calendar.SelectedDate = addedDate;

            if( dp.SelectedDate != null )
            {
                var day = (DateTime)dp.SelectedDate;

                // When the SelectedDateProperty change is done from
                // OnTextPropertyChanged method, two-way binding breaks if
                // BeginInvoke is not used:
                dp.Dispatcher.BeginInvoke(delegate
                {
                    dp._settingSelectedDate = true;
                    dp.Text = dp.DateTimeToString(day);
                    dp._settingSelectedDate = false;
                    dp.OnDateSelected(addedDate, removedDate);
                });

                // When DatePickerDisplayDateFlag is TRUE, the SelectedDate
                // change is coming from the Calendar UI itself, so, we
                // shouldn't change the DisplayDate since it will automatically
                // be changed by the Calendar
                if( (day.Month != dp.DisplayDate.Month || day.Year != dp.DisplayDate.Year) && !dp._calendar.DatePickerDisplayDateFlag )
                    dp.DisplayDate = day;
                dp._calendar.DatePickerDisplayDateFlag = false;
            }
            else
            {
                dp._settingSelectedDate = true;
                dp.SetWaterMarkText();
                dp._settingSelectedDate = false;
                dp.OnDateSelected(addedDate, removedDate);
            }
        }

        /// <summary>
        /// SelectedDateFormatProperty property changed handler.
        /// </summary>
        /// <param name="d">
        /// DatePicker that changed its SelectedDateFormat.
        /// </param>
        /// <param name="e">
        /// The DependencyPropertyChangedEventArgs.
        /// </param>
        private static void OnSelectedDateFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dp = d as DatePicker;
            Debug.Assert(dp != null, "The DatePicker should not be null!");

            if( IsValidSelectedDateFormat((DatePickerFormat)e.NewValue) )
            {
                if( dp._textBox != null )
                {
                    // Update DatePickerTextBox.Text
                    if( string.IsNullOrEmpty(dp._textBox.Text) )
                        dp.SetWaterMarkText();
                    else
                    {
                        DateTime? date = dp.ParseText(dp._textBox.Text);

                        if( date != null )
                        {
                            string s = dp.DateTimeToString((DateTime)date);
                            dp.Text = s;
                        }
                    }
                }
            }
            else
                throw new ArgumentOutOfRangeException("d", Assets.Resources.ControlsStrings.DatePicker_OnSelectedDateFormatChanged_InvalidValue);
        }

        /// <summary>
        /// TextProperty property changed handler.
        /// </summary>
        /// <param name="d">
        /// DatePicker that changed its Text.
        /// </param>
        /// <param name="e">
        /// The DependencyPropertyChangedEventArgs.
        /// </param>
        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dp = d as DatePicker;
            Debug.Assert(dp != null, "The DatePicker should not be null!");

            if( !dp.IsHandlerSuspended(TextProperty) )
            {
                var newValue = e.NewValue as string;
                if( newValue != null )
                {
                    if( dp._textBox != null )
                        dp._textBox.Text = newValue;
                    else
                        dp._defaultText = newValue;
                    if( !dp._settingSelectedDate )
                        dp.SetSelectedDate();
                }
                else
                {
                    if( !dp._settingSelectedDate )
                        dp.SetValueNoCallback(SelectedDateProperty, null);
                }
            }
            else
                dp.SetWaterMarkText();
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
        private void Calendar_DayButtonMouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Focus();
            this.IsDropDownOpen = false;
            this._calendar.ReleaseMouseCapture();
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
        private void Calendar_DisplayDateChanged(object sender, GlobalCalendarDateChangedEventArgs e)
        {
            if( e.AddedDate != this.DisplayDate )
                this.SetValue(DisplayDateProperty, (DateTime)e.AddedDate);
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
        private void Calendar_KeyDown(object sender, KeyEventArgs e)
        {
            var c = sender as GlobalCalendar;
            Debug.Assert(c != null, "The Calendar should not be null!");

            if( !e.Handled && (e.Key == Key.Enter || e.Key == Key.Space || e.Key == Key.Escape) && c.DisplayMode == CalendarMode.Month )
            {
                this.Focus();
                this.IsDropDownOpen = false;

                if( e.Key == Key.Escape )
                    this.SelectedDate = this._onOpenSelectedDate;
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
        private void Calendar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
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
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.Assert(e.AddedItems.Count < 2, "There should be less than 2 AddedItems!");

            if( e.AddedItems.Count > 0 && this.SelectedDate.HasValue && DateTime.Compare((DateTime)e.AddedItems[0], this.SelectedDate.Value) != 0 )
                this.SelectedDate = (DateTime?)e.AddedItems[0];
            else
            {
                if( e.AddedItems.Count == 0 )
                {
                    this.SelectedDate = null;
                    return;
                }

                if( !this.SelectedDate.HasValue )
                {
                    if( e.AddedItems.Count > 0 )
                        this.SelectedDate = (DateTime?)e.AddedItems[0];
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
        private void Calendar_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.SetPopUpPosition();
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
        private void DatePicker_GotFocus(object sender, RoutedEventArgs e)
        {
            var dp = sender as DatePicker;
            Debug.Assert(dp != null, "The DatePicker should not be null!");
            if( this.IsEnabled && this._textBox != null )
                this._textBox.Focus();
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
        private void DatePicker_LostFocus(object sender, RoutedEventArgs e)
        {
            var dp = sender as DatePicker;
            Debug.Assert(dp != null, "The DatePicker should not be null!");
            Debug.Assert(e.OriginalSource != null, "The OriginalSource should not be null!");

            if( dp.IsDropDownOpen && dp._dropDownButton != null && !e.OriginalSource.Equals(dp._textBox) && !e.OriginalSource.Equals(dp._dropDownButton) && !e.OriginalSource.Equals(dp._calendar) )
                dp.IsDropDownOpen = false;
            this.SetSelectedDate();
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="d">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <returns>
        /// Inherited code: Requires comment 2.
        /// </returns>
        private string DateTimeToString(DateTime d)
        {
            switch( this.SelectedDateFormat )
            {
                case DatePickerFormat.Short:
                    return this.CalendarInfo.DateToString(d); // string.Format(CultureInfo.CurrentCulture, d.ToString(dtfi.ShortDatePattern, dtfi));
                case DatePickerFormat.Long:
                    return this.CalendarInfo.DateToLongString(d); // string.Format(CultureInfo.CurrentCulture, d.ToString(dtfi.LongDatePattern, dtfi));
            }

            return null;
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
        private void DropDownButton_Click(object sender, RoutedEventArgs e)
        {
            this.HandlePopUp();
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private void HandlePopUp()
        {
            if( this.IsDropDownOpen )
            {
                this.Focus();
                this.IsDropDownOpen = false;
                this._calendar.ReleaseMouseCapture();
            }
            else
            {
                Debug.Assert(!this.IsDropDownOpen, "The drop down should be closed!");
                this._calendar.CaptureMouse();
                this.ProcessTextBox();
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private void InitializeCalendar()
        {
            this._calendar = new GlobalCalendar();
            this._calendar.DayButtonMouseUp += this.Calendar_DayButtonMouseUp;
            this._calendar.DisplayDateChanged += this.Calendar_DisplayDateChanged;
            this._calendar.SelectedDatesChanged += this.Calendar_SelectedDatesChanged;
            this._calendar.MouseLeftButtonDown += this.Calendar_MouseLeftButtonDown;
            this._calendar.KeyDown += this.Calendar_KeyDown;
            this._calendar.SelectionMode = CalendarSelectionMode.SingleDate;
            this._calendar.SizeChanged += this.Calendar_SizeChanged;
            this._calendar.IsTabStop = true;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="e">
        /// Inherited code: Requires comment 1.
        /// </param>
        private void OnCalendarClosed(RoutedEventArgs e)
        {
            RoutedEventHandler handler = this.CalendarClosed;
            if( null != handler )
                handler(this, e);
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="e">
        /// Inherited code: Requires comment 1.
        /// </param>
        private void OnCalendarOpened(RoutedEventArgs e)
        {
            RoutedEventHandler handler = this.CalendarOpened;
            if( null != handler )
                handler(this, e);
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="addedDate">
        /// The added date.
        /// </param>
        /// <param name="removedDate">
        /// The removed date.
        /// </param>
        private void OnDateSelected(DateTime? addedDate, DateTime? removedDate)
        {
            EventHandler<SelectionChangedEventArgs> handler = this.SelectedDateChanged;
            if( null != handler )
            {
                var addedItems = new Collection<DateTime>();
                var removedItems = new Collection<DateTime>();

                if( addedDate.HasValue )
                    addedItems.Add(addedDate.Value);

                if( removedDate.HasValue )
                    removedItems.Add(removedDate.Value);

                handler(this, new SelectionChangedEventArgs(removedItems, addedItems));
            }

            // TODO: Uncomment here, if anything goes wrong.
            // var peer = FrameworkElementAutomationPeer.FromElement(this) as DatePickerAutomationPeer;
            // if( peer != null )
            // {
            // string oldValue = removedDate.HasValue ? removedDate.Value.ToString(DateTimeHelper.GetCurrentDateFormat()) : string.Empty;
            // string newValue = addedDate.HasValue ? addedDate.Value.ToString(DateTimeHelper.GetCurrentDateFormat()) : string.Empty;
            // peer.RaiseValuePropertyChangedEvent(oldValue, newValue);
            // }
        }

        /// <summary>
        /// Called when the IsEnabled property changes.
        /// </summary>
        /// <param name="sender">
        /// Sender object.
        /// </param>
        /// <param name="e">
        /// Property changed args.
        /// </param>
        private void OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.UpdateDisabledVisual();
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private void OpenDropDown()
        {
            this._calendar.Focus();
            this.OpenPopUp();
            this._calendar.ResetStates();
            this.OnCalendarOpened(new RoutedEventArgs());
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private void OpenPopUp()
        {
            FrameworkElement page = (Application.Current != null) ?
                                                                      Application.Current.RootVisual as FrameworkElement :
                                                                                                                             null;

            if( page != null )
            {
                this._onOpenSelectedDate = this.SelectedDate;
                this._popUp.IsOpen = true;
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
        private void OutsidePopupCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.IsDropDownOpen = false;
        }

        /// <summary>
        /// Input text is parsed in the correct format and changed into a
        /// DateTime object.  If the text can not be parsed TextParseError Event
        /// is thrown.
        /// </summary>
        /// <param name="text">
        /// Inherited code: Requires comment.
        /// </param>
        /// <returns>
        /// IT SHOULD RETURN NULL IF THE STRING IS NOT VALID, RETURN THE
        /// DATETIME VALUE IF IT IS VALID.
        /// </returns>
        private DateTime? ParseText(string text)
        {
            // TryParse is not used in order to be able to pass the exception to
            // the TextParseError event
            try
            {
                var newSelectedDate = this.CalendarInfo.Parse(text);

                if( GlobalCalendar.IsValidDateSelection(this._calendar, newSelectedDate) )
                    return newSelectedDate;

                var dateValidationError = new DatePickerDateValidationErrorEventArgs(new ArgumentOutOfRangeException("text", Assets.Resources.ControlsStrings.Calendar_OnSelectedDateChanged_InvalidValue), text);
                this.OnDateValidationError(dateValidationError);

                if( dateValidationError.ThrowException )
                    throw dateValidationError.Exception;
            }
            catch( FormatException ex )
            {
                var textParseError = new DatePickerDateValidationErrorEventArgs(ex, text);
                this.OnDateValidationError(textParseError);

                if( textParseError.ThrowException )
                    throw textParseError.Exception;
            }

            return null;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="e">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <returns>
        /// Inherited code: Requires comment 2.
        /// </returns>
        private bool ProcessDatePickerKey(KeyEventArgs e)
        {
            switch( e.Key )
            {
                case Key.Enter:
                {
                    this.SetSelectedDate();
                    return true;
                }

                case Key.Down:
                {
                    // REMOVE_RTM: Ctrl+Down may be changed into Alt+Down once the related Jolt bug is fixed 
                    if( (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control )
                        this.HandlePopUp();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private void ProcessTextBox()
        {
            this.SetSelectedDate();
            this.IsDropDownOpen = true;
            this._calendar.Focus();
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private void SetPopUpPosition()
        {
            if( this._calendar != null && Application.Current != null && Application.Current.Host != null && Application.Current.Host.Content != null )
            {
                double pageHeight = Application.Current.Host.Content.ActualHeight;
                double pageWidth = Application.Current.Host.Content.ActualWidth;
                double calendarHeight = this._calendar.ActualHeight;
                double actualHeight = this.ActualHeight;

                if( this._root != null )
                {
                    GeneralTransform gt = this._root.TransformToVisual(null);

                    if( gt != null )
                    {
                        var point00 = new Point(0, 0);
                        var point10 = new Point(1, 0);
                        var point01 = new Point(0, 1);
                        Point transform00 = gt.Transform(point00);
                        Point transform10 = gt.Transform(point10);
                        Point transform01 = gt.Transform(point01);

                        double dpX = transform00.X;
                        double dpY = transform00.Y;

                        double calendarX = dpX;
                        double calendarY = dpY + actualHeight;

                        // if the page height is less then the total height of
                        // the PopUp + DatePicker or if we can fit the PopUp
                        // inside the page, we want to place the PopUp to the
                        // bottom
                        if( pageHeight < calendarY + calendarHeight )
                            calendarY = dpY - calendarHeight;
                        this._popUp.HorizontalOffset = 0;
                        this._popUp.VerticalOffset = 0;
                        this._outsidePopupCanvas.Width = pageWidth;
                        this._outsidePopupCanvas.Height = pageHeight;
                        this._calendar.HorizontalAlignment = HorizontalAlignment.Left;
                        this._calendar.VerticalAlignment = VerticalAlignment.Top;
                        Canvas.SetLeft(this._calendar, calendarX - dpX);
                        Canvas.SetTop(this._calendar, calendarY - dpY);

                        // Transform the invisible canvas to plugin coordinate
                        // space origin
                        Matrix transformToRootMatrix = Matrix.Identity;
                        transformToRootMatrix.M11 = transform10.X - transform00.X;
                        transformToRootMatrix.M12 = transform10.Y - transform00.Y;
                        transformToRootMatrix.M21 = transform01.X - transform00.X;
                        transformToRootMatrix.M22 = transform01.Y - transform00.Y;
                        transformToRootMatrix.OffsetX = transform00.X;
                        transformToRootMatrix.OffsetY = transform00.Y;
                        var mt = new MatrixTransform();
                        InvertMatrix(ref transformToRootMatrix);
                        mt.Matrix = transformToRootMatrix;
                        this._outsidePopupCanvas.RenderTransform = mt;
                    }
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private void SetSelectedDate()
        {
            if( this._textBox != null )
            {
                if( !string.IsNullOrEmpty(this._textBox.Text) )
                {
                    string s = this._textBox.Text;

                    if( this.SelectedDate != null )
                    {
                        // If the string value of the SelectedDate and the
                        // TextBox string value are equal, we do not parse the
                        // string again if we do an extra parse, we lose data in
                        // M/d/yy format.
                        // ex: SelectedDate = DateTime(1008,12,19) but when
                        // "12/19/08" is parsed it is interpreted as
                        // DateTime(2008,12,19)
                        string selectedDate = this.DateTimeToString(this.SelectedDate.Value);
                        if( selectedDate == s )
                            return;
                    }

                    DateTime? d = this.SetTextBoxValue(s);
                    if( !this.SelectedDate.Equals(d) )
                        this.SelectedDate = d;
                }
                else
                {
                    if( this.SelectedDate != null )
                        this.SelectedDate = null;
                }
            }
            else
            {
                DateTime? d = this.SetTextBoxValue(this._defaultText);
                if( !this.SelectedDate.Equals(d) )
                    this.SelectedDate = d;
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="s">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <returns>
        /// Inherited code: Requires comment 2.
        /// </returns>
        private DateTime? SetTextBoxValue(string s)
        {
            if( string.IsNullOrEmpty(s) )
            {
                this.SetValue(TextProperty, s);
                return this.SelectedDate;
            }

            DateTime? d = this.ParseText(s);
            if( d != null )
            {
                this.SetValue(TextProperty, s);
                return d;
            }

            // If parse error: TextBox should have the latest valid
            // selecteddate value:
            if( this.SelectedDate != null )
            {
                string newtext = this.DateTimeToString((DateTime)this.SelectedDate);
                this.SetValue(TextProperty, newtext);
                return this.SelectedDate;
            }

            this.SetWaterMarkText();
            return null;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private void SetWaterMarkText()
        {
            if( this._textBox == null )
                return;

            var dtfi = this.CalendarInfo.DateFormatInfo;
            this.Text = string.Empty;
            this._defaultText = string.Empty;

            switch( this.SelectedDateFormat )
            {
                case DatePickerFormat.Long:
                    this._textBox.Watermark = string.Format(CultureInfo.CurrentCulture, 
                        Assets.Resources.ControlsStrings.DatePicker_WatermarkText, dtfi.LongDatePattern);
                    break;
                case DatePickerFormat.Short:
                    this._textBox.Watermark = string.Format(CultureInfo.CurrentCulture, 
                        Assets.Resources.ControlsStrings.DatePicker_WatermarkText, dtfi.ShortDatePattern);
                    break;
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
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.IsDropDownOpen = false;
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
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if( !e.Handled )
                e.Handled = this.ProcessDatePickerKey(e);
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
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if( this._textBox != null )
                this.SetValueNoCallback(TextProperty, this._textBox.Text);
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private void UpdateDisabledVisual()
        {
            if( !this.IsEnabled )
                VisualStates.GoToState(this, true, VisualStates.StateDisabled, VisualStates.StateNormal);
            else
                VisualStates.GoToState(this, true, VisualStates.StateNormal);
        }

        #endregion
    }
}

// ReSharper restore PossibleNullReferenceException