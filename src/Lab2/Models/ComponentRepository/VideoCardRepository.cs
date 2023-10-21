using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Type;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComponentRepository;

public class VideoCardRepository
{
    private readonly List<IVideoCard> _videoCards;

    public VideoCardRepository()
    {
        _videoCards = new List<IVideoCard>
        {
            new VideoCard(new SizeType(146, 69), new CountType(2), new PciEVersion.V2(), new CountType(954), new CountType(19)),
            new VideoCard(new SizeType(327, 137), new CountType(12), new PciEVersion.V2(), new CountType(2150), new CountType(250)),
            new VideoCard(new SizeType(342, 150), new CountType(24), new PciEVersion.V4(), new CountType(2235), new CountType(300)),
        };
    }

    public IEnumerable<IVideoCard> ReturnVideoCards() => _videoCards;

    public void AddVideoCard(IVideoCard videoCard)
    {
        _videoCards.Add(videoCard);
    }
}