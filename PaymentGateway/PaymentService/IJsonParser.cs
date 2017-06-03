using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentService
{
    public interface IJsonParser<T>
    {
        T FromJson(string response);
        string ToJson(T source);
    }
}
