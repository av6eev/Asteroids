using System.Collections.Generic;

namespace Global.Pulls.Base
{
    public abstract class BasePull<TElementView> : IEntityPull<TElementView> where TElementView : BasePullElementView
    {
        private readonly Queue<TElementView> _elements = new();
        private BasePullView<TElementView> _pullView;

        public virtual void CreatePull(BasePullView<TElementView> view)
        {
            _pullView = view;
            
            for (var i = 0; i < view.Count; i++)
            {
                var pullElement = view.CreateObject();
                pullElement.ChangeVisibility(false);
                
                _elements.Enqueue(pullElement);
            }
        }

        public TElementView TryGetElement()
        {
            if (_elements.Count == 0)
            {
                _elements.Enqueue(_pullView.CreateObject());
            }

            var pullObject = _elements.Dequeue();
            pullObject.ChangeVisibility(true);
            
            return pullObject;
        }

        public virtual void PutBack(TElementView element)
        {
            element.ChangeVisibility(false);
            _elements.Enqueue(element);
        }
        
        public virtual void Dispose()
        {
            _pullView.DestroyObjects();
            _elements.Clear();
        }
    }

    public interface IEntityPull<TElementView> where TElementView : BasePullElementView
    {
        void Dispose();
        void PutBack(TElementView elementView);
        TElementView TryGetElement();
        void CreatePull(BasePullView<TElementView> view);
    }
}