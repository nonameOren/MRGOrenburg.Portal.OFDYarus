using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.CQRS.Queries;
using Convey.Docs.Swagger;
using Convey.HTTP;
using Convey.Logging;
using Convey.Types;
using Convey.WebApi;
using Convey.WebApi.Swagger;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MRG.OFDYarus.Api.Exceptions;
using MRG.OFDYarus.Application.Requests;
using MRG.OFDYarus.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRG.OFDYarus.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        => await WebHost.CreateDefaultBuilder(args)
            .ConfigureServices(services => services
                .AddConvey()
                .AddHttpClient()
                .AddErrorHandler<ExceptionToResponseMapper>()
                .AddInfrastructure()
                .AddWebApi()
                .AddWebApiSwaggerDocs()
                .AddCommandHandlers()
                .AddInMemoryCommandDispatcher()
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher()
                .AddEventHandlers()
                .AddInMemoryEventDispatcher()
                .Build())
            .Configure(app => app
                .UseInfrastructure()
                .UseErrorHandler()
                .UseSwaggerDocs()
                .UseEndpoints(endpoints => endpoints
                    .Get("", ctx => ctx.Response.WriteAsync(ctx.RequestServices.GetService<AppOptions>().Name))
                    .Get("v1/inn", async ctx => {
                        var request = await ctx.RequestServices.GetService<IOfdService>().InnAsync();
                        await ctx.Response.WriteAsJsonAsync(request);
                    })
                    .Post<Check_FNRequest>("v1/check_fn", async (cmd, ctx) => {
                        var request = await ctx.RequestServices.GetService<IOfdService>().Check_FNAsync(cmd);
                        await ctx.Response.WriteAsJsonAsync(request);
                    })
                    .Post<DateRequest>("v1/KKT", async (cmd, ctx) => {
                        var request = await ctx.RequestServices.GetService<IOfdService>().KKTv1(cmd);
                        await ctx.Response.WriteAsJsonAsync(request);                        
                    })
                    .Post<DateRequest>("v2/KKT", async (cmd, ctx) => {
                        var request = await ctx.RequestServices.GetService<IOfdService>().KKTv2(cmd);
                        await ctx.Response.WriteAsJsonAsync(request);                        
                    })
                    .Post<DateRequest>("v1/TP", async (cmd, ctx) => {
                        var request = await ctx.RequestServices.GetService<IOfdService>().TPv1(cmd);
                        await ctx.Response.WriteAsJsonAsync(request);
                    })
                    .Post<DateRequest>("v2/TP", async (cmd, ctx) => {
                        var request = await ctx.RequestServices.GetService<IOfdService>().TPv2(cmd);
                        await ctx.Response.WriteAsJsonAsync(request);
                    })
                    .Get("v1/TradePoint", async ctx => {
                        var request = await ctx.RequestServices.GetService<IOfdService>().TradePoint();
                        await ctx.Response.WriteAsJsonAsync(request);
                    })
                    .Post<TPNumberRequest>("v1/KKTbyTradePoint", async(cmd, ctx)=> {
                        var request = await ctx.RequestServices.GetService<IOfdService>().KKTbyTradePoint(cmd);
                        await ctx.Response.WriteAsJsonAsync(request);
                    })
                    .Post<DocumentsRequest>("v1/documents", async (cmd, ctx) => {
                        var request = await ctx.RequestServices.GetService<IOfdService>().Documents(cmd);
                        await ctx.Response.WriteAsJsonAsync(request);
                    })
                    .Post<KKTShiftRequest>("v1/KKTShift", async (cmd, ctx) => {
                        var request = await ctx.RequestServices.GetService<IOfdService>().KKTShift(cmd);
                        await ctx.Response.WriteAsJsonAsync(request);
                    })
                    .Post<DocumentsShiftRequest>("v1/documentsShift", async (cmd, ctx) => {
                        var request = await ctx.RequestServices.GetService<IOfdService>().DocumentsShift(cmd);
                        await ctx.Response.WriteAsJsonAsync(request);
                    })  
                    .Post<CloseShiftReportRequest>("v1/closeShiftReport", async (cmd, ctx) => {
                        var request = await ctx.RequestServices.GetService<IOfdService>().CloseShiftReport(cmd);
                        await ctx.Response.WriteAsJsonAsync(request);
                    })   
                    .Post<GetChequeLinkRequest_v1>("v1/getChequeLink", async (cmd, ctx) => {
                        var request = await ctx.RequestServices.GetService<IOfdService>().GetChequeLink(cmd);
                        await ctx.Response.WriteAsJsonAsync(request);
                    })
                    .Post<GetChequeLinkRequest_v2>("v2/getChequeLink", async (cmd, ctx) => {
                        var request = await ctx.RequestServices.GetService<IOfdService>().GetChequeLink(cmd);
                        await ctx.Response.WriteAsJsonAsync(request);
                    })
                    .Post<GetFiscalDocRequest_v1>("v1/getFiscalDoc", async (cmd, ctx) => {
                        var request = await ctx.RequestServices.GetService<IOfdService>().GetFiscalDoc(cmd);
                        await ctx.Response.WriteAsJsonAsync(request);
                    })
                    .Post<GetFiscalDocRequest_v2>("v2/getFiscalDoc", async (cmd, ctx) => {
                        var request = await ctx.RequestServices.GetService<IOfdService>().GetFiscalDoc(cmd);
                        await ctx.Response.WriteAsJsonAsync(request);
                    })
                    .Post<GetFiscalReportRequest>("v1/getFiscalReport", async (cmd, ctx) => {
                        var request = await ctx.RequestServices.GetService<IOfdService>().GetFiscalReport(cmd);
                        await ctx.Response.WriteAsJsonAsync(request);
                    })
                )
            )
            .UseLogging()
            .Build()
            .RunAsync();
    }
}
