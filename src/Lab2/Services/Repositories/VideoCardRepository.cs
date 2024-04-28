using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.GPU;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

public class VideoCardRepository
{
    private IList<VideoCard> _videoCards;

    public VideoCardRepository(IList<VideoCard> videoCards)
    {
        _videoCards = videoCards;
    }

    // Так как видеокарта может быть null то она не вписывается в IRepository из-за GetByName
    public VideoCard? GetByName(string name)
    {
        foreach (VideoCard elem in _videoCards)
        {
            if (elem.Name == name)
            {
                return elem;
            }
        }

        return null;
    }

    public void Update(VideoCard sparePart)
    {
        VideoCard? currentObject = _videoCards.FirstOrDefault(storage => storage.Name == sparePart.Name);
        if (currentObject is not null)
        {
            int pos = _videoCards.IndexOf(currentObject);
            _videoCards[pos] = sparePart;
        }
    }

    public void Add(VideoCard sparePart)
    {
        _videoCards.Add(sparePart);
    }

    public void Delete(string partName)
    {
        _videoCards.Remove(_videoCards.FirstOrDefault(video => video.Name == partName) ??
                           throw new ArgumentNullException(partName));
    }
}