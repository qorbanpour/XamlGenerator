// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

namespace Silverlight.Controls
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    using Silverlight.Controls.Primitives;

    /// <summary>
    /// Represents a control that enables a user to select a date by using a
    /// visual calendar display.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A GlobalCalendar control can be used on its own, or as a drop-down part of a
    /// DatePicker control. For more information, see DatePicker.  A GlobalCalendar
    /// displays either the days of a month, the months of a year, or the years
    /// of a decade, depending on the value of the DisplayMode property.  When
    /// displaying the days of a month, the user can select a date, a range of
    /// dates, or multiple ranges of dates.  The kinds of selections that are
    /// allowed are controlled by the SelectionMode property.
    /// </para>
    /// <para>
    /// The range of dates displayed is governed by the DisplayDateStart and
    /// DisplayDateEnd properties.  If DisplayMode is Year or Decade, only
    /// months or years that contain displayable dates will be displayed.
    /// Setting the displayable range to a range that does not include the
    /// current DisplayDate will throw an ArgumentOutOfRangeException.
    /// </para>
    /// <para>
    /// The BlackoutDates property can be used to specify dates that cannot be
    /// selected. These dates will be displayed as dimmed and disabled.
    /// </para>
    /// <para>
    /// By default, Today is highlighted.  This can be disabled by setting
    /// IsTodayHighlighted to false.
    /// </para>
    /// <para>
    /// The GlobalCalendar control provides basic navigation using either the mouse or
    /// keyboard. The following table summarizes keyboard navigation.
    /// 
    ///     Key Combination     DisplayMode     Action
    ///     ARROW               Any             Change focused date, unselect
    ///                                         all selected dates, and select
    ///                                         new focused date.
    ///                                         
    ///     SHIFT+ARROW         Any             If SelectionMode is not set to
    ///                                         SingleDate or None begin
    ///                                         selecting a range of dates.
    ///                                         
    ///     CTRL+UP ARROW       Any             Switch to the next larger
    ///                                         DisplayMode.  If DisplayMode is
    ///                                         already Decade, no action.
    ///                                         
    ///     CTRL+DOWN ARROW     Any             Switch to the next smaller
    ///                                         DisplayMode.  If DisplayMode is
    ///                                         already Month, no action.
    ///                                         
    ///     SPACEBAR            Month           Select focused date.
    ///     
    ///     SPACEBAR            Year or Decade  Switch DisplayMode to the Month
    ///                                         or Year represented by focused
    ///                                         item.
    ///                                         
    ///     CTRL+HOME           Any             Switch DisplayMode to Month,
    ///                                         show today's date, and try to
    ///                                         select the date if allowed.
    /// </para>
    /// <para>
    /// XAML Usage for Classes Derived from GlobalCalendar
    /// If you define a class that derives from GlobalCalendar, the class can be used
    /// as an object element in XAML, and all of the inherited properties and
    /// events that show a XAML usage in the reference for the GlobalCalendar members
    /// can have the same XAML usage for the derived class. However, the object
    /// element itself must have a different prefix mapping than the controls:
    /// mapping shown in the usages, because the derived class comes from an
    /// assembly and namespace that you create and define.  You must define your
    /// own prefix mapping to an XML namespace to use the class as an object
    /// element in XAML.
    /// </para>
    /// </remarks>
    /// <QualityBand>Experimental</QualityBand>
    [TemplatePart(Name = ElementRoot, Type = typeof(Panel))]
    [TemplatePart(Name = ElementMonth, Type = typeof(GlobalCalendarItem))]
    [TemplateVisualState(Name = VisualStates.StateValid, GroupName = VisualStates.GroupValidation)]
    [TemplateVisualState(Name = VisualStates.StateInvalidFocused, GroupName = VisualStates.GroupValidation)]
    [TemplateVisualState(Name = VisualStates.StateInvalidUnfocused, GroupName = VisualStates.GroupValidation)]
    [StyleTypedProperty(Property = "CalendarButtonStyle", StyleTargetType = typeof(GlobalCalendarButton))]
    [StyleTypedProperty(Property = "CalendarDayButtonStyle", StyleTargetType = typeof(GlobalCalendarDayButton))]
    [StyleTypedProperty(Property = "CalendarItemStyle", StyleTargetType = typeof(GlobalCalendarItem))]
    public class GlobalCalendar : Control
    {
        #region Constants and Fields

        /// <summary>
        /// Identifies the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.CalendarButtonStyle" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.CalendarButtonStyle" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty CalendarButtonStyleProperty =
            DependencyProperty.Register(
                                        "CalendarButtonStyle", 
                typeof(Style), 
                typeof(GlobalCalendar), 
                new PropertyMetadata(OnCalendarButtonStyleChanged));

        /// <summary>
        /// Identifies the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.CalendarDayButtonStyle" />
        /// dependency property.
        /// </summary>
        /// <remarks>
        /// The identifier for the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.CalendarDayButtonStyle" />
        /// dependency property.
        /// </remarks>
        public static readonly DependencyProperty CalendarDayButtonStyleProperty =
            DependencyProperty.Register(
                                        "CalendarDayButtonStyle", 
                typeof(Style), 
                typeof(GlobalCalendar), 
                new PropertyMetadata(OnCalendarDayButtonStyleOrSelectorChanged));

        /// <summary>
        /// Identifies the CalendarDayButtonStyleSelector dependency property.
        /// </summary>
        public static readonly DependencyProperty CalendarDayButtonStyleSelectorProperty =
            DependencyProperty.Register(
                                        "CalendarDayButtonStyleSelector", 
                typeof(CalendarDayButtonStyleSelector), 
                typeof(GlobalCalendar), 
                new PropertyMetadata(null, OnCalendarDayButtonStyleOrSelectorChanged));

        /// <summary>
        /// Identifies the CalendarInfo dependency property.
        /// </summary>
        public static readonly DependencyProperty CalendarInfoProperty =
            DependencyProperty.Register(
                                        "CalendarInfo", 
                typeof(CalendarInfo), 
                typeof(GlobalCalendar), 
                new PropertyMetadata(null, OnCalendarInfoPropertyChanged));

        /// <summary>
        /// Identifies the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.CalendarItemStyle" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.CalendarItemStyle" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty CalendarItemStyleProperty =
            DependencyProperty.Register(
                                        "CalendarItemStyle", 
                typeof(Style), 
                typeof(GlobalCalendar), 
                new PropertyMetadata(OnCalendarItemStyleChanged));

        /// <summary>
        /// Identifies the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.DisplayDateEnd" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.DisplayDateEnd" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty DisplayDateEndProperty =
            DependencyProperty.Register(
                                        "DisplayDateEnd", 
                typeof(DateTime?), 
                typeof(GlobalCalendar), 
                new PropertyMetadata(OnDisplayDateEndChanged));

        /// <summary>
        /// Identifies the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.DisplayDate" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.DisplayDate" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty DisplayDateProperty =
            DependencyProperty.Register(
                                        "DisplayDate", 
                typeof(DateTime), 
                typeof(GlobalCalendar), 
                new PropertyMetadata(OnDisplayDateChanged));

        /// <summary>
        /// Identifies the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.DisplayDateStart" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.DisplayDateStart" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty DisplayDateStartProperty =
            DependencyProperty.Register(
                                        "DisplayDateStart", 
                typeof(DateTime?), 
                typeof(GlobalCalendar), 
                new PropertyMetadata(OnDisplayDateStartChanged));

        /// <summary>
        /// Identifies the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.DisplayMode" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.DisplayMode" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty DisplayModeProperty =
            DependencyProperty.Register(
                                        "DisplayMode", 
                typeof(CalendarMode), 
                typeof(GlobalCalendar), 
                new PropertyMetadata(OnDisplayModePropertyChanged));

        /// <summary>
        /// Identifies the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.FirstDayOfWeek" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.FirstDayOfWeek" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty FirstDayOfWeekProperty =
            DependencyProperty.Register(
                                        "FirstDayOfWeek", 
                typeof(DayOfWeek), 
                typeof(GlobalCalendar), 
                new PropertyMetadata(OnFirstDayOfWeekChanged));

        /// <summary>
        /// Identifies the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.IsTodayHighlighted" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.IsTodayHighlighted" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty IsTodayHighlightedProperty =
            DependencyProperty.Register(
                                        "IsTodayHighlighted", 
                typeof(bool), 
                typeof(GlobalCalendar), 
                new PropertyMetadata(true, OnIsTodayHighlightedChanged));

        /// <summary>
        /// Identifies the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.SelectedDate" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.SelectedDate" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty SelectedDateProperty =
            DependencyProperty.Register(
                                        "SelectedDate", 
                typeof(DateTime?), 
                typeof(GlobalCalendar), 
                new PropertyMetadata(OnSelectedDateChanged));

        /// <summary>
        /// Identifies the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.SelectionMode" />
        /// dependency property.
        /// </summary>
        /// <value>
        /// The identifier for the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.SelectionMode" />
        /// dependency property.
        /// </value>
        public static readonly DependencyProperty SelectionModeProperty =
            DependencyProperty.Register(
                                        "SelectionMode", 
                typeof(CalendarSelectionMode), 
                typeof(GlobalCalendar), 
                new PropertyMetadata(OnSelectionModeChanged));

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        internal const int ColumnsPerMonth = 7;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        internal const int ColumnsPerYear = 4;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        internal const int RowsPerMonth = 7;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        internal const int RowsPerYear = 3;

        /// <summary>
        /// The default CalendarInfo used to provide globalized date operations.
        /// </summary>
        internal static readonly CalendarInfo DefaultCalendarInfo = new GregorianCalendarInfo(CultureInfo.CurrentCulture);

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private const string ElementMonth = "CalendarItem";

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private const string ElementRoot = "Root";

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private bool _isShiftPressed;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private DateTime _selectedMonth;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private DateTime _selectedYear;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Silverlight.Controls.GlobalCalendar" /> class.
        /// </summary>
        public GlobalCalendar()
        {
            this.DefaultStyleKey = typeof(GlobalCalendar);
            this.DisplayDate = DateTime.Today;
            this.GotFocus += this.Calendar_GotFocus;
            this.LostFocus += this.Calendar_LostFocus;
            this.IsEnabledChanged += this.OnIsEnabledChanged;
            this.MouseLeftButtonUp += this.Calendar_MouseLeftButtonUp;
            this.BlackoutDates = new GlobalCalendarBlackoutDatesCollection(this);
            this.SelectedDates = new GlobalSelectedDatesCollection(this);
            this.RemovedItems = new Collection<DateTime>();
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.DisplayDate" />
        /// property is changed.
        /// </summary>
        /// <remarks>
        /// This event occurs after DisplayDate is assigned its new value.
        /// </remarks>
        public event EventHandler<GlobalCalendarDateChangedEventArgs> DisplayDateChanged;

        /// <summary>
        /// Occurs when the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.DisplayMode" />
        /// property is changed.
        /// </summary>
        public event EventHandler<CalendarModeChangedEventArgs> DisplayModeChanged;

        /// <summary>
        /// Occurs when the collection returned by the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.SelectedDates" />
        /// property is changed.
        /// </summary>
        public event EventHandler<SelectionChangedEventArgs> SelectedDatesChanged;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        internal event MouseButtonEventHandler DayButtonMouseUp;

        #endregion

        #region Properties

        /// <summary>
        /// Gets a collection of dates that are marked as not selectable.
        /// </summary>
        /// <value>
        /// A collection of dates that cannot be selected. The default value is
        /// an empty collection.
        /// </value>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Adding a date to this collection when it is already selected or
        /// adding a date outside the range specified by DisplayDateStart and
        /// DisplayDateEnd.
        /// </exception>
        /// <remarks>
        /// <para>
        /// Dates in this collection will appear as disabled on the calendar.
        /// </para>
        /// <para>
        /// To make all past dates not selectable, you can use the
        /// AddDatesInPast method provided by the collection returned by this
        /// property.
        /// </para>
        /// </remarks>
        public GlobalCalendarBlackoutDatesCollection BlackoutDates { get; private set; }

        /// <summary>
        /// Gets or sets the <see cref="T:System.Windows.Style" /> associated
        /// with the control's internal
        /// <see cref="T:System.Windows.Controls.Primitives.GlobalCalendarButton" />
        /// object.
        /// </summary>
        /// <value>
        /// The current style of the
        /// <see cref="T:System.Windows.Controls.Primitives.GlobalCalendarButton" />
        /// object.
        /// </value>
        public Style CalendarButtonStyle
        {
            get { return (Style)this.GetValue(CalendarButtonStyleProperty); }
            set { this.SetValue(CalendarButtonStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the <see cref="T:System.Windows.Style" /> associated
        /// with the control's internal
        /// <see cref="T:System.Windows.Controls.Primitives.GlobalCalendarDayButton" />
        /// object.
        /// </summary>
        /// <value>
        /// The current style of the
        /// <see cref="T:System.Windows.Controls.Primitives.GlobalCalendarDayButton" />
        /// object.
        /// </value>
        public Style CalendarDayButtonStyle
        {
            get { return (Style)this.GetValue(CalendarDayButtonStyleProperty); }
            set { this.SetValue(CalendarDayButtonStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets a CalendarDayButtonStyleSelector that enables an application writer
        /// to provide custom style-selection logic for the day buttons.
        /// </summary>
        public CalendarDayButtonStyleSelector CalendarDayButtonStyleSelector
        {
            get { return this.GetValue(CalendarDayButtonStyleSelectorProperty) as CalendarDayButtonStyleSelector; }
            set { this.SetValue(CalendarDayButtonStyleSelectorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the CalendarInfo that provides globalized date
        /// operations.
        /// </summary>
        public CalendarInfo CalendarInfo
        {
            get { return this.GetValue(CalendarInfoProperty) as CalendarInfo; }
            set { this.SetValue(CalendarInfoProperty, value); }
        }

        /// <summary>
        /// Gets or sets the <see cref="T:System.Windows.Style" /> associated
        /// with the control's internal
        /// <see cref="T:System.Windows.Controls.Primitives.GlobalCalendarItem" />
        /// object.
        /// </summary>
        /// <value>
        /// The current style of the
        /// <see cref="T:System.Windows.Controls.Primitives.GlobalCalendarItem" />
        /// object.
        /// </value>
        public Style CalendarItemStyle
        {
            get { return (Style)this.GetValue(CalendarItemStyleProperty); }
            set { this.SetValue(CalendarItemStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the date to display.
        /// </summary>
        /// <value>The date to display.</value>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// The given date is not in the range specified by
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.DisplayDateStart" />
        /// and
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.DisplayDateEnd" />.
        /// </exception>
        /// <remarks>
        /// <para>
        /// This property allows the developer to specify a date to display.  If
        /// this property is a null reference (Nothing in Visual Basic),
        /// SelectedDate is displayed.  If SelectedDate is also a null reference
        /// (Nothing in Visual Basic), Today is displayed.  The default is
        /// Today.
        /// </para>
        /// <para>
        /// To set this property in XAML, use a date specified in the format
        /// yyyy/mm/dd.  The mm and dd components must always consist of two
        /// characters, with a leading zero if necessary.  For instance, the
        /// month of May should be specified as 05.
        /// </para>
        /// </remarks>
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
        /// <remarks>
        /// To set this property in XAML, use a date specified in the format
        /// yyyy/mm/dd.  The mm and dd components must always consist of two
        /// characters, with a leading zero if necessary.  For instance, the
        /// month of May should be specified as 05.
        /// </remarks>
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
        /// <remarks>
        /// To set this property in XAML, use a date specified in the format
        /// yyyy/mm/dd.  The mm and dd components must always consist of two
        /// characters, with a leading zero if necessary.  For instance, the
        /// month of May should be specified as 05.
        /// </remarks>
        [TypeConverter(typeof(DateTimeTypeConverter))]
        public DateTime? DisplayDateStart
        {
            get { return (DateTime?)this.GetValue(DisplayDateStartProperty); }
            set { this.SetValue(DisplayDateStartProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the calendar is displayed in
        /// months, years, or decades.
        /// </summary>
        /// <value>
        /// A value indicating what length of time the
        /// <see cref="T:Silverlight.Controls.GlobalCalendar" /> should display.
        /// </value>
        public CalendarMode DisplayMode
        {
            get { return (CalendarMode)this.GetValue(DisplayModeProperty); }
            set { this.SetValue(DisplayModeProperty, value); }
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
        /// Gets or sets a value indicating whether the current date is
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
        /// <value>The date currently selected. The default is null.</value>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// The given date is outside the range specified by
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.DisplayDateStart" />
        /// and <see cref="P:Silverlight.Controls.GlobalCalendar.DisplayDateEnd" />
        /// -or-
        /// The given date is in the
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.BlackoutDates" />
        /// collection.
        /// </exception>
        /// <exception cref="T:System.InvalidOperationException">
        /// If set to anything other than null when
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.SelectionMode" /> is
        /// set to
        /// <see cref="F:System.Windows.Controls.CalendarSelectionMode.None" />.
        /// </exception>
        /// <remarks>
        /// Use this property when SelectionMode is set to SingleDate.  In other
        /// modes, this property will always be the first date in SelectedDates.
        /// </remarks>
        [TypeConverter(typeof(DateTimeTypeConverter))]
        public DateTime? SelectedDate
        {
            get { return (DateTime?)this.GetValue(SelectedDateProperty); }
            set { this.SetValue(SelectedDateProperty, value); }
        }

        /// <summary>
        /// Gets a collection of selected dates.
        /// </summary>
        /// <value>
        /// A <see cref="T:System.Windows.Controls.GlobalSelectedDatesCollection" />
        /// object that contains the currently selected dates. The default is an
        /// empty collection.
        /// </value>
        /// <remarks>
        /// Dates can be added to the collection either individually or in a
        /// range using the AddRange method.  Depending on the value of the
        /// SelectionMode property, adding a date or range to the collection may
        /// cause it to be cleared.  The following table lists how
        /// CalendarSelectionMode affects the SelectedDates property.
        /// 
        ///     CalendarSelectionMode   Description
        ///     None                    No selections are allowed.  SelectedDate
        ///                             cannot be set and no values can be added
        ///                             to SelectedDates.
        ///                             
        ///     SingleDate              Only a single date can be selected,
        ///                             either by setting SelectedDate or the
        ///                             first value in SelectedDates.  AddRange
        ///                             cannot be used.
        ///                             
        ///     SingleRange             A single range of dates can be selected.
        ///                             Setting SelectedDate, adding a date
        ///                             individually to SelectedDates, or using
        ///                             AddRange will clear all previous values
        ///                             from SelectedDates.
        ///     MultipleRange           Multiple non-contiguous ranges of dates
        ///                             can be selected. Adding a date
        ///                             individually to SelectedDates or using
        ///                             AddRange will not clear SelectedDates.
        ///                             Setting SelectedDate will still clear
        ///                             SelectedDates, but additional dates or
        ///                             range can then be added.  Adding a range
        ///                             that includes some dates that are
        ///                             already selected or overlaps with
        ///                             another range results in the union of
        ///                             the ranges and does not cause an
        ///                             exception.
        /// </remarks>
        public GlobalSelectedDatesCollection SelectedDates { get; private set; }

        /// <summary>
        /// Gets or sets a value that indicates what kind of selections are
        /// allowed.
        /// </summary>
        /// <value>
        /// A value that indicates the current selection mode. The default is
        /// <see cref="F:System.Windows.Controls.CalendarSelectionMode.SingleDate" />.
        /// </value>
        /// <remarks>
        /// <para>
        /// This property determines whether the GlobalCalendar allows no selection,
        /// selection of a single date, or selection of multiple dates.  The
        /// selection mode is specified with the CalendarSelectionMode
        /// enumeration.
        /// </para>
        /// <para>
        /// When this property is changed, all selected dates will be cleared.
        /// </para>
        /// </remarks>
        public CalendarSelectionMode SelectionMode
        {
            get { return (CalendarSelectionMode)this.GetValue(SelectionModeProperty); }
            set { this.SetValue(SelectionModeProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether DatePicker should change its 
        /// DisplayDate because of a SelectedDate change on its GlobalCalendar.
        /// </summary>
        internal bool DatePickerDisplayDateFlag { get; set; }

        /// <summary>
        /// Gets Inherited code: Requires comment.
        /// </summary>
        internal DateTime DisplayDateInternal { get; private set; }

        /// <summary>
        /// Gets Inherited code: Requires comment.
        /// </summary>
        internal DateTime DisplayDateRangeEnd
        {
            get { return this.DisplayDateEnd.GetValueOrDefault(DateTime.MaxValue); }
        }

        /// <summary>
        /// Gets Inherited code: Requires comment.
        /// </summary>
        internal DateTime DisplayDateRangeStart
        {
            get { return this.DisplayDateStart.GetValueOrDefault(DateTime.MinValue); }
        }

        /// <summary>
        /// Gets the day that is considered the beginning of the week.
        /// </summary>
        internal DayOfWeek FirstDay
        {
            get
            {
                return (this.ReadLocalValue(FirstDayOfWeekProperty) == DependencyProperty.UnsetValue) ?
                                                                                                          this.Info.FirstDayOfWeek :
                                                                                                                                       this.FirstDayOfWeek;
            }
        }

        /// <summary>
        /// Gets or sets Inherited code: Requires comment.
        /// </summary>
        internal GlobalCalendarDayButton FocusButton { get; set; }

        /// <summary>
        /// Gets or sets Inherited code: Requires comment.
        /// </summary>
        internal GlobalCalendarButton FocusCalendarButton { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Inherited code: Requires comment.
        /// </summary>
        internal bool HasFocusInternal { get; set; }

        /// <summary>
        /// Gets or sets Inherited code: Requires comment.
        /// </summary>
        internal DateTime? HoverEnd
        {
            get { return this.HoverEndInternal; }
            set
            {
                this.HoverEndInternal = value;
                this.LastSelectedDate = value;
            }
        }

        /// <summary>
        /// Gets or sets Inherited code: Requires comment.
        /// </summary>
        internal int? HoverEndIndex { get; set; }

        /// <summary>
        /// Gets or sets Inherited code: Requires comment.
        /// </summary>
        internal DateTime? HoverEndInternal { get; set; }

        /// <summary>
        /// Gets or sets Inherited code: Requires comment.
        /// </summary>
        internal DateTime? HoverStart { get; set; }

        /// <summary>
        /// Gets or sets Inherited code: Requires comment.
        /// </summary>
        internal int? HoverStartIndex { get; set; }

        /// <summary>
        /// Gets the <see cref="CalendarInfo"/> that provides globalized date operations.
        /// </summary>
        internal CalendarInfo Info
        {
            get { return this.CalendarInfo ?? DefaultCalendarInfo; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether Inherited code: Requires comment.
        /// </summary>
        internal bool IsMouseSelection { get; set; }

        /// <summary>
        /// Gets or sets Inherited code: Requires comment.
        /// </summary>
        internal DateTime? LastSelectedDate
        {
            get { return this.LastSelectedDateInternal; }
            set
            {
                this.LastSelectedDateInternal = value;

                if( this.SelectionMode == CalendarSelectionMode.None )
                {
                    if( this.FocusButton != null )
                        this.FocusButton.IsCurrent = false;
                    this.FocusButton = this.FindDayButtonFromDay(this.LastSelectedDate.Value);
                    if( this.FocusButton != null )
                        this.FocusButton.IsCurrent = this.HasFocusInternal;
                }
            }
        }

        /// <summary>
        /// Gets or sets Inherited code: Requires comment.
        /// </summary>
        internal DateTime? LastSelectedDateInternal { get; set; }

        /// <summary>
        /// Gets Inherited code: Requires comment.
        /// </summary>
        internal GlobalCalendarItem MonthControl
        {
            get
            {
                if( this.Root != null && this.Root.Children.Count > 0 )
                    return this.Root.Children[0] as GlobalCalendarItem;
                return null;
            }
        }

        /// <summary>
        /// Gets or sets Inherited code: Requires comment.
        /// </summary>
        internal Collection<DateTime> RemovedItems { get; set; }

        /// <summary>
        /// Gets or sets Inherited code: Requires comment.
        /// </summary>
        internal Panel Root { get; set; }

        /// <summary>
        /// Gets or sets Inherited code: Requires comment.
        /// </summary>
        internal DateTime SelectedMonth
        {
            get { return this._selectedMonth; }
            set
            {
                int monthDifferenceStart = this.Info.GetMonthDifference(value, this.DisplayDateRangeStart);
                int monthDifferenceEnd = this.Info.GetMonthDifference(value, this.DisplayDateRangeEnd);

                if( monthDifferenceStart >= 0 && monthDifferenceEnd <= 0 )
                    this._selectedMonth = this.Info.GetFirstDayInMonth(value);
                else
                {
                    if( monthDifferenceStart < 0 )
                        this._selectedMonth = this.Info.GetFirstDayInMonth(this.DisplayDateRangeStart);
                    else
                    {
                        Debug.Assert(monthDifferenceEnd > 0, "monthDifferenceEnd should be greater than 0!");
                        this._selectedMonth = this.Info.GetFirstDayInMonth(this.DisplayDateRangeEnd);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets Inherited code: Requires comment.
        /// </summary>
        internal DateTime SelectedYear
        {
            get { return this._selectedYear; }
            set
            {
                if( value.Year < this.DisplayDateRangeStart.Year )
                    this._selectedYear = this.DisplayDateRangeStart;
                else
                {
                    if( value.Year > this.DisplayDateRangeEnd.Year )
                        this._selectedYear = this.DisplayDateRangeEnd;
                    else
                        this._selectedYear = value;
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Builds the visual tree for the
        /// <see cref="T:Silverlight.Controls.GlobalCalendar"/> when a new
        /// template is applied.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.Root = this.GetTemplateChild(ElementRoot) as Panel;

            this.SelectedMonth = this.DisplayDate;
            this.SelectedYear = this.DisplayDate;

            if( this.Root != null )
            {
                var month = this.GetTemplateChild(ElementMonth) as GlobalCalendarItem;
                if( month != null )
                {
                    month.Owner = this;
                    if( this.CalendarItemStyle != null )
                        month.Style = this.CalendarItemStyle;
                }
            }

            this.SizeChanged += this.Calendar_SizeChanged;
            this.KeyDown += this.Calendar_KeyDown;
            this.KeyUp += this.Calendar_KeyUp;
        }

        /// <summary>
        /// Provides a text representation of the selected date.
        /// </summary>
        /// <returns>
        /// A text representation of the selected date, or an empty string if
        /// <see cref="P:Silverlight.Controls.GlobalCalendar.SelectedDate"/> is
        /// null.
        /// </returns>
        public override string ToString()
        {
            return (this.SelectedDate != null) ?
                                                   this.Info.DateToString(this.SelectedDate.Value) :
                                                                                                       string.Empty;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="cal">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="value">
        /// Inherited code: Requires comment 2.
        /// </param>
        /// <returns>
        /// Inherited code: Requires comment 3.
        /// </returns>
        internal static bool IsValidDateSelection(GlobalCalendar cal, object value)
        {
            if( value == null )
                return true;
            else if( cal.BlackoutDates.Contains((DateTime)value) )
                return false;
            else if( cal.Info.Compare((DateTime)value, cal.DisplayDateRangeStart) < 0 )
                cal.SetValueNoCallback(DisplayDateStartProperty, value);
            else if( cal.Info.Compare((DateTime)value, cal.DisplayDateRangeEnd) > 0 )
                cal.SetValueNoCallback(DisplayDateEndProperty, value);

            return true;
        }

        /// <summary>
        /// Apply a Style to a GlobalCalendarDayButton.
        /// </summary>
        /// <param name="button">
        /// The button.
        /// </param>
        internal void ApplyDayButtonStyle(GlobalCalendarDayButton button)
        {
            Debug.Assert(button != null, "button should not be null!");

            DateTime? date = button.GetDateNullable();
            CalendarDayButtonStyleSelector selector = this.CalendarDayButtonStyleSelector;
            Style style = this.CalendarDayButtonStyle;

            button.Style = (selector != null && date != null) ?
                                                                  selector.SelectStyle(date.Value, button) ?? style :
                                                                                                                        style;
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
        internal void Calendar_KeyDown(object sender, KeyEventArgs e)
        {
            var c = sender as GlobalCalendar;
            Debug.Assert(c != null, "c should not be null!");

            if( !e.Handled && c.IsEnabled )
                e.Handled = this.ProcessCalendarKey(e);
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="day">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <returns>
        /// Inherited code: Requires comment 2.
        /// </returns>
        internal GlobalCalendarDayButton FindDayButtonFromDay(DateTime day)
        {
            int count = RowsPerMonth * ColumnsPerMonth;

            GlobalCalendarItem monthControl = this.MonthControl;
            if( monthControl != null && monthControl.MonthView != null )
            {
                for( int childIndex = ColumnsPerMonth; childIndex < count; childIndex++ )
                {
                    var b = monthControl.MonthView.Children[childIndex] as GlobalCalendarDayButton;

                    DateTime? d = b.GetDateNullable();
                    if( d != null )
                    {
                        if( this.Info.CompareDays(d.Value, day) == 0 )
                            return b;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// This method highlights the days in MultiSelection mode without
        /// adding them to the SelectedDates collection.
        /// </summary>
        internal void HighlightDays()
        {
            if( this.HoverEnd != null && this.HoverStart != null )
            {
                int startIndex, endIndex, i;
                GlobalCalendarItem monthControl = this.MonthControl;

                // This assumes a contiguous set of dates:
                if( this.HoverEndIndex != null && this.HoverStartIndex != null )
                {
                    this.SortHoverIndexes(out startIndex, out endIndex);

                    for( i = startIndex; i <= endIndex; i++ )
                    {
                        var b = monthControl.MonthView.Children[i] as GlobalCalendarDayButton;
                        b.IsSelected = true;
                        DateTime? d = b.GetDateNullable();

                        if( d.HasValue && this.Info.CompareDays(this.HoverEnd.Value, d.Value) == 0 )
                        {
                            if( this.FocusButton != null )
                                this.FocusButton.IsCurrent = false;
                            b.IsCurrent = this.HasFocusInternal;
                            this.FocusButton = b;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="e">
        /// Inherited code: Requires comment 1.
        /// </param>
        internal void OnDayButtonMouseUp(MouseButtonEventArgs e)
        {
            MouseButtonEventHandler handler = this.DayButtonMouseUp;
            if( null != handler )
                handler(this, e);
        }

        /// <summary>
        /// If the day is a trailing day, Update the DisplayDate.
        /// </summary>
        /// <param name="selectedDate">
        /// Inherited code: Requires comment.
        /// </param>
        internal void OnDayClick(DateTime selectedDate)
        {
            Debug.Assert(this.DisplayMode == CalendarMode.Month, "DisplayMode should be Month!");
            int i = this.Info.GetMonthDifference(selectedDate, this.DisplayDateInternal);

            if( this.SelectionMode == CalendarSelectionMode.None )
                this.LastSelectedDate = selectedDate;

            if( i > 0 )
                this.OnNextClick();
            else if( i < 0 )
                this.OnPreviousClick();
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        internal void OnHeaderClick()
        {
            Debug.Assert(this.DisplayMode == CalendarMode.Year || this.DisplayMode == CalendarMode.Decade, "The DisplayMode should be Year or Decade");
            GlobalCalendarItem monthControl = this.MonthControl;
            if( monthControl != null && monthControl.MonthView != null && monthControl.YearView != null )
            {
                monthControl.MonthView.Visibility = Visibility.Collapsed;
                monthControl.YearView.Visibility = Visibility.Visible;
                this.UpdateMonths();
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        internal void OnNextClick()
        {
            if( this.DisplayMode == CalendarMode.Month && this.DisplayDate != null )
            {
                DateTime? d = this.Info.AddMonths(this.Info.GetFirstDayInMonth(this.DisplayDate), 1);
                if( d.HasValue )
                {
                    if( !this.LastSelectedDate.HasValue || this.Info.GetMonthDifference(this.Info.GetFirstDayInMonth(this.LastSelectedDate.Value), d.Value) != 0 )
                        this.LastSelectedDate = d.Value;
                    this.DisplayDate = d.Value;
                }
            }
            else
            {
                if( this.DisplayMode == CalendarMode.Year )
                {
                    DateTime? d = this.Info.AddYears(this.Info.GetFirstDayInYear(this.SelectedMonth), 1);
                    this.SelectedMonth = (d != null) ?
                                                         d.Value :
                                                                     this.Info.GetFirstDayInMonth(this.DisplayDateRangeEnd);
                }
                else
                {
                    Debug.Assert(this.DisplayMode == CalendarMode.Decade, "DisplayMode should be Decade");
                    DateTime? d = this.Info.AddYears(this.Info.GetFirstDayInYear(this.SelectedYear), 10);
                    if( d != null )
                    {
                        int decade = Math.Max(1, this.Info.GetDecadeStart(d.Value));
                        this.SelectedYear = new DateTime(decade, 1, 1);
                    }
                    else
                        this.SelectedYear = this.Info.GetFirstDayInMonth(this.DisplayDateRangeEnd);
                }

                this.UpdateMonths();
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        internal void OnPreviousClick()
        {
            if( this.DisplayMode == CalendarMode.Month && this.DisplayDate != null )
            {
                DateTime? d = this.Info.AddMonths(this.Info.GetFirstDayInMonth(this.DisplayDate), -1);
                if( d.HasValue )
                {
                    if( !this.LastSelectedDate.HasValue || this.Info.GetMonthDifference(this.LastSelectedDate.Value, d.Value) != 0 )
                        this.LastSelectedDate = d.Value;
                    this.DisplayDate = d.Value;
                }
            }
            else
            {
                if( this.DisplayMode == CalendarMode.Year )
                {
                    DateTime? d = this.Info.AddYears(this.Info.GetFirstDayInYear(this.SelectedMonth), -1);
                    this.SelectedMonth = (d != null) ?
                                                         d.Value :
                                                                     this.Info.GetFirstDayInMonth(this.DisplayDateRangeStart);
                }
                else
                {
                    Debug.Assert(this.DisplayMode == CalendarMode.Decade, "DisplayMode should be Decade!");
                    DateTime? d = this.Info.AddYears(this.Info.GetFirstDayInYear(this.SelectedYear), -10);
                    if( d != null )
                    {
                        int decade = Math.Max(1, this.Info.GetDecadeStart(d.Value));
                        this.SelectedYear = new DateTime(decade, 1, 1);
                    }
                    else
                        this.SelectedYear = this.Info.GetFirstDayInMonth(this.DisplayDateRangeStart);
                }

                this.UpdateMonths();
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="e">
        /// Inherited code: Requires comment 1.
        /// </param>
        internal void OnSelectedDatesCollectionChanged(SelectionChangedEventArgs e)
        {
            if( IsSelectionChanged(e) )
            {
                EventHandler<SelectionChangedEventArgs> handler = this.SelectedDatesChanged;

                if( null != handler )
                    handler(this, e);

                // if( AutomationPeer.ListenerExists(AutomationEvents.SelectionItemPatternOnElementSelected) ||
                // AutomationPeer.ListenerExists(AutomationEvents.SelectionItemPatternOnElementAddedToSelection) ||
                // AutomationPeer.ListenerExists(AutomationEvents.SelectionItemPatternOnElementRemovedFromSelection) )
                // {
                // GlobalCalendarAutomationPeer peer = FrameworkElementAutomationPeer.FromElement(this) as GlobalCalendarAutomationPeer;
                // if( peer != null )
                // {
                // peer.RaiseSelectionEvents(e);
                // }
                // }
            }
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
        internal bool ProcessCalendarKey(KeyEventArgs e)
        {
            if( this.DisplayMode == CalendarMode.Month )
            {
                if( this.LastSelectedDate.HasValue && this.DisplayDateInternal != null )
                {
                    // If a blackout day is inactive, when clicked on it, the
                    // previous inactive day which is not a blackout day can get
                    // the focus.  In this case we should allow keyboard
                    // functions on that inactive day
                    if( this.Info.GetMonthDifference(this.LastSelectedDate.Value, this.DisplayDateInternal) != 0 && this.FocusButton != null && !this.FocusButton.IsInactive )
                        return true;
                }
            }

            // Some keys (e.g. Left/Right) need to be translated in RightToLeft mode
            Key invariantKey = InteractionHelper.GetLogicalKey(this.FlowDirection, e.Key);

            bool ctrl, shift;
            CalendarExtensions.GetMetaKeyState(out ctrl, out shift);

            switch( invariantKey )
            {
                case Key.Up:
                {
                    this.ProcessUpKey(ctrl, shift);
                    return true;
                }

                case Key.Down:
                {
                    this.ProcessDownKey(ctrl, shift);
                    return true;
                }

                case Key.Left:
                {
                    this.ProcessLeftKey(shift);
                    return true;
                }

                case Key.Right:
                {
                    this.ProcessRightKey(shift);
                    return true;
                }

                case Key.PageDown:
                {
                    this.ProcessPageDownKey(shift);
                    return true;
                }

                case Key.PageUp:
                {
                    this.ProcessPageUpKey(shift);
                    return true;
                }

                case Key.Home:
                {
                    this.ProcessHomeKey(ctrl, shift);
                    return true;
                }

                case Key.End:
                {
                    this.ProcessEndKey(shift);
                    return true;
                }

                case Key.Enter:
                case Key.Space:
                {
                    return this.ProcessEnterKey();
                }
            }

            return false;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="ctrl">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="shift">
        /// Inherited code: Requires comment 2.
        /// </param>
        internal void ProcessDownKey(bool ctrl, bool shift)
        {
            switch( this.DisplayMode )
            {
                case CalendarMode.Month:
                {
                    if( !ctrl || shift )
                    {
                        DateTime? selectedDate = this.Info.AddDays(this.LastSelectedDate.GetValueOrDefault(DateTime.Today), ColumnsPerMonth);
                        this.ProcessSelection(shift, selectedDate, ColumnsPerMonth);
                    }

                    break;
                }

                case CalendarMode.Year:
                {
                    if( ctrl )
                    {
                        this.DisplayDate = this.SelectedMonth;
                        this.DisplayMode = CalendarMode.Month;
                    }
                    else
                    {
                        DateTime? selectedMonth = this.Info.AddMonths(this._selectedMonth, ColumnsPerYear);
                        this.OnSelectedMonthChanged(selectedMonth);
                    }

                    break;
                }

                case CalendarMode.Decade:
                {
                    if( ctrl )
                    {
                        this.SelectedMonth = this.SelectedYear;
                        this.DisplayMode = CalendarMode.Year;
                    }
                    else
                    {
                        DateTime? selectedYear = this.Info.AddYears(this.SelectedYear, ColumnsPerYear);
                        this.OnSelectedYearChanged(selectedYear);
                    }

                    break;
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="shift">
        /// Inherited code: Requires comment 1.
        /// </param>
        internal void ProcessEndKey(bool shift)
        {
            switch( this.DisplayMode )
            {
                case CalendarMode.Month:
                {
                    if( this.DisplayDate != null )
                    {
                        DateTime? selectedDate = new DateTime(this.DisplayDateInternal.Year, this.DisplayDateInternal.Month, 1);

                        if( this.Info.GetMonthDifference(DateTime.MaxValue, selectedDate.Value) > 0 )
                        {
                            // since DisplayDate is not equal to
                            // DateTime.MaxValue we are sure selectedDate is\
                            // not null
                            selectedDate = this.Info.AddMonths(selectedDate.Value, 1).Value;
                            selectedDate = this.Info.AddDays(selectedDate.Value, -1).Value;
                        }
                        else
                            selectedDate = DateTime.MaxValue;
                        this.ProcessSelection(shift, selectedDate, null);
                    }

                    break;
                }

                case CalendarMode.Year:
                {
                    var selectedMonth = new DateTime(this._selectedMonth.Year, 12, 1);
                    this.OnSelectedMonthChanged(selectedMonth);
                    break;
                }

                case CalendarMode.Decade:
                {
                    DateTime? selectedYear = new DateTime(this.Info.GetDecadeEnd(this.SelectedYear), 1, 1);
                    this.OnSelectedYearChanged(selectedYear);
                    break;
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="ctrl">
        /// A value indicating whether the Control key is pressed.
        /// </param>
        /// <param name="shift">
        /// A value indicating whether the Shift key is pressed.
        /// </param>
        internal void ProcessHomeKey(bool ctrl, bool shift)
        {
            if( ctrl )
            {
                this.DisplayMode = CalendarMode.Month;
                this.DisplayDate = DateTime.Today;

                DateTime? selectedDate = DateTime.Today;
                this.ProcessSelection(shift, selectedDate, null);
            }
            else
            {
                switch( this.DisplayMode )
                {
                    case CalendarMode.Month:
                    {
                        DateTime? selectedDate = this.Info.GetFirstDayInMonth(this.DisplayDateInternal);
                        this.ProcessSelection(shift, selectedDate, null);
                        break;
                    }

                    case CalendarMode.Year:
                    {
                        DateTime selectedMonth = this.Info.GetFirstDayInYear(this._selectedMonth);
                        this.OnSelectedMonthChanged(selectedMonth);
                        break;
                    }

                    case CalendarMode.Decade:
                    {
                        DateTime? selectedYear = new DateTime(this.Info.GetDecadeStart(this.SelectedYear), 1, 1);
                        this.OnSelectedYearChanged(selectedYear);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="shift">
        /// Inherited code: Requires comment 1.
        /// </param>
        internal void ProcessLeftKey(bool shift)
        {
            switch( this.DisplayMode )
            {
                case CalendarMode.Month:
                {
                    DateTime? selectedDate = this.Info.AddDays(this.LastSelectedDate.GetValueOrDefault(DateTime.Today), -1);
                    this.ProcessSelection(shift, selectedDate, -1);
                    break;
                }

                case CalendarMode.Year:
                {
                    DateTime? selectedMonth = this.Info.AddMonths(this._selectedMonth, -1);
                    this.OnSelectedMonthChanged(selectedMonth);
                    break;
                }

                case CalendarMode.Decade:
                {
                    DateTime? selectedYear = this.Info.AddYears(this.SelectedYear, -1);
                    this.OnSelectedYearChanged(selectedYear);
                    break;
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="shift">
        /// Inherited code: Requires comment 1.
        /// </param>
        internal void ProcessPageDownKey(bool shift)
        {
            switch( this.DisplayMode )
            {
                case CalendarMode.Month:
                {
                    DateTime? selectedDate = this.Info.AddMonths(this.LastSelectedDate.GetValueOrDefault(DateTime.Today), 1);
                    this.ProcessSelection(shift, selectedDate, null);
                    break;
                }

                case CalendarMode.Year:
                {
                    DateTime? selectedMonth = this.Info.AddYears(this._selectedMonth, 1);
                    this.OnSelectedMonthChanged(selectedMonth);
                    break;
                }

                case CalendarMode.Decade:
                {
                    DateTime? selectedYear = this.Info.AddYears(this.SelectedYear, 10);
                    this.OnSelectedYearChanged(selectedYear);
                    break;
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="shift">
        /// Inherited code: Requires comment 1.
        /// </param>
        internal void ProcessPageUpKey(bool shift)
        {
            switch( this.DisplayMode )
            {
                case CalendarMode.Month:
                {
                    DateTime? selectedDate = this.Info.AddMonths(this.LastSelectedDate.GetValueOrDefault(DateTime.Today), -1);
                    this.ProcessSelection(shift, selectedDate, null);
                    break;
                }

                case CalendarMode.Year:
                {
                    DateTime? selectedMonth = this.Info.AddYears(this._selectedMonth, -1);
                    this.OnSelectedMonthChanged(selectedMonth);
                    break;
                }

                case CalendarMode.Decade:
                {
                    DateTime? selectedYear = this.Info.AddYears(this.SelectedYear, -10);
                    this.OnSelectedYearChanged(selectedYear);
                    break;
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="shift">
        /// Inherited code: Requires comment 1.
        /// </param>
        internal void ProcessRightKey(bool shift)
        {
            switch( this.DisplayMode )
            {
                case CalendarMode.Month:
                {
                    DateTime? selectedDate = this.Info.AddDays(this.LastSelectedDate.GetValueOrDefault(DateTime.Today), 1);
                    this.ProcessSelection(shift, selectedDate, 1);
                    break;
                }

                case CalendarMode.Year:
                {
                    DateTime? selectedMonth = this.Info.AddMonths(this._selectedMonth, 1);
                    this.OnSelectedMonthChanged(selectedMonth);
                    break;
                }

                case CalendarMode.Decade:
                {
                    DateTime? selectedYear = this.Info.AddYears(this.SelectedYear, 1);
                    this.OnSelectedYearChanged(selectedYear);
                    break;
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        internal void ProcessShiftKeyUp()
        {
            if( this._isShiftPressed && (this.SelectionMode == CalendarSelectionMode.SingleRange || this.SelectionMode == CalendarSelectionMode.MultipleRange) )
            {
                this.AddSelection();
                this._isShiftPressed = false;
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="ctrl">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="shift">
        /// Inherited code: Requires comment 2.
        /// </param>
        internal void ProcessUpKey(bool ctrl, bool shift)
        {
            switch( this.DisplayMode )
            {
                case CalendarMode.Month:
                {
                    if( ctrl )
                    {
                        this.SelectedMonth = this.DisplayDateInternal;
                        this.DisplayMode = CalendarMode.Year;
                    }
                    else
                    {
                        DateTime? selectedDate = this.Info.AddDays(this.LastSelectedDate.GetValueOrDefault(DateTime.Today), -ColumnsPerMonth);
                        this.ProcessSelection(shift, selectedDate, -ColumnsPerMonth);
                    }

                    break;
                }

                case CalendarMode.Year:
                {
                    if( ctrl )
                    {
                        this.SelectedYear = this.SelectedMonth;
                        this.DisplayMode = CalendarMode.Decade;
                    }
                    else
                    {
                        DateTime? selectedMonth = this.Info.AddMonths(this._selectedMonth, -ColumnsPerYear);
                        this.OnSelectedMonthChanged(selectedMonth);
                    }

                    break;
                }

                case CalendarMode.Decade:
                {
                    if( !ctrl )
                    {
                        DateTime? selectedYear = this.Info.AddYears(this.SelectedYear, -ColumnsPerYear);
                        this.OnSelectedYearChanged(selectedYear);
                    }

                    break;
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        internal void ResetStates()
        {
            GlobalCalendarDayButton d;
            GlobalCalendarItem monthControl = this.MonthControl;
            int count = RowsPerMonth * ColumnsPerMonth;
            if( monthControl != null )
            {
                if( monthControl.MonthView != null )
                {
                    for( int childIndex = ColumnsPerMonth; childIndex < count; childIndex++ )
                    {
                        d = monthControl.MonthView.Children[childIndex] as GlobalCalendarDayButton;
                        d.IgnoreMouseOverState();
                    }
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="startIndex">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="endIndex">
        /// Inherited code: Requires comment 2.
        /// </param>
        internal void SortHoverIndexes(out int startIndex, out int endIndex)
        {
            // not comparing indexes since the two days may not be on the same
            // month
            // REMOVE_RTM: this assumes that the two indexes are on the same month
            // should be updated if MultiCalendar support is added
            if( this.Info.CompareDays(this.HoverEnd.Value, this.HoverStart.Value) > 0 )
            {
                startIndex = this.HoverStartIndex.Value;
                endIndex = this.HoverEndIndex.Value;
            }
            else
            {
                startIndex = this.HoverEndIndex.Value;
                endIndex = this.HoverStartIndex.Value;
            }
        }

        /// <summary>
        /// This method un-highlights the days that were hovered over but not
        /// added to the SelectedDates collection or un-highlighted the
        /// previously selected days in SingleRange Mode.
        /// </summary>
        internal void UnHighlightDays()
        {
            if( this.HoverEnd != null && this.HoverStart != null )
            {
                GlobalCalendarItem monthControl = this.MonthControl;
                if( this.HoverEndIndex != null && this.HoverStartIndex != null )
                {
                    int startIndex, endIndex;
                    this.SortHoverIndexes(out startIndex, out endIndex);

                    if( this.SelectionMode == CalendarSelectionMode.MultipleRange )
                    {
                        for( int i = startIndex; i <= endIndex; i++ )
                        {
                            var b = monthControl.MonthView.Children[i] as GlobalCalendarDayButton;
                            DateTime? d = b.GetDateNullable();
                            if( d != null )
                            {
                                if( !this.SelectedDates.Contains(d.Value) )
                                    b.IsSelected = false;
                            }
                        }
                    }
                    else
                    {
                        // It is SingleRange
                        for( int i = startIndex; i <= endIndex; i++ )
                        {
                            (monthControl.MonthView.Children[i] as GlobalCalendarDayButton).IsSelected = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        internal void UpdateMonths()
        {
            GlobalCalendarItem monthControl = this.MonthControl;
            if( monthControl != null )
            {
                switch( this.DisplayMode )
                {
                    case CalendarMode.Month:
                    {
                        monthControl.UpdateMonthMode();
                        break;
                    }

                    case CalendarMode.Year:
                    {
                        monthControl.UpdateYearMode();
                        break;
                    }

                    case CalendarMode.Decade:
                    {
                        monthControl.UpdateDecadeMode();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Mouse wheel handler simulates (Ctrl+)PageUp/Down.
        /// </summary>
        /// <param name="e">
        /// Event arguments.
        /// </param>
        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
            if( !e.Handled )
            {
                bool ctrl;
                bool shift;
                CalendarExtensions.GetMetaKeyState(out ctrl, out shift);

                if( !ctrl )
                {
                    if( e.Delta > 0 )
                        this.ProcessPageUpKey(false);
                    else
                        this.ProcessPageDownKey(false);
                }
                else
                {
                    if( e.Delta > 0 )
                        this.ProcessDownKey(ctrl, shift);
                    else
                        this.ProcessUpKey(ctrl, shift);
                }

                e.Handled = true;
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="calendarButton">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="calendarButtonStyle">
        /// Inherited code: Requires comment 2.
        /// </param>
        private static void EnsureCalendarButtonStyle(GlobalCalendarButton calendarButton, Style calendarButtonStyle)
        {
            Debug.Assert(calendarButton != null, "The calendarButton should not be null!");
            if( calendarButtonStyle != null && calendarButton != null )
                calendarButton.Style = calendarButtonStyle;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="month">
        /// Inherited code: Requires comment 1 .
        /// </param>
        /// <param name="monthStyle">
        /// Inherited code: Requires comment 2 .
        /// </param>
        private static void EnsureMonthStyle(GlobalCalendarItem month, Style monthStyle)
        {
            Debug.Assert(month != null, "month should not be null!");
            if( monthStyle != null && month != null )
                month.Style = monthStyle;
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
        private static bool IsSelectionChanged(SelectionChangedEventArgs e)
        {
            if( e.AddedItems.Count != e.RemovedItems.Count )
                return true;
            foreach( DateTime addedDate in e.AddedItems )
            {
                if( !e.RemovedItems.Contains(addedDate) )
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="mode">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <returns>
        /// Inherited code: Requires comment 2.
        /// </returns>
        private static bool IsValidDisplayMode(CalendarMode mode)
        {
            return mode == CalendarMode.Month
                   || mode == CalendarMode.Year
                   || mode == CalendarMode.Decade;
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
        private static bool IsValidFirstDayOfWeek(object value)
        {
            var day = (DayOfWeek)value;

            return day == DayOfWeek.Sunday
                   || day == DayOfWeek.Monday
                   || day == DayOfWeek.Tuesday
                   || day == DayOfWeek.Wednesday
                   || day == DayOfWeek.Thursday
                   || day == DayOfWeek.Friday
                   || day == DayOfWeek.Saturday;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="cal">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="value">
        /// Inherited code: Requires comment 2.
        /// </param>
        /// <returns>
        /// Inherited code: Requires comment 3.
        /// </returns>
        private static bool IsValidKeyboardSelection(GlobalCalendar cal, object value)
        {
            if( value == null )
                return true;
            else
            {
                if( cal.BlackoutDates.Contains((DateTime)value) )
                    return false;
                else
                {
                    return cal.Info.Compare((DateTime)value, cal.DisplayDateRangeStart) >= 0 &&
                           cal.Info.Compare((DateTime)value, cal.DisplayDateRangeEnd) <= 0;
                }
            }
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
        private static bool IsValidSelectionMode(object value)
        {
            var mode = (CalendarSelectionMode)value;

            return mode == CalendarSelectionMode.SingleDate
                   || mode == CalendarSelectionMode.SingleRange
                   || mode == CalendarSelectionMode.MultipleRange
                   || mode == CalendarSelectionMode.None;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="d">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="e">
        /// Inherited code: Requires comment 2.
        /// </param>
        private static void OnCalendarButtonStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newStyle = e.NewValue as Style;
            var c = d as GlobalCalendar;

            if( newStyle != null && c != null )
            {
                GlobalCalendarItem monthControl = c.MonthControl;
                if( monthControl != null && monthControl.YearView != null )
                {
                    foreach( UIElement child in monthControl.YearView.Children )
                    {
                        var calendarButton = child as GlobalCalendarButton;
                        if( calendarButton != null )
                            EnsureCalendarButtonStyle(calendarButton, newStyle);
                    }
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="d">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="e">
        /// Inherited code: Requires comment 2.
        /// </param>
        private static void OnCalendarDayButtonStyleOrSelectorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = d as GlobalCalendar;
            GlobalCalendarItem monthControl = c.MonthControl;
            if( monthControl != null && monthControl.MonthView != null )
            {
                foreach( UIElement child in monthControl.MonthView.Children )
                {
                    var dayButton = child as GlobalCalendarDayButton;
                    if( dayButton != null )
                        c.ApplyDayButtonStyle(dayButton);
                }
            }
        }

        /// <summary>
        /// <see cref="CalendarInfoProperty"/> property changed handler.
        /// </summary>
        /// <param name="d">
        /// <c>GlobalCalendar</c> that changed its <c>CalendarInfo</c>.
        /// </param>
        /// <param name="e">
        /// Event arguments.
        /// </param>
        private static void OnCalendarInfoPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var source = (GlobalCalendar)d;
            source.UpdateMonths();
            source.DisplayDate = DateTime.Now;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="d">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="e">
        /// Inherited code: Requires comment 2.
        /// </param>
        private static void OnCalendarItemStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newStyle = e.NewValue as Style;
            var c = d as GlobalCalendar;

            if( newStyle != null && c != null )
            {
                GlobalCalendarItem monthControl = c.MonthControl;
                if( monthControl != null )
                    EnsureMonthStyle(monthControl, newStyle);
            }
        }

        /// <summary>
        /// DisplayDateProperty property changed handler.
        /// </summary>
        /// <param name="d">
        /// GlobalCalendar that changed its DisplayDate.
        /// </param>
        /// <param name="e">
        /// The DependencyPropertyChangedEventArgs.
        /// </param>
        private static void OnDisplayDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = d as GlobalCalendar;
            Debug.Assert(c != null, "c should not be null!");
            DateTime removedDate, addedDate;

            addedDate = (DateTime)e.NewValue;
            removedDate = (DateTime)e.OldValue;

            // If DisplayDate < DisplayDateStart, DisplayDate = DisplayDateStart
            if( c.Info.Compare(addedDate, c.DisplayDateRangeStart) < 0 )
            {
                c.DisplayDate = c.DisplayDateRangeStart;
                return;
            }

            // If DisplayDate > DisplayDateEnd, DisplayDate = DisplayDateEnd
            if( c.Info.Compare(addedDate, c.DisplayDateRangeEnd) > 0 )
            {
                c.DisplayDate = c.DisplayDateRangeEnd;
                return;
            }

            c.DisplayDateInternal = c.Info.GetFirstDayInMonth(addedDate);
            c.UpdateMonths();
            c.OnDisplayDate(new GlobalCalendarDateChangedEventArgs(removedDate, addedDate));
        }

        /// <summary>
        /// DisplayDateEndProperty property changed handler.
        /// </summary>
        /// <param name="d">
        /// GlobalCalendar that changed its DisplayDateEnd.
        /// </param>
        /// <param name="e">
        /// The DependencyPropertyChangedEventArgs.
        /// </param>
        private static void OnDisplayDateEndChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = d as GlobalCalendar;
            Debug.Assert(c != null, "c should not be null!");

            if( !c.IsHandlerSuspended(DisplayDateEndProperty) )
            {
                var newValue = e.NewValue as DateTime?;

                if( newValue.HasValue )
                {
                    // DisplayDateEnd coerces to the value of the
                    // SelectedDateMax if SelectedDateMax > DisplayDateEnd
                    DateTime? selectedDateMax = SelectedDateMax(c);

                    if( selectedDateMax.HasValue && c.Info.Compare(selectedDateMax.Value, newValue.Value) > 0 )
                    {
                        c.DisplayDateEnd = selectedDateMax.Value;
                        return;
                    }

                    // if DisplayDateEnd < DisplayDateStart,
                    // DisplayDateEnd = DisplayDateStart
                    if( c.Info.Compare(newValue.Value, c.DisplayDateRangeStart) < 0 )
                    {
                        c.DisplayDateEnd = c.DisplayDateStart;
                        return;
                    }

                    // If DisplayDate > DisplayDateEnd,
                    // DisplayDate = DisplayDateEnd
                    if( c.Info.GetMonthDifference(newValue.Value, c.DisplayDateInternal) < 0 )
                        c.DisplayDate = newValue.Value;
                }

                c.UpdateMonths();
            }
        }

        /// <summary>
        /// DisplayDateStartProperty property changed handler.
        /// </summary>
        /// <param name="d">
        /// GlobalCalendar that changed its DisplayDateStart.
        /// </param>
        /// <param name="e">
        /// The DependencyPropertyChangedEventArgs.
        /// </param>
        private static void OnDisplayDateStartChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = d as GlobalCalendar;
            Debug.Assert(c != null, "c should not be null!");

            if( !c.IsHandlerSuspended(DisplayDateStartProperty) )
            {
                var newValue = e.NewValue as DateTime?;

                if( newValue.HasValue )
                {
                    // DisplayDateStart coerces to the value of the
                    // SelectedDateMin if SelectedDateMin < DisplayDateStart
                    DateTime? selectedDateMin = SelectedDateMin(c);

                    if( selectedDateMin.HasValue && c.Info.Compare(selectedDateMin.Value, newValue.Value) < 0 )
                    {
                        c.DisplayDateStart = selectedDateMin.Value;
                        return;
                    }

                    // if DisplayDateStart > DisplayDateEnd,
                    // DisplayDateEnd = DisplayDateStart
                    if( c.Info.Compare(newValue.Value, c.DisplayDateRangeEnd) > 0 )
                        c.DisplayDateEnd = c.DisplayDateStart;

                    // If DisplayDate < DisplayDateStart,
                    // DisplayDate = DisplayDateStart
                    if( c.Info.GetMonthDifference(newValue.Value, c.DisplayDateInternal) > 0 )
                        c.DisplayDate = newValue.Value;
                }

                c.UpdateMonths();
            }
        }

        /// <summary>
        /// DisplayModeProperty property changed handler.
        /// </summary>
        /// <param name="d">
        /// GlobalCalendar that changed its DisplayMode.
        /// </param>
        /// <param name="e">
        /// The DependencyPropertyChangedEventArgs.
        /// </param>
        private static void OnDisplayModePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = d as GlobalCalendar;
            Debug.Assert(c != null, "c should not be null!");
            var mode = (CalendarMode)e.NewValue;
            var oldMode = (CalendarMode)e.OldValue;
            GlobalCalendarItem monthControl = c.MonthControl;

            if( !c.IsHandlerSuspended(DisplayModeProperty) )
            {
                if( IsValidDisplayMode(mode) )
                {
                    if( monthControl != null )
                    {
                        switch( oldMode )
                        {
                            case CalendarMode.Month:
                            {
                                c.SelectedYear = c.DisplayDateInternal;
                                c.SelectedMonth = c.DisplayDateInternal;
                                break;
                            }

                            case CalendarMode.Year:
                            {
                                c.DisplayDate = c.SelectedMonth;
                                c.SelectedYear = c.SelectedMonth;
                                break;
                            }

                            case CalendarMode.Decade:
                            {
                                c.DisplayDate = c.SelectedYear;
                                c.SelectedMonth = c.SelectedYear;
                                break;
                            }
                        }

                        switch( mode )
                        {
                            case CalendarMode.Month:
                            {
                                c.OnMonthClick();
                                break;
                            }

                            case CalendarMode.Year:
                            case CalendarMode.Decade:
                            {
                                c.OnHeaderClick();
                                break;
                            }
                        }
                    }

                    c.OnDisplayModeChanged(new CalendarModeChangedEventArgs((CalendarMode)e.OldValue, mode));
                }
                else
                {
                    c.SetValueNoCallback(DisplayModeProperty, e.OldValue);
                    throw new ArgumentOutOfRangeException("d", Assets.Resources.ControlsStrings.Calendar_OnDisplayModePropertyChanged_InvalidValue);
                }
            }
        }

        /// <summary>
        /// FirstDayOfWeekProperty property changed handler.
        /// </summary>
        /// <param name="d">
        /// GlobalCalendar that changed its FirstDayOfWeek.
        /// </param>
        /// <param name="e">
        /// The DependencyPropertyChangedEventArgs.
        /// </param>
        private static void OnFirstDayOfWeekChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = d as GlobalCalendar;
            Debug.Assert(c != null, "c should not be null!");

            if( IsValidFirstDayOfWeek(e.NewValue) )
                c.UpdateMonths();
            else
                throw new ArgumentOutOfRangeException("d", Assets.Resources.ControlsStrings.Calendar_OnFirstDayOfWeekChanged_InvalidValue);
        }

        /// <summary>
        /// IsTodayHighlightedProperty property changed handler.
        /// </summary>
        /// <param name="d">
        /// GlobalCalendar that changed its IsTodayHighlighted.
        /// </param>
        /// <param name="e">
        /// The DependencyPropertyChangedEventArgs.
        /// </param>
        private static void OnIsTodayHighlightedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = d as GlobalCalendar;
            Debug.Assert(c != null, "c should not be null!");

            if( c.DisplayDate != null )
            {
                int i = c.Info.GetMonthDifference(c.DisplayDateInternal, DateTime.Today);

                if( i > -2 && i < 2 )
                    c.UpdateMonths();
            }
        }

        /// <summary>
        /// SelectedDateProperty property changed handler.
        /// </summary>
        /// <param name="d">
        /// GlobalCalendar that changed its SelectedDate.
        /// </param>
        /// <param name="e">
        /// The DependencyPropertyChangedEventArgs.
        /// </param>
        private static void OnSelectedDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = d as GlobalCalendar;
            Debug.Assert(c != null, "c should not be null!");

            if( !c.IsHandlerSuspended(SelectedDateProperty) )
            {
                if( c.SelectionMode != CalendarSelectionMode.None )
                {
                    DateTime? addedDate;

                    addedDate = (DateTime?)e.NewValue;

                    if( IsValidDateSelection(c, addedDate) )
                    {
                        if( addedDate == null )
                            c.SelectedDates.Clear();
                        else
                        {
                            if( addedDate.HasValue && !(c.SelectedDates.Count > 0 && c.SelectedDates[0] == addedDate.Value) )
                            {
                                foreach( var item in c.SelectedDates )
                                {
                                    c.RemovedItems.Add(item);
                                }

                                c.SelectedDates.ClearInternal();

                                // the value is added as a range so that the
                                // SelectedDatesChanged event can be thrown with
                                // all the removed items
                                c.SelectedDates.AddRange(addedDate.Value, addedDate.Value);
                            }
                        }

                        // We update the LastSelectedDate for only the Single
                        // mode.  For the other modes it automatically gets
                        // updated when the HoverEnd is updated.
                        if( c.SelectionMode == CalendarSelectionMode.SingleDate )
                            c.LastSelectedDate = addedDate;
                    }
                    else
                        throw new ArgumentOutOfRangeException("d", Assets.Resources.ControlsStrings.Calendar_OnSelectedDateChanged_InvalidValue);
                }
                else
                    throw new InvalidOperationException(Assets.Resources.ControlsStrings.Calendar_OnSelectedDateChanged_InvalidOperation);
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="d">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="e">
        /// Inherited code: Requires comment 2.
        /// </param>
        private static void OnSelectionModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var c = d as GlobalCalendar;
            Debug.Assert(c != null, "c should not be null!");

            if( IsValidSelectionMode(e.NewValue) )
            {
                c.SetValueNoCallback(SelectedDateProperty, null);
                c.SelectedDates.Clear();
            }
            else
                throw new ArgumentOutOfRangeException("d", Assets.Resources.ControlsStrings.Calendar_OnSelectionModeChanged_InvalidValue);
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="cal">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <returns>
        /// Inherited code: Requires comment 2.
        /// </returns>
        private static DateTime? SelectedDateMax(GlobalCalendar cal)
        {
            DateTime selectedDateMax;

            if( cal.SelectedDates.Count > 0 )
            {
                selectedDateMax = cal.SelectedDates[0];
                Debug.Assert(cal.Info.Compare(cal.SelectedDate.Value, selectedDateMax) == 0, "The SelectedDate should be the maximum SelectedDate!");
            }
            else
                return null;

            foreach( var selectedDate in cal.SelectedDates )
            {
                if( cal.Info.Compare(selectedDate, selectedDateMax) > 0 )
                    selectedDateMax = selectedDate;
            }

            return selectedDateMax;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="cal">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <returns>
        /// Inherited code: Requires comment 2.
        /// </returns>
        private static DateTime? SelectedDateMin(GlobalCalendar cal)
        {
            DateTime selectedDateMin;

            if( cal.SelectedDates.Count > 0 )
            {
                selectedDateMin = cal.SelectedDates[0];
                Debug.Assert(cal.Info.Compare(cal.SelectedDate.Value, selectedDateMin) == 0, "The SelectedDate should be the minimum selected date!");
            }
            else
                return null;

            foreach( var selectedDate in cal.SelectedDates )
            {
                if( cal.Info.Compare(selectedDate, selectedDateMin) < 0 )
                    selectedDateMin = selectedDate;
            }

            return selectedDateMin;
        }

        /// <summary>
        /// This method adds the days that were selected by Keyboard to the
        /// SelectedDays Collection.
        /// </summary>
        private void AddSelection()
        {
            if( this.HoverEnd != null && this.HoverStart != null )
            {
                foreach( var item in this.SelectedDates )
                {
                    this.RemovedItems.Add(item);
                }

                this.SelectedDates.ClearInternal();

                // In keyboard selection, we are sure that the collection does
                // not include any blackout days
                this.SelectedDates.AddRange(this.HoverStart.Value, this.HoverEnd.Value);
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
        private void Calendar_GotFocus(object sender, RoutedEventArgs e)
        {
            var c = sender as GlobalCalendar;
            Debug.Assert(c != null, "c should not be null!");
            this.HasFocusInternal = true;

            switch( this.DisplayMode )
            {
                case CalendarMode.Month:
                {
                    DateTime focusDate;
                    if( this.LastSelectedDate.HasValue && this.Info.GetMonthDifference(this.DisplayDateInternal, this.LastSelectedDate.Value) == 0 )
                        focusDate = this.LastSelectedDate.Value;
                    else
                    {
                        focusDate = this.DisplayDate;
                        this.LastSelectedDate = this.DisplayDate;
                    }

                    Debug.Assert(focusDate != null, "focusDate should not be null!");
                    this.FocusButton = this.FindDayButtonFromDay(focusDate);

                    if( this.FocusButton != null )
                        this.FocusButton.IsCurrent = true;
                    break;
                }

                case CalendarMode.Year:
                case CalendarMode.Decade:
                {
                    if( this.FocusCalendarButton != null )
                        this.FocusCalendarButton.IsCalendarButtonFocused = true;
                    break;
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
        private void Calendar_KeyUp(object sender, KeyEventArgs e)
        {
            if( !e.Handled && e.Key == Key.Shift )
                this.ProcessShiftKeyUp();
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="sender">
        /// Inherited code: Requires comment1 .
        /// </param>
        /// <param name="e">
        /// Inherited code: Requires comment 2.
        /// </param>
        private void Calendar_LostFocus(object sender, RoutedEventArgs e)
        {
            var c = sender as GlobalCalendar;
            Debug.Assert(c != null, "c should not be null!");
            this.HasFocusInternal = false;

            switch( this.DisplayMode )
            {
                case CalendarMode.Month:
                {
                    if( this.FocusButton != null )
                        this.FocusButton.IsCurrent = false;
                    break;
                }

                case CalendarMode.Year:
                case CalendarMode.Decade:
                {
                    if( this.FocusCalendarButton != null )
                        this.FocusCalendarButton.IsCalendarButtonFocused = false;
                    break;
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
        private void Calendar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if( !this.HasFocusInternal )
                this.Focus();
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
            Debug.Assert(sender is GlobalCalendar, "The sender should be a GlobalCalendar!");

            var rg = new RectangleGeometry();
            rg.Rect = new Rect(0, 0, e.NewSize.Width, e.NewSize.Height);

            if( this.Root != null )
                this.Root.Clip = rg;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="e">
        /// Inherited code: Requires comment 1.
        /// </param>
        private void OnDisplayDate(GlobalCalendarDateChangedEventArgs e)
        {
            EventHandler<GlobalCalendarDateChangedEventArgs> handler = this.DisplayDateChanged;
            if( null != handler )
                handler(this, e);
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="args">
        /// Inherited code: Requires comment 1.
        /// </param>
        private void OnDisplayModeChanged(CalendarModeChangedEventArgs args)
        {
            EventHandler<CalendarModeChangedEventArgs> handler = this.DisplayModeChanged;

            if( null != handler )
                handler(this, args);
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
            Debug.Assert(e.NewValue is bool, "NewValue should be a boolean!");
            var isEnabled = (bool)e.NewValue;

            if( this.MonthControl != null )
                this.MonthControl.UpdateDisabledGrid(isEnabled);
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private void OnMonthClick()
        {
            GlobalCalendarItem monthControl = this.MonthControl;
            if( monthControl != null &&
                monthControl.YearView != null &&
                monthControl.MonthView != null )
            {
                monthControl.YearView.Visibility = Visibility.Collapsed;
                monthControl.MonthView.Visibility = Visibility.Visible;

                if( !this.LastSelectedDate.HasValue || this.Info.GetMonthDifference(this.LastSelectedDate.Value, this.DisplayDate) != 0 )
                    this.LastSelectedDate = this.DisplayDate;

                this.UpdateMonths();
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="selectedMonth">
        /// Inherited code: Requires comment 1.
        /// </param>
        private void OnSelectedMonthChanged(DateTime? selectedMonth)
        {
            if( selectedMonth.HasValue )
            {
                Debug.Assert(this.DisplayMode == CalendarMode.Year, "DisplayMode should be Year!");
                this.SelectedMonth = selectedMonth.Value;
                this.UpdateMonths();
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="selectedYear">
        /// Inherited code: Requires comment 1.
        /// </param>
        private void OnSelectedYearChanged(DateTime? selectedYear)
        {
            if( selectedYear.HasValue )
            {
                Debug.Assert(this.DisplayMode == CalendarMode.Decade, "DisplayMode should be Decade!");
                this.SelectedYear = selectedYear.Value;
                this.UpdateMonths();
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <returns>
        /// Inherited code: Requires comment 1.
        /// </returns>
        private bool ProcessEnterKey()
        {
            switch( this.DisplayMode )
            {
                case CalendarMode.Year:
                {
                    this.DisplayDate = this.SelectedMonth;
                    this.DisplayMode = CalendarMode.Month;
                    return true;
                }

                case CalendarMode.Decade:
                {
                    this.SelectedMonth = this.SelectedYear;
                    this.DisplayMode = CalendarMode.Year;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <param name="shift">
        /// Inherited code: Requires comment 1.
        /// </param>
        /// <param name="lastSelectedDate">
        /// Inherited code: Requires comment 2.
        /// </param>
        /// <param name="index">
        /// Inherited code: Requires comment 3.
        /// </param>
        private void ProcessSelection(bool shift, DateTime? lastSelectedDate, int? index)
        {
            if( this.SelectionMode == CalendarSelectionMode.None && lastSelectedDate != null )
            {
                this.OnDayClick(lastSelectedDate.Value);
                return;
            }

            if( lastSelectedDate != null && IsValidKeyboardSelection(this, lastSelectedDate.Value) )
            {
                if( this.SelectionMode == CalendarSelectionMode.SingleRange ||
                    this.SelectionMode == CalendarSelectionMode.MultipleRange )
                {
                    foreach( var item in this.SelectedDates )
                    {
                        this.RemovedItems.Add(item);
                    }

                    this.SelectedDates.ClearInternal();
                    if( shift )
                    {
                        GlobalCalendarDayButton b;
                        this._isShiftPressed = true;
                        if( this.HoverStart == null )
                        {
                            if( this.LastSelectedDate != null )
                                this.HoverStart = this.LastSelectedDate;
                            else
                            {
                                if( this.Info.GetMonthDifference(this.DisplayDateInternal, DateTime.Today) == 0 )
                                    this.HoverStart = DateTime.Today;
                                else
                                    this.HoverStart = this.DisplayDateInternal;
                            }

                            b = this.FindDayButtonFromDay(this.HoverStart.Value);
                            if( b != null )
                                this.HoverStartIndex = b.Index;
                        }

                        // the index of the SelectedDate is always the last
                        // selectedDate's index
                        this.UnHighlightDays();

                        // If we hit a BlackOutDay with keyboard we do not
                        // update the HoverEnd
                        CalendarDateRange range;

                        if( this.Info.Compare(this.HoverStart.Value, lastSelectedDate.Value) < 0 )
                            range = new CalendarDateRange(this.HoverStart.Value, lastSelectedDate.Value);
                        else
                            range = new CalendarDateRange(lastSelectedDate.Value, this.HoverStart.Value);

                        if( !this.BlackoutDates.ContainsAny(range) )
                        {
                            this.HoverEnd = lastSelectedDate;

                            if( index.HasValue )
                                this.HoverEndIndex += index;
                            else
                            {
                                // For Home, End, PageUp and PageDown Keys there
                                // is no easy way to predict the index value
                                b = this.FindDayButtonFromDay(this.HoverEndInternal.Value);

                                if( b != null )
                                    this.HoverEndIndex = b.Index;
                            }
                        }

                        this.OnDayClick(this.HoverEnd.Value);
                        this.HighlightDays();
                    }
                    else
                    {
                        this.HoverStart = lastSelectedDate;
                        this.HoverEnd = lastSelectedDate;
                        this.AddSelection();
                        this.OnDayClick(lastSelectedDate.Value);
                    }
                }
                else
                {
                    // ON CLEAR 
                    this.LastSelectedDate = lastSelectedDate.Value;
                    if( this.SelectedDates.Count > 0 )
                        this.SelectedDates[0] = lastSelectedDate.Value;
                    else
                        this.SelectedDates.Add(lastSelectedDate.Value);
                    this.OnDayClick(lastSelectedDate.Value);
                }
            }
        }

        #endregion
    }
}