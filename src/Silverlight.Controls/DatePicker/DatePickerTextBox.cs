// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

namespace Silverlight.Controls.Primitives
{
    using System.Diagnostics;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Represents the text input of a
    /// <see cref="T:System.Windows.Controls.DatePicker"/>.
    /// </summary>
    /// <QualityBand>Mature</QualityBand>
    [TemplateVisualState(Name = VisualStates.StateNormal, GroupName = VisualStates.GroupCommon)]
    [TemplateVisualState(Name = VisualStates.StateMouseOver, GroupName = VisualStates.GroupCommon)]
    [TemplateVisualState(Name = VisualStates.StateDisabled, GroupName = VisualStates.GroupCommon)]
    [TemplateVisualState(Name = VisualStates.StateUnfocused, GroupName = VisualStates.GroupFocus)]
    [TemplateVisualState(Name = VisualStates.StateFocused, GroupName = VisualStates.GroupFocus)]
    [TemplateVisualState(Name = VisualStates.StateUnwatermarked, GroupName = VisualStates.GroupWatermark)]
    [TemplateVisualState(Name = VisualStates.StateWatermarked, GroupName = VisualStates.GroupWatermark)]
    [TemplatePart(Name = ElementContentName, Type = typeof(ContentControl))]
    public sealed class DatePickerTextBox : TextBox
    {
        #region Constants and Fields

        /// <summary>
        /// Watermark dependency property.
        /// </summary>
        public new static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.Register(
                                        "Watermark", 
                typeof(object), 
                typeof(DatePickerTextBox), 
                new PropertyMetadata(OnWatermarkPropertyChanged));

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private const string ElementContentName = "Watermark";

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:System.Windows.Controls.Primitives.DatePickerTextBox" />
        /// class.
        /// </summary>
        public DatePickerTextBox()
        {
            this.DefaultStyleKey = typeof(DatePickerTextBox);
            this.SetDefaults();

            this.MouseEnter += this.OnMouseEnter;
            this.MouseLeave += this.OnMouseLeave;
            this.Loaded += this.OnLoaded;
            this.LostFocus += this.OnLostFocus;
            this.GotFocus += this.OnGotFocus;
            this.TextChanged += this.OnTextChanged;
            this.IsEnabledChanged += this.OnIsEnabledChanged;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the Watermark content.
        /// </summary>
        /// <value>The watermark.</value>
        public new object Watermark
        {
            get { return this.GetValue(WatermarkProperty); }
            set { this.SetValue(WatermarkProperty, value); }
        }

        /// <summary>
        /// Gets or sets Inherited code: Requires comment.
        /// </summary>
        internal ContentControl ElementContent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Inherited code: Requires comment.
        /// </summary>
        internal bool HasFocusInternal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Inherited code: Requires comment.
        /// </summary>
        internal bool IsHovered { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Builds the visual tree for the
        /// <see cref="T:System.Windows.Controls.Primitives.DatePickerTextBox"/>
        /// when a new template is applied.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.ElementContent = this.ExtractTemplatePart<ContentControl>(ElementContentName);

            this.OnWatermarkChanged();

            this.ChangeVisualState(false);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Change to the correct visual state for the textbox.
        /// </summary>
        internal void ChangeVisualState()
        {
            this.ChangeVisualState(true);
        }

        /// <summary>
        /// Change to the correct visual state for the textbox.
        /// </summary>
        /// <param name="useTransitions">
        /// True to use transitions when updating the visual state, false to
        /// snap directly to the new visual state.
        /// </param>
        internal void ChangeVisualState(bool useTransitions)
        {
            // Update the CommonStates group
            if( !this.IsEnabled )
                VisualStates.GoToState(this, useTransitions, VisualStates.StateDisabled, VisualStates.StateNormal);
            else if( this.IsHovered )
                VisualStates.GoToState(this, useTransitions, VisualStates.StateMouseOver, VisualStates.StateNormal);
            else
                VisualStates.GoToState(this, useTransitions, VisualStates.StateNormal);

            // Update the FocusStates group
            if( this.HasFocusInternal && this.IsEnabled )
                VisualStates.GoToState(this, useTransitions, VisualStates.StateFocused, VisualStates.StateUnfocused);
            else
                VisualStates.GoToState(this, useTransitions, VisualStates.StateUnfocused);

            // Update the WatermarkStates group
            if( this.Watermark != null && string.IsNullOrEmpty(this.Text) )
                VisualStates.GoToState(this, useTransitions, VisualStates.StateWatermarked, VisualStates.StateUnwatermarked);
            else
                VisualStates.GoToState(this, useTransitions, VisualStates.StateUnwatermarked);
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
        internal void OnLoaded(object sender, RoutedEventArgs e)
        {
            this.ApplyTemplate();
            this.ChangeVisualState(false);
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <typeparam name="T">
        /// Inherited code: Requires comment 1.
        /// </typeparam>
        /// <param name="partName">
        /// Inherited code: Requires comment 2.
        /// </param>
        /// <param name="obj">
        /// Inherited code: Requires comment 3.
        /// </param>
        /// <returns>
        /// Inherited code: Requires comment 4.
        /// </returns>
        private static T ExtractTemplatePart<T>(string partName, DependencyObject obj)
            where T : DependencyObject
        {
            Debug.Assert(
                         obj == null || typeof(T).IsInstanceOfType(obj), 
                string.Format(CultureInfo.InvariantCulture, Assets.Resources.ControlsStrings.DatePickerTextBox_TemplatePartIsOfIncorrectType, partName, typeof(T).Name));
            return obj as T;
        }

        /// <summary>
        /// Called when watermark property is changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="args">
        /// The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/>
        /// instance containing the event data.
        /// </param>
        private static void OnWatermarkPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var datePickerTextBox = sender as DatePickerTextBox;
            Debug.Assert(datePickerTextBox != null, "The source is not an instance of a DatePickerTextBox!");
            datePickerTextBox.OnWatermarkChanged();
            datePickerTextBox.ChangeVisualState();
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <typeparam name="T">
        /// Inherited code: Requires comment 1.
        /// </typeparam>
        /// <param name="partName">
        /// Inherited code: Requires comment 2.
        /// </param>
        /// <returns>
        /// Inherited code: Requires comment 3.
        /// </returns>
        private T ExtractTemplatePart<T>(string partName)
            where T : DependencyObject
        {
            DependencyObject obj = this.GetTemplateChild(partName);
            return ExtractTemplatePart<T>(partName, obj);
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
        private void OnGotFocus(object sender, RoutedEventArgs e)
        {
            if( this.IsEnabled )
            {
                this.HasFocusInternal = true;

                if( !string.IsNullOrEmpty(this.Text) )
                    this.Select(0, this.Text.Length);

                this.ChangeVisualState();
            }
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
            Debug.Assert(e.NewValue is bool, "The new value should be a boolean!");
            var isEnabled = (bool)e.NewValue;

            this.IsReadOnly = !isEnabled;
            if( !isEnabled )
                this.IsHovered = false;

            this.ChangeVisualState();
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
        private void OnLostFocus(object sender, RoutedEventArgs e)
        {
            this.HasFocusInternal = false;
            this.ChangeVisualState();
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
        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            this.IsHovered = true;

            if( !this.HasFocusInternal )
                this.ChangeVisualState();
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
        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            this.IsHovered = false;

            if( !this.HasFocusInternal )
                this.ChangeVisualState();
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
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            this.ChangeVisualState();
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private void OnWatermarkChanged()
        {
            if( this.ElementContent != null )
            {
                var watermarkControl = this.Watermark as Control;
                if( watermarkControl != null )
                {
                    watermarkControl.IsTabStop = false;
                    watermarkControl.IsHitTestVisible = false;
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private void SetDefaults()
        {
            this.IsEnabled = true;
            this.Watermark = Assets.Resources.ControlsStrings.DatePickerTextBox_DefaultWatermarkText;
        }

        #endregion
    }
}