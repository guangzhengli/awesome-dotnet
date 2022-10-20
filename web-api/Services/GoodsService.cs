using Awesome_dotnet.Models;
using Awesome_dotnet.Repositories;

namespace Awesome_dotnet.Services;

public class GoodsService
{
    private readonly GoodsRepository _goodsRepository;

    public GoodsService(GoodsRepository goodsRepository)
    {
        _goodsRepository = goodsRepository;
    }

    public void CreateGoods(Goods goods)
    {
        _goodsRepository.Save(goods);
    }

    public Goods GetGoods(Guid id)
    {
        return _goodsRepository.Load<Goods>(id);
    }
}