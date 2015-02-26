using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.NetworkInformation;

using Windows.UI.Xaml;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class MainViewModel : BindableBase
    {
       private Source1ViewModel _source1Model;
       private Source2ViewModel _source2Model;
       private Source3ViewModel _source3Model;
        private PrivacyViewModel _privacyModel;

        private ViewModelBase _selectedItem = null;

        public MainViewModel()
        {
            _selectedItem = Source1Model;
            _privacyModel = new PrivacyViewModel();

        }
 
        public Source1ViewModel Source1Model
        {
            get { return _source1Model ?? (_source1Model = new Source1ViewModel()); }
        }
 
        public Source2ViewModel Source2Model
        {
            get { return _source2Model ?? (_source2Model = new Source2ViewModel()); }
        }
 
        public Source3ViewModel Source3Model
        {
            get { return _source3Model ?? (_source3Model = new Source3ViewModel()); }
        }

        public void SetViewType(ViewTypes viewType)
        {
            Source1Model.ViewType = viewType;
            Source2Model.ViewType = viewType;
            Source3Model.ViewType = viewType;
        }

        public ViewModelBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                UpdateAppBar();
            }
        }

        public Visibility AppBarVisibility
        {
            get
            {
                return SelectedItem == null ? AboutVisibility : SelectedItem.AppBarVisibility;
            }
        }

        public Visibility AboutVisibility
        {

         get { return Visibility.Visible; }
        }

        public void UpdateAppBar()
        {
            OnPropertyChanged("AppBarVisibility");
            OnPropertyChanged("AboutVisibility");
        }

        /// <summary>
        /// Load ViewModel items asynchronous
        /// </summary>
        public async Task LoadData(bool isNetworkAvailable)
        {
            var loadTasks = new Task[]
            { 
                Source1Model.LoadItems(isNetworkAvailable),
                Source2Model.LoadItems(isNetworkAvailable),
                Source3Model.LoadItems(isNetworkAvailable),
            };
            await Task.WhenAll(loadTasks);
        }

        /// <summary>
        /// Refresh ViewModel items asynchronous
        /// </summary>
        public async Task RefreshData(bool isNetworkAvailable)
        {
            var refreshTasks = new Task[]
            { 
                Source1Model.RefreshItems(isNetworkAvailable),
                Source2Model.RefreshItems(isNetworkAvailable),
                Source3Model.RefreshItems(isNetworkAvailable),
            };
            await Task.WhenAll(refreshTasks);
        }

        //
        //  ViewModel command implementation
        //
        public ICommand RefreshCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await RefreshData(NetworkInterface.GetIsNetworkAvailable());
                });
            }
        }

        public ICommand AboutCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateToPage("AboutThisAppPage");
                });
            }
        }

        public ICommand PrivacyCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateTo(_privacyModel.Url);
                });
            }
        }
    }
}
