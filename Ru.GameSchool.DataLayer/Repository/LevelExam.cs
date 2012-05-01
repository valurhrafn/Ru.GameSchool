//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Ru.GameSchool.DataLayer.Repository
{
    public partial class LevelExam
    {
        #region Primitive Properties
    
        public virtual int LevelExamId
        {
            get;
            set;
        }
    
        public virtual int LevelId
        {
            get { return _levelId; }
            set
            {
                if (_levelId != value)
                {
                    if (Level != null && Level.LevelId != value)
                    {
                        Level = null;
                    }
                    _levelId = value;
                }
            }
        }
        private int _levelId;
    
        public virtual string Description
        {
            get;
            set;
        }
    
        public virtual double GradePercentageValue
        {
            get;
            set;
        }
    
        public virtual string Name
        {
            get;
            set;
        }
    
        public virtual System.DateTime CreateDateTime
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual Level Level
        {
            get { return _level; }
            set
            {
                if (!ReferenceEquals(_level, value))
                {
                    var previousValue = _level;
                    _level = value;
                    FixupLevel(previousValue);
                }
            }
        }
        private Level _level;
    
        public virtual ICollection<LevelExamQuestion> LevelExamQuestions
        {
            get
            {
                if (_levelExamQuestions == null)
                {
                    var newCollection = new FixupCollection<LevelExamQuestion>();
                    newCollection.CollectionChanged += FixupLevelExamQuestions;
                    _levelExamQuestions = newCollection;
                }
                return _levelExamQuestions;
            }
            set
            {
                if (!ReferenceEquals(_levelExamQuestions, value))
                {
                    var previousValue = _levelExamQuestions as FixupCollection<LevelExamQuestion>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupLevelExamQuestions;
                    }
                    _levelExamQuestions = value;
                    var newValue = value as FixupCollection<LevelExamQuestion>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupLevelExamQuestions;
                    }
                }
            }
        }
        private ICollection<LevelExamQuestion> _levelExamQuestions;
    
        public virtual ICollection<LevelExamResult> LevelExamResults
        {
            get
            {
                if (_levelExamResults == null)
                {
                    var newCollection = new FixupCollection<LevelExamResult>();
                    newCollection.CollectionChanged += FixupLevelExamResults;
                    _levelExamResults = newCollection;
                }
                return _levelExamResults;
            }
            set
            {
                if (!ReferenceEquals(_levelExamResults, value))
                {
                    var previousValue = _levelExamResults as FixupCollection<LevelExamResult>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupLevelExamResults;
                    }
                    _levelExamResults = value;
                    var newValue = value as FixupCollection<LevelExamResult>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupLevelExamResults;
                    }
                }
            }
        }
        private ICollection<LevelExamResult> _levelExamResults;

        #endregion
        #region Association Fixup
    
        private void FixupLevel(Level previousValue)
        {
            if (previousValue != null && previousValue.LevelExams.Contains(this))
            {
                previousValue.LevelExams.Remove(this);
            }
    
            if (Level != null)
            {
                if (!Level.LevelExams.Contains(this))
                {
                    Level.LevelExams.Add(this);
                }
                if (LevelId != Level.LevelId)
                {
                    LevelId = Level.LevelId;
                }
            }
        }
    
        private void FixupLevelExamQuestions(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (LevelExamQuestion item in e.NewItems)
                {
                    item.LevelExam = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (LevelExamQuestion item in e.OldItems)
                {
                    if (ReferenceEquals(item.LevelExam, this))
                    {
                        item.LevelExam = null;
                    }
                }
            }
        }
    
        private void FixupLevelExamResults(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (LevelExamResult item in e.NewItems)
                {
                    item.LevelExam = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (LevelExamResult item in e.OldItems)
                {
                    if (ReferenceEquals(item.LevelExam, this))
                    {
                        item.LevelExam = null;
                    }
                }
            }
        }

        #endregion
    }
}