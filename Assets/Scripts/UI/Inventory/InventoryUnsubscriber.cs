using System;
using System.Collections.Generic;

//Class that allows Inventory Slots to unsubcribe to the event once they have registered
internal class InventoryUnsubscriber<InventoryManager> : IDisposable
{
    private List<IObserver<InventoryManager>> _observers;
    private IObserver<InventoryManager> _observer;

    internal InventoryUnsubscriber(List<IObserver<InventoryManager>> observers, IObserver<InventoryManager> observer)
    {
        _observers = observers;
        _observer = observer;
    }

    public void Dispose()
    {
        if (_observers.Contains(_observer))
        {
            _observers.Remove(_observer);
        }
    }
}