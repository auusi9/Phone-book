using Code.Data;
using Code.Presentation.Actions;
using Code.Presentation.Controllers;
using Code.Presentation.Models;
using Code.Presentation.Notifications;
using Code.Presentation.Views;
using Code.Presentation.Views.ContactList;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class ContactListInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _contactElementPrefab;
        
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            
            DeclareAndBindActions();
            BindControllers();
            BindModels();
            BindViews();
            BindServices();
            DeclareNotifications();
        }

        private void BindServices()
        {
            Container.BindInterfacesTo<Persistance>().AsTransient();
        }

        private void DeclareAndBindActions()
        {
            Container.DeclareSignal<RefreshContactListAction>();
            Container.BindSignal<RefreshContactListAction>()
            .ToMethod<RefreshContactListController>(x => x.Execute).FromResolve();
            
            Container.DeclareSignal<SortContactsByDateAction>();
            Container.BindSignal<SortContactsByDateAction>()
            .ToMethod<SortContactsByDateController>(x => x.Execute).FromResolve();
            
            Container.DeclareSignal<SortContactsByAlphabetAction>();
            Container.BindSignal<SortContactsByAlphabetAction>()
            .ToMethod<SortContactsByAlphabetController>(x => x.Execute).FromResolve();
            
            Container.DeclareSignal<SearchContactAction>();
            Container.BindSignal<SearchContactAction>()
            .ToMethod<SearchContactController>(x => x.Execute).FromResolve();
            
            Container.DeclareSignal<CancelSearchAction>();
            Container.BindSignal<CancelSearchAction>()
            .ToMethod<CancelSearchController>(x => x.Execute).FromResolve();
        }

        private void BindControllers()
        {
            Container.Bind<RefreshContactListController>().AsTransient();
            Container.Bind<SortContactsByDateController>().AsTransient();
            Container.Bind<SortContactsByAlphabetController>().AsTransient();
            Container.Bind<SearchContactController>().AsTransient();
            Container.Bind<CancelSearchController>().AsTransient();
        }

        private void BindModels()
        {
            Container.BindInterfacesTo<ContactListModel>().AsSingle();
        }

        private void BindViews()
        {
            Container.BindMemoryPool<ContactElementView, ContactElementView.Pool>()
                .WithInitialSize(10)
                .FromComponentInNewPrefab(_contactElementPrefab).UnderTransformGroup("ContactElementPool");

            Container.Bind<LoopScrollContactElementPrefabSource>().AsSingle();
        }
        
        private void DeclareNotifications()
        {
            Container.DeclareSignal<ContactListRefreshedNotification>();
        }
    }
}