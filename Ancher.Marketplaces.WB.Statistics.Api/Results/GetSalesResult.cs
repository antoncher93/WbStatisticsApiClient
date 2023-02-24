using System.Net;

namespace Ancher.Marketplaces.WB.Statistics.Api.Results;

public class GetSalesResult
{
    public static GetSalesResult FromSuccess(
        List<Sale> sales)
    {
        return new GetSalesResult(
            success: new SuccessResult(sales));
    }

    public static GetSalesResult FromError(
        HttpStatusCode httpStatusCode,
        string message)
    {
        return new GetSalesResult(
            error: new ErrorResult(
                httpStatusCode: httpStatusCode,
                message: message));
    }
    
    public SuccessResult? Success { get; }
    
    public ErrorResult? Error { get; }
    
    public class SuccessResult
    {
        public SuccessResult(
            List<Sale> sales)
        {
            Sales = sales;
        }
        
        public List<Sale> Sales { get; }
    }
    
    public class ErrorResult
    {
        public ErrorResult(
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
        SuccessResult success)
    {
        Success = success;
    }

    private GetSalesResult(
        ErrorResult error)
    {
        Error = error;
    }
}