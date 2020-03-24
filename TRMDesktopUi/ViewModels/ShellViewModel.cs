using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using SWADesktopUI.Library.Models;
using SWAWPFDesktopUI.EventModels;
using SWAWPFDesktopUI.ViewModels;

namespace SWADesktopUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        private readonly ILoggedInUserModel user;

        public ShellViewModel( IEventAggregator events, SalesViewModel salesVM, ILoggedInUserModel user)
        {
            _events = events;
            _salesVM = salesVM;
            this.user = user;
            _events.SubscribeOnPublishedThread(this);

            ActivateItemAsync(IoC.Get<LoginViewModel>(), new CancellationToken());
        }

        public bool IsLoggedIn 
        {
            get
            {
                bool output = false;

                if (string.IsNullOrEmpty(user.Token) == false)
                {
                    output = true;
                }

                return output;
            }
        }

        public void ExitApplication()
        {
            TryCloseAsync();
        }

        //public async Task UserManagement()
        //{
        //    await ActivateItemAsync(IoC.Get<UserDisplayViewModel>(), new CancellationToken()); 
        //}

        public async Task LogOut()
        {
            _user.ResetUserModel();
            user.LogOffUser();
            await ActivateItemAsync(IoC.Get<LoginViewModel>(), new CancellationToken());
            NotifyOfPropertyChange(() => IsLoggedIn);
        }

        public async Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            await ActivateItemAsync(_salesVM, cancellationToken);
            NotifyOfPropertyChange(() => IsLoggedIn);
        }
    }
}
