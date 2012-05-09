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
    public partial class LevelMaterial
    {
        #region Primitive Properties
    
        public virtual int LevelMaterialId
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
    
        public virtual System.Guid ContentId
        {
            get;
            set;
        }
    
        public virtual int ContentTypeId
        {
            get { return _contentTypeId; }
            set
            {
                if (_contentTypeId != value)
                {
                    if (ContentType != null && ContentType.ContentTypeId != value)
                    {
                        ContentType = null;
                    }
                    _contentTypeId = value;
                }
            }
        }
        private int _contentTypeId;
    
        public virtual string Url
        {
            get;
            set;
        }
    
        public virtual string Description
        {
            get;
            set;
        }
    
        public virtual string Title
        {
            get;
            set;
        }
    
        public virtual string Filename
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<Comment> Comments
        {
            get
            {
                if (_comments == null)
                {
                    var newCollection = new FixupCollection<Comment>();
                    newCollection.CollectionChanged += FixupComments;
                    _comments = newCollection;
                }
                return _comments;
            }
            set
            {
                if (!ReferenceEquals(_comments, value))
                {
                    var previousValue = _comments as FixupCollection<Comment>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupComments;
                    }
                    _comments = value;
                    var newValue = value as FixupCollection<Comment>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupComments;
                    }
                }
            }
        }
        private ICollection<Comment> _comments;
    
        public virtual ContentType ContentType
        {
            get { return _contentType; }
            set
            {
                if (!ReferenceEquals(_contentType, value))
                {
                    var previousValue = _contentType;
                    _contentType = value;
                    FixupContentType(previousValue);
                }
            }
        }
        private ContentType _contentType;
    
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

        #endregion
        #region Association Fixup
    
        private void FixupContentType(ContentType previousValue)
        {
            if (previousValue != null && previousValue.LevelMaterials.Contains(this))
            {
                previousValue.LevelMaterials.Remove(this);
            }
    
            if (ContentType != null)
            {
                if (!ContentType.LevelMaterials.Contains(this))
                {
                    ContentType.LevelMaterials.Add(this);
                }
                if (ContentTypeId != ContentType.ContentTypeId)
                {
                    ContentTypeId = ContentType.ContentTypeId;
                }
            }
        }
    
        private void FixupLevel(Level previousValue)
        {
            if (previousValue != null && previousValue.LevelMaterials.Contains(this))
            {
                previousValue.LevelMaterials.Remove(this);
            }
    
            if (Level != null)
            {
                if (!Level.LevelMaterials.Contains(this))
                {
                    Level.LevelMaterials.Add(this);
                }
                if (LevelId != Level.LevelId)
                {
                    LevelId = Level.LevelId;
                }
            }
        }
    
        private void FixupComments(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Comment item in e.NewItems)
                {
                    item.LevelMaterial = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Comment item in e.OldItems)
                {
                    if (ReferenceEquals(item.LevelMaterial, this))
                    {
                        item.LevelMaterial = null;
                    }
                }
            }
        }

        #endregion
    }
}
