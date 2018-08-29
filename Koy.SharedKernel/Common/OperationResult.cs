using System;
using System.Collections.Generic;
using System.Text;

namespace Koy.SharedKernel.Common
{
    public class OperationResult
    {
        public bool Success { get; private set; } = true;
        public List<Notification> Notes = new List<Notification>();
        public void AddNote(Notification note)
        {
            Notes.Add(note);
            Success = false;
        }
        public void AddNotes(IEnumerable<Notification> notifications)
        {
            foreach (var note in notifications)
            {
                AddNote(note);
            }
        }
        public OperationResult Merge(OperationResult otherResult)
        {
            AddNotes(otherResult.Notes);
            Success &= otherResult.Success;
            return this;
        }
    }

    public class OperationResult<T>
    {
        public bool Success { get; private set; } = true;
        public List<Notification> Notes = new List<Notification>();
        private T _createdEntity;

        public T CreatedEntity {
            get { return _createdEntity;  }
            set
            {
                if (_createdEntity == null)
                    value = _createdEntity;
                else
                    throw new Exception("You cant change the created entity in OperationResult<T> after once assigned.");
            }
        }
        public void AddNote(Notification note)
        {
            Notes.Add(note);
            Success = false;
        }
        public void AddNotes(IEnumerable<Notification> notifications)
        {
            foreach (var note in notifications)
            {
                AddNote(note);
            }
        }
        public OperationResult<T> Merge(OperationResult<T> otherResult)
        {
            AddNotes(otherResult.Notes);
            Success &= otherResult.Success;
            return this;
        }


    }
}
