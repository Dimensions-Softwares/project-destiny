using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUnsubcriber : IDisposable
{
    private List<IObserver<HealthBar>> _observers;
    private IObserver<HealthBar> _observer;

    internal HealthBarUnsubcriber(List<IObserver<HealthBar>> observers, IObserver<HealthBar> observer)
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
