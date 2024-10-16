﻿using System.Net;
using NWEB01.API.ApiResponse;
using NWEB01.Application.Exceptions;

namespace NWEB01.API.Middlewares
{
	public class ExceptionHandlerMiddleware
	{
		private readonly RequestDelegate next;

		public ExceptionHandlerMiddleware(RequestDelegate next)
		{
			this.next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await next(context);
			}
			catch (Exception exception)
			{
				await HandleException(context, exception);
			}
		}

		private async Task HandleException(HttpContext context, Exception exception)
		{
			context.Response.ContentType = "application/json";
			if (exception is NotFoundException)
			{
				context.Response.StatusCode = (int)HttpStatusCode.NotFound;
			}
			else
			{
				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			}

			var errorResponse = new ErrorResponse();
			errorResponse.AddError("Some thing went wrong!");
			errorResponse.AddDetailsError(exception.Message);

			await context.Response.WriteAsJsonAsync(errorResponse);
		}
	}
}
