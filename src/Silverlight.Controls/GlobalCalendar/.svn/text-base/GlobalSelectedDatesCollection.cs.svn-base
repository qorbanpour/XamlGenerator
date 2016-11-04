// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

namespace Silverlight.Controls
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading;
    using System.Windows.Controls;

    /// <summary>
    /// Represents a set of selected dates in a
    /// <see cref="T:System.Windows.Controls.GlobalCalendar"/>.
    /// </summary>
    /// <QualityBand>Experimental</QualityBand>
    public sealed class GlobalSelectedDatesCollection : ObservableCollection<DateTime>
    {
        #region Constants and Fields

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private readonly Collection<DateTime> _addedItems;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private readonly Thread _dispatcherThread;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private readonly GlobalCalendar _owner;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private bool _isCleared;

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        private bool _isRangeAdded;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:System.Windows.Controls.GlobalSelectedDatesCollection"/>
        /// class.
        /// </summary>
        /// <param name="owner">
        /// The <see cref="T:System.Windows.Controls.GlobalCalendar"/>
        /// associated with this object.
        /// </param>
        public GlobalSelectedDatesCollection(GlobalCalendar owner)
        {
            Debug.Assert(owner != null, "owner should not be null!");
            this._owner = owner;
            this._addedItems = new Collection<DateTime>();
            this._dispatcherThread = Thread.CurrentThread;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds all the dates in the specified range, which includes the first
        /// and last dates, to the collection.
        /// </summary>
        /// <param name="start">
        /// The first date to add to the collection.
        /// </param>
        /// <param name="end">
        /// The last date to add to the collection.
        /// </param>
        public void AddRange(DateTime start, DateTime end)
        {
            // increment parameter specifies if the Days were selected in
            // Descending order or Ascending order based on this value, we add 
            // the days in the range either in Ascending order or in Descending
            // order
            int increment = (this._owner.Info.Compare(end, start) >= 0) ? 1 : -1;

            this._addedItems.Clear();

            DateTime? rangeStart = start;
            this._isRangeAdded = true;

            if( this._owner.IsMouseSelection )
            {
                // In Mouse Selection we allow the user to be able to add
                // multiple ranges in one action in MultipleRange Mode.  In
                // SingleRange Mode, we only add the first selected range.
                while( rangeStart != null && this._owner.Info.Compare(end, rangeStart.Value) != -increment )
                {
                    if( GlobalCalendar.IsValidDateSelection(this._owner, rangeStart) )
                        this.Add(rangeStart.Value);
                    else if( this._owner.SelectionMode == CalendarSelectionMode.SingleRange )
                    {
                        this._owner.HoverEnd = this._owner.Info.AddDays(rangeStart.Value, -increment);
                        break;
                    }

                    rangeStart = this._owner.Info.AddDays(rangeStart.Value, increment);
                }
            }
            else
            {
                // If CalendarSelectionMode.SingleRange and a user
                // programmatically tries to add multiple ranges, we will throw
                // away the old range and replace it with the new one.  In order
                // to provide the removed items without an additional event, we
                // are calling ClearInternal
                if( this._owner.SelectionMode == CalendarSelectionMode.SingleRange && this.Count > 0 )
                {
                    foreach( var item in this )
                    {
                        this._owner.RemovedItems.Add(item);
                    }

                    this.ClearInternal();
                }

                while( rangeStart != null && this._owner.Info.Compare(end, rangeStart.Value) != -increment )
                {
                    this.Add(rangeStart.Value);
                    rangeStart = this._owner.Info.AddDays(rangeStart.Value, increment);
                }
            }

            this._owner.OnSelectedDatesCollectionChanged(new SelectionChangedEventArgs(this._owner.RemovedItems, this._addedItems));
            this._owner.RemovedItems.Clear();
            this._owner.UpdateMonths();
            this._isRangeAdded = false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        internal void ClearInternal()
        {
            base.ClearItems();
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        /// <remarks>
        /// This implementation raises the CollectionChanged event.
        /// </remarks>
        protected override void ClearItems()
        {
            if( !this.IsValidThread() )
                throw new NotSupportedException(Assets.Resources.ControlsStrings.CalendarCollection_MultiThreadedCollectionChangeNotSupported);
            var addedItems = new Collection<DateTime>();
            var removedItems = new Collection<DateTime>();

            foreach( var item in this )
            {
                removedItems.Add(item);
            }

            base.ClearItems();

            // The event fires after SelectedDate changes
            if( this._owner.SelectionMode != CalendarSelectionMode.None && this._owner.SelectedDate != null )
                this._owner.SelectedDate = null;

            if( removedItems.Count != 0 )
                this._owner.OnSelectedDatesCollectionChanged(new SelectionChangedEventArgs(removedItems, addedItems));
            this._owner.UpdateMonths();
        }

        /// <summary>
        /// Inserts an item into the collection at the specified index.
        /// </summary>
        /// <param name="index">
        /// The zero-based index at which item should be inserted.
        /// </param>
        /// <param name="item">
        /// The object to insert.
        /// </param>
        /// <remarks>
        /// This implementation raises the CollectionChanged event.
        /// </remarks>
        protected override void InsertItem(int index, DateTime item)
        {
            if( !this.IsValidThread() )
                throw new NotSupportedException(Assets.Resources.ControlsStrings.CalendarCollection_MultiThreadedCollectionChangeNotSupported);

            if( !this.Contains(item) )
            {
                var addedItems = new Collection<DateTime>();

                if( this.CheckSelectionMode() )
                {
                    if( GlobalCalendar.IsValidDateSelection(this._owner, item) )
                    {
                        // If the Collection is cleared since it is SingleRange
                        // and it had another range set the index to 0
                        if( this._isCleared )
                        {
                            index = 0;
                            this._isCleared = false;
                        }

                        base.InsertItem(index, item);

                        // The event fires after SelectedDate changes
                        if( index == 0 && !(this._owner.SelectedDate != null && this._owner.Info.Compare(this._owner.SelectedDate.Value, item) == 0) )
                            this._owner.SelectedDate = item;

                        if( !this._isRangeAdded )
                        {
                            addedItems.Add(item);

                            this._owner.OnSelectedDatesCollectionChanged(new SelectionChangedEventArgs(this._owner.RemovedItems, addedItems));
                            this._owner.RemovedItems.Clear();

                            int monthDifference = this._owner.Info.GetMonthDifference(item, this._owner.DisplayDateInternal);
                            if( monthDifference < 2 && monthDifference > -2 )
                                this._owner.UpdateMonths();
                        }
                        else
                            this._addedItems.Add(item);
                    }
                    else
                        throw new ArgumentOutOfRangeException(Assets.Resources.ControlsStrings.Calendar_OnSelectedDateChanged_InvalidValue);
                }
            }
        }

        /// <summary>
        /// Removes the item at the specified index of the collection.
        /// </summary>
        /// <param name="index">
        /// The zero-based index of the element to remove.
        /// </param>
        /// <remarks>
        /// This implementation raises the CollectionChanged event.
        /// </remarks>
        protected override void RemoveItem(int index)
        {
            if( !this.IsValidThread() )
                throw new NotSupportedException(Assets.Resources.ControlsStrings.CalendarCollection_MultiThreadedCollectionChangeNotSupported);

            if( index >= this.Count )
                base.RemoveItem(index);
            else
            {
                var addedItems = new Collection<DateTime>();
                var removedItems = new Collection<DateTime>();
                int monthDifference = this._owner.Info.GetMonthDifference(this[index], this._owner.DisplayDateInternal);

                removedItems.Add(this[index]);
                base.RemoveItem(index);

                // The event fires after SelectedDate changes
                if( index == 0 )
                {
                    if( this.Count > 0 )
                        this._owner.SelectedDate = this[0];
                    else
                        this._owner.SelectedDate = null;
                }

                this._owner.OnSelectedDatesCollectionChanged(new SelectionChangedEventArgs(removedItems, addedItems));

                if( monthDifference < 2 && monthDifference > -2 )
                    this._owner.UpdateMonths();
            }
        }

        /// <summary>
        /// Replaces the element at the specified index.
        /// </summary>
        /// <param name="index">
        /// The zero-based index of the element to replace.
        /// </param>
        /// <param name="item">
        /// The new value for the element at the specified index.
        /// </param>
        /// <remarks>
        /// This implementation raises the CollectionChanged event.
        /// </remarks>
        protected override void SetItem(int index, DateTime item)
        {
            if( !this.IsValidThread() )
                throw new NotSupportedException(Assets.Resources.ControlsStrings.CalendarCollection_MultiThreadedCollectionChangeNotSupported);

            if( !this.Contains(item) )
            {
                var addedItems = new Collection<DateTime>();
                var removedItems = new Collection<DateTime>();

                if( index >= this.Count )
                    base.SetItem(index, item);
                else
                {
                    if( item != null && this._owner.Info.Compare(this[index], item) != 0 && GlobalCalendar.IsValidDateSelection(this._owner, item) )
                    {
                        removedItems.Add(this[index]);
                        base.SetItem(index, item);
                        addedItems.Add(item);

                        // The event fires after SelectedDate changes
                        if( index == 0 && !(this._owner.SelectedDate != null && this._owner.Info.Compare(this._owner.SelectedDate.Value, item) == 0) )
                            this._owner.SelectedDate = item;
                        this._owner.OnSelectedDatesCollectionChanged(new SelectionChangedEventArgs(removedItems, addedItems));

                        int monthDifference = this._owner.Info.GetMonthDifference(item, this._owner.DisplayDateInternal);
                        if( monthDifference < 2 && monthDifference > -2 )
                            this._owner.UpdateMonths();
                    }
                }
            }
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <returns>
        /// Inherited code: Requires comment 1.
        /// </returns>
        private bool CheckSelectionMode()
        {
            if( this._owner.SelectionMode == CalendarSelectionMode.None )
                throw new InvalidOperationException(Assets.Resources.ControlsStrings.Calendar_OnSelectedDateChanged_InvalidOperation);
            if( this._owner.SelectionMode == CalendarSelectionMode.SingleDate && this.Count > 0 )
                throw new InvalidOperationException(Assets.Resources.ControlsStrings.Calendar_CheckSelectionMode_InvalidOperation);

            // if user tries to add an item into the SelectedDates in
            // SingleRange mode, we throw away the old range and replace it with
            // the new one in order to provide the removed items without an
            // additional event, we are calling ClearInternal
            if( this._owner.SelectionMode == CalendarSelectionMode.SingleRange && !this._isRangeAdded && this.Count > 0 )
            {
                foreach( var item in this )
                {
                    this._owner.RemovedItems.Add(item);
                }

                this.ClearInternal();
                this._isCleared = true;
            }

            return true;
        }

        /// <summary>
        /// Inherited code: Requires comment.
        /// </summary>
        /// <returns>
        /// Inherited code: Requires comment 1.
        /// </returns>
        private bool IsValidThread()
        {
            return Thread.CurrentThread == this._dispatcherThread;
        }

        #endregion
    }
}