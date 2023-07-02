using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;
using FluentMigrator.Runner.Processors.Firebird;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Discounts;
using Nop.Core.Domain.Media;
using Nop.Plugin.Api.Attributes;
using Nop.Plugin.Api.Authorization.Attributes;
using Nop.Plugin.Api.Delta;
using Nop.Plugin.Api.DTO;
using Nop.Plugin.Api.DTO.Categories;
using Nop.Plugin.Api.DTO.CustomerRoles;
using Nop.Plugin.Api.DTO.Errors;
using Nop.Plugin.Api.DTO.Images;
using Nop.Plugin.Api.Factories;
using Nop.Plugin.Api.Helpers;
using Nop.Plugin.Api.Infrastructure;
using Nop.Plugin.Api.JSON.ActionResults;
using Nop.Plugin.Api.JSON.Serializers;
using Nop.Plugin.Api.ModelBinders;
using Nop.Plugin.Api.Models.CategoriesParameters;
using Nop.Plugin.Api.Services;
using Nop.Services.Catalog;
using Nop.Services.Customers;
using Nop.Services.Discounts;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Media;
using Nop.Services.Security;
using Nop.Services.Seo;
using Nop.Services.Stores;

namespace Nop.Plugin.Api.Controllers.Public
{
    public class PublicGeneralController : BaseApiController
    {
        public PublicGeneralController(
            IJsonFieldsSerializer jsonFieldsSerializer,
            ICustomerActivityService customerActivityService,
            ILocalizationService localizationService,
            IPictureService pictureService,
            IStoreMappingService storeMappingService,
            IStoreService storeService,
            IDiscountService discountService,
            IAclService aclService,
            ICustomerService customerService
            ) 
            : base(jsonFieldsSerializer, aclService, customerService, storeMappingService, storeService, discountService,
                                         customerActivityService, localizationService, pictureService)
        {
        }

        [HttpGet]
        [Route("/api/publicgeneral/ping", Name = "GetPing")]
        [AuthorizePermission("PublicStoreAllowNavigation")]
        [ProducesResponseType(typeof(CategoriesRootObject), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorsRootObject), (int)HttpStatusCode.BadRequest)]
        [GetRequestsErrorInterceptorActionFilter]
        public async Task<IActionResult> GetPing([FromQuery] bool isWithoutToken)
        {
            string fields = "";
            var ping = new PingRootObject {
                FullVersion = "v2.0",
                CurrentVersion = "v2.2",
                MinorVersion = "v2.1"
            };

            var json = JsonFieldsSerializer.Serialize(ping, fields);
            return new RawJsonActionResult(json);
        }
    }


    public class PingRootObject : ISerializableObject
    {
        public string CurrentVersion { get; set; }
        public string MinorVersion { get; set; }
        public string FullVersion { get; set; }
        public string GetPrimaryPropertyName()
        {
            return "ping";
        }

        public Type GetPrimaryPropertyType()
        {
            return typeof(string);
        }
    }
    

}
