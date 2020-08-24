using Code.Presentation.Views;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class BookListInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _contactElementPrefab;
        
        public override void InstallBindings()
        {
            Container.BindMemoryPool<ContactElementView, ContactElementView.Pool>()
                .WithInitialSize(10)
                .FromComponentInNewPrefab(_contactElementPrefab).
                UnderTransformGroup("ContactElementPool");

            Container.Bind<LoopScrollContactElementPrefabSource>().AsSingle();
        }
    }
}