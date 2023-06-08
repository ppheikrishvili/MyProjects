
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace OutlookReplayBySender.Model
{
    public class eMailRecipient
    {
        public string RowName { get; set; }
        string _emailName;
        public string EmailName
        {
            get => $"{_emailName}  {(eMailRecipientChildren.Count > 0 ? $"({eMailRecipientChildren.Count} recipients)" : "")}";
            set
            {
                if (_emailName != null && value == _emailName) return;
                _emailName = value;
            }
        }
        public ExitEventHandler TypeChanged;
        public ExitEventHandler SelectionChanged;
        public string Domain { get; set; }
        bool _autoCheckUpdated;
        [OnChangedMethod(nameof(OnTypeChanged))] public string Type { get; set; }
        public eMailRecipient Parent { get; set; }
        public ObservableCollection<eMailRecipient> eMailRecipientChildren { get; set; } = new();
        [OnChangedMethod(nameof(OnIsCheckedChanged))] public bool? IsChecked { get; set; } = false;
        void OnTypeChanged() => TypeChanged?.Invoke(null, null);
        void OnIsCheckedChanged()
        {
            if (_autoCheckUpdated) return;
            foreach (eMailRecipient recipient in eMailRecipientChildren)
            {
                recipient.CascadeChangeCheckBox(IsChecked);
            }
            Parent?.CascadeChangeCheckBox(Parent.GetDomainCheckState());
            SelectionChanged?.Invoke(this, null);
        }

        void CascadeChangeCheckBox(bool? isChecked)
        {
            if (IsChecked == isChecked) return;
            _autoCheckUpdated = true;
            IsChecked = isChecked;
            _autoCheckUpdated = false;
        }

        bool? GetDomainCheckState()
        {
            if (eMailRecipientChildren.All(a => a.IsChecked == true)) return true;
            return eMailRecipientChildren.Any(a => a.IsChecked == true) ? null : false;
        }
    }
}
