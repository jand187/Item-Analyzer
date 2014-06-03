using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using HaveBox;

namespace ItemAnalyzer.Website.HaveBox
{
	public class HaveBoxControllerActivator : IHttpControllerActivator
	{
		private readonly Container _container;

		public HaveBoxControllerActivator(Container container)
		{
			_container = container;
		}

		public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
		{
			return _container.GetInstance(controllerType) as IHttpController;
		}
	}
}
