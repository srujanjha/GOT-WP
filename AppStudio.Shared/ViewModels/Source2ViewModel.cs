using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class Source2ViewModel : ViewModelBase<YouTubeSchema>
    {
        override protected string CacheKey
        {
            get { return "Source2DataSource"; }
        }

        private RelayCommandEx<YouTubeSchema> itemClickCommand;
        public RelayCommandEx<YouTubeSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<YouTubeSchema>(
                        (item) =>
                        {
                            NavigationServices.CurrentViewModel = this;
                            this.SelectedItem = item;

                            NavigationServices.NavigateToPage("Source2Detail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected IDataSource<YouTubeSchema> CreateDataSource()
        {
            return new Source2DataSource(); // YouTubeDataSource
        }

        override public Visibility PinToStartVisibility
        {
            get { return ViewType == ViewTypes.Detail ? Visibility.Visible : Visibility.Collapsed; }
        }

        override protected void PinToStart()
        {
            base.PinToStart("Source2Detail", "{Title}", "{Summary}", "{ImageUrl}");
        }

        override public Visibility ShareItemVisibility
        {
            get { return ViewType == ViewTypes.Detail ? Visibility.Visible : Visibility.Collapsed; }
        }

        override public Visibility TextToSpeechVisibility
        {
            get { return ViewType == ViewTypes.Detail ? Visibility.Visible : Visibility.Collapsed; }
        }

        override protected async void TextToSpeech()
        {
            await base.SpeakText("Summary");
        }

        override public Visibility GoToSourceVisibility
        {
            get { return ViewType == ViewTypes.Detail ? Visibility.Visible : Visibility.Collapsed; }
        }

        override protected void GoToSource()
        {
            base.GoToSource("{ExternalUrl}");
        }

        override public Visibility RefreshVisibility
        {
            get { return ViewType == ViewTypes.List ? Visibility.Visible : Visibility.Collapsed; }
        }

        override public void NavigateToSectionList()
        {
            NavigationServices.NavigateToPage("Source2List");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("Source2Detail");
        }
    }
}
