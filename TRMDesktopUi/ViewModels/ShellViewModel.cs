using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using SWAWPFDesktopUI.EventModels;
using SWAWPFDesktopUI.ViewModels;

namespace SWADesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        
        public ShellViewModel( IEventAggregator events, SalesViewModel salesVM)
        {
            _events = events;
            _salesVM = salesVM;

            _events.SubscribeOnPublishedThread(this);

            ActivateItemAsync(IoC.Get<LoginViewModel>(), new CancellationToken());
        }

        public bool IsLoggedIn { get; set; }

        public void ExitApplication()
        {
            TryCloseAsync();
        }

        //public async Task UserManagement()
        //{
        //    await ActivateItemAsync(IoC.Get<UserDisplayViewModel>(), new CancellationToken()); 
        //}

        //public async Task LogOut()
        //{
        //    _user.ResetUserModel();
        //    _apiHelper.LogOffUser();
        //    await ActivateItemAsync(IoC.Get<LoginViewModel>(), new CancellationToken());
        //    NotifyOfPropertyChange(() => IsLoggedIn);
        //}

        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_salesVM, cancellationToken);
            NotifyOfPropertyChange(() => IsLoggedIn);
        }
    }
}
