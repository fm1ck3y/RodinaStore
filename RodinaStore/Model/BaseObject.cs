using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace RodinaStore.Model
{
    public abstract class BaseObject
    {
        public delegate void ChangedHandler(object OldValue, object NewValue, string propertyName, string User);
        public event ChangedHandler Changed;
        public virtual List<AuditItem> Audit { get { return audit; } }

        public static bool IsLoading = false;

        [Key]
        public int Id { get; set; }

        public void OnChanged(object oldValue, object newValue, string propertyName, string User)
        {
            AuditItem aud = new AuditItem();
            aud.PropertyName = propertyName;
            aud.Date = DateTime.Now;
            aud.NewValue = newValue.ToString();
            aud.OldValue = oldValue.ToString();
            aud.User = User;
            audit.Add(aud);
        }

        public void SetPropertyValue<T>(T oldValue, T newValue, string propertyName, string User) where T : IComparable<T>
        {
            Type type = this.GetType();
            type = type.BaseType;
            FieldInfo fi = type.GetField(propertyName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (fi == null)
            {
                type = IsLoading ? type.BaseType : this.GetType();
                fi = type.GetField(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField);
            }
            fi.SetValue(this, newValue);

            if (oldValue.CompareTo(newValue) != 0 && !IsLoading)
                Changed?.Invoke(oldValue, newValue, propertyName, User);
        }

        private List<AuditItem> audit = new List<AuditItem>();
    }
}
