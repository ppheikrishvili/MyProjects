
using PropertyChanged;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using OutlookReplayBySender.Common.Enum;

namespace OutlookReplayBySender.Model.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public abstract class BaseViewModel
    {
        public ViewActionEnum ActiveView { get; set; }
        public bool FromInspector { get; set; }
        public ObservableCollection<eMailRecipient> Recipients { get; set; }
        public ListCollectionView RecipientsCollectionView { get; set; }
        public abstract List<eMailRecipient> GetSelectedRecipients();
        public abstract List<eMailRecipient> GetAllRecipients();
        public virtual void Populate(List<eMailRecipient> addresses, bool fromInspector) { }
        public List<string> Types { get; } = new List<string>() { "TO", "CC", "BCC" };
    }
}

