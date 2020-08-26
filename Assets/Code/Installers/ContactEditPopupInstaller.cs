using Code.Data.Vo;
using Code.Presentation.Actions;
using Code.Presentation.Controllers;
using Code.Presentation.Notifications;
using Code.Presentation.Views.EditContact;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class ContactEditPopupInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _contactEditPopupPrefab;

        public override void InstallBindings()
        {
            DeclareAndBindActions();
            BindControllers();
            DeclareNotifications();
            Container.BindFactory<ContactVo, EditContactMediator, EditContactMediator.Factory>().FromComponentInNewPrefab(_contactEditPopupPrefab);
        }

        private void BindControllers()
        {
            Container.Bind<SaveContactController>().AsTransient();
            Container.Bind<DeleteContactController>().AsTransient();
        }

        private void DeclareNotifications()
        {
            Container.DeclareSignal<ContactDetailsNotValidNotification>();
        }

        private void DeclareAndBindActions()
        {
            Container.DeclareSignal<SaveContactAction>();
            Container.BindSignal<SaveContactAction>()
                .ToMethod<SaveContactController>(x => x.Execute).FromResolve();
            
            Container.DeclareSignal<DeleteContactAction>();
            Container.BindSignal<DeleteContactAction>()
                .ToMethod<DeleteContactController>(x => x.Execute).FromResolve();
        }
    }
}