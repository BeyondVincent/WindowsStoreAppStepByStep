using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DevDiv_DataBinding.Data
{
    class ForumItem : INotifyPropertyChanged
    {
        private string name, link, info;// 论坛板块的名称,链接和描述信息
        private int topicCount; // 主题数
        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged("Name"); }
        }
        public string Link
        {
            get { return link; }
            set { link = value; NotifyPropertyChanged("Link"); }
        }
        public string Info
        {
            get { return info; }
            set { info = value; NotifyPropertyChanged("info"); }
        }
        public int TopicCount
        {
            get { return topicCount; }
            set { topicCount = value; NotifyPropertyChanged("TopicCount"); }
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
