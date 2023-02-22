using System.Net;

namespace Ancher.Marketplaces.WB.Statistics.Api.Results;

public class GetSalesResult
{
    public static GetSalesResult FromSuccess(
        List<Sale> sales)
    {
        return new GetSalesResult(
            successResult: new Success(sales));
    }

    public static GetSalesResult FromError(
        HttpStatusCode httpStatusCode,
        string message)
    {
        return new GetSalesResult(
            errorResult: new Error(
                httpStatusCode: httpStatusCode,
                message: message));
    }
    
    public Success? SuccessResult { get; }
    
    public Error? ErrorResult { get; }
    
    public class Success
    {
        public Success(
            List<Sale> sales)
        {
            Sales = sales;
        }
        
        public List<Sale> Sales { get; }
    }
    
    public class Error
    {
        public Error(
            HttpStatusCode httpStatusCode,
            string message)
        {
            HttpStatusCode = httpStatusCode;
            Message = message;
        }
        
        public HttpStatusCode HttpStatusCode { get; }
        
        public string Message { get; }
    }

    private GetSalesResult(
        Success successResult)
    {
        SuccessResult = successResult;
    }

    private GetSalesResult(
        Error errorResult)
    {
        ErrorResult = errorResult;
    }
}