﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Fabric;

namespace ITG.Brix.Mobile.Bff.API.Controllers
{
    [Route("/")]
    [ApiController]
    [ExcludeFromCodeCoverage]
    public class HealthController : ControllerBase
    {
        private readonly StatelessServiceContext context;

        public HealthController(StatelessServiceContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult CheckHealth()
        {
            return Ok(new
            {
                service = context.ServiceName,
                version = context.CodePackageActivationContext.CodePackageVersion,
                status = "Alive and kicking"
            });
        }

        [HttpGet]
        [Route("throwException")]
        public IActionResult ThrowException()
        {
            throw new System.Exception("test global exception handler");
        }
    }
}
