﻿using MakasUI.Models;
using MakasUI.Models.DtosForCustomer;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MakasUI.Services.CustomerServices.Abstract
{
    public interface ICustomerRestService
    {
        Task<Customer> GetCustomerAsync(int customerId);
        Task<List<GetSaloonsByLocationDto>> ListSaloonsByLocationAsync(SearchSaloonsDto listedSaloon);
        Task<HttpResponseMessage> UpdateCustomerNameAsync(UpdateCustomerNameDto customer);
        Task<HttpResponseMessage> UpdateCustomerPasswordAsync(UpdateCustomerPasswordDto customer);
        Task<HttpResponseMessage> UpdateCustomerMailAsync(UpdateCustomerMailDto customer);
    }
}