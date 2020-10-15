using System.ComponentModel;

namespace SimpleMVVM
{
    /// <summary>
    /// 实现INotifyPropertyChanged接口
    /// 如果属性更改，可以使用RaisePropertyChanged方法通知属性更改
    /// </summary>
    public class NotifyPropertyObject: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 属性值更改时引发通知
        /// </summary>
        /// <param name="propertyName">属性名</param>
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 如果属性值更改，则设置属性值并引发通知
        /// </summary>
        /// <typeparam name="T">属性类型</typeparam>
        /// <param name="propertyName">属性名</param>
        /// <param name="oldValue">属性旧值</param>
        /// <param name="newValue">属性新值</param>
        protected virtual void SetAndNotifyIfChanged<T>(string propertyName, ref T oldValue, T newValue)
        {
            if (oldValue == null && newValue == null) return;
            if (oldValue != null && oldValue.Equals(newValue)) return;
            if (oldValue != null && newValue.Equals(oldValue)) return;
            oldValue = newValue;
            RaisePropertyChanged(propertyName);
        }
    }
}
