using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFi;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

public class WiFiModemRepository
{
    private IList<WiFiModem> _wifiModems;

    public WiFiModemRepository(IList<WiFiModem> wifiModems)
    {
        _wifiModems = wifiModems;
    }

    // Так же почему и видеокарта
    public WiFiModem? GetByName(string name)
    {
        foreach (WiFiModem elem in _wifiModems)
        {
            if (elem.Name == name)
            {
                return elem;
            }
        }

        return null;
    }

    public void Update(WiFiModem sparePart)
    {
        WiFiModem? currentObject = _wifiModems.FirstOrDefault(storage => storage.Name == sparePart.Name);
        if (currentObject is not null)
        {
            int pos = _wifiModems.IndexOf(currentObject);
            _wifiModems[pos] = sparePart;
        }
    }

    public void Add(WiFiModem sparePart)
    {
        _wifiModems.Add(sparePart);
    }

    public void Delete(string partName)
    {
        _wifiModems.Remove(_wifiModems.FirstOrDefault(video => video.Name == partName) ??
                           throw new ArgumentNullException(partName));
    }
}