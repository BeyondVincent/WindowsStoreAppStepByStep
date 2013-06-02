using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace DevDiv_DataBinding.Data
{
    class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ForumItem> forumItemList;
        private int selectedItemIndex;
        private string itemDetail;
        public ViewModel()
        {
            forumItemList = new ObservableCollection<ForumItem>();
            selectedItemIndex = -1;
        }

        public int SelectedItemIndex
        {
            get { return selectedItemIndex; }
            set
            {
                selectedItemIndex = value; NotifyPropertyChanged("SelectedItemIndex");
            }
        }

        public string ItemDetail
        {
            get { return itemDetail; }
            set
            {
                itemDetail = value; NotifyPropertyChanged("ItemDetail");
            }
        }

        public ObservableCollection<ForumItem> ForumItemList
        {
            get
            {
                return forumItemList;
            }
        }

        public void SearchAndSelect(string searchTerm)
        {
            int selIndex = -1;
            for (int i = 0; i < ForumItemList.Count; i++)
            {
                if (ForumItemList[i].Name.ToLower().Contains(searchTerm.ToLower()))
                {
                    selIndex = i;
                    System.Diagnostics.Debug.WriteLine(ForumItemList[i].Name);
                    break;
                }
            }
            SelectedItemIndex = selIndex;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }

}
