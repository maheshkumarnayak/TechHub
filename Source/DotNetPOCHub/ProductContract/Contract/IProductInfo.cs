using ProductContract.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace ProductContract.Contract
{
    [ServiceContract (Namespace ="myService")]
    public interface IProductInfo
    {
        [OperationContract]
        Product Insert(Product product);

        [OperationContract]
        Product Update(Product product);

        [OperationContract]
        List<Product> Get(GetProductRequest request);

        [OperationContract]
        bool Delete(int Id);
    }
}
