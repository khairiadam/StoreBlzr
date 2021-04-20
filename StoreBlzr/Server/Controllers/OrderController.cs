﻿using Microsoft.AspNetCore.Mvc;
using Server.Services;
using StoreBlzr.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreBlzr.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ITypeCrud<Order> _order;

        public OrderController(ITypeCrud<Order> order)
        {
            _order = order;
        }


        // GET: api/<OrderController>
        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            return Ok(await _order.GetAll());
        }

        // GET api/<OrderController>/5
        [HttpGet("Detail")]
        public async Task<IActionResult> GetOrder(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound("Invalid Order Id !");

            var clt = await _order.Get(id);

            if(clt is null) return NotFound("Order was not Found !");

            return Ok(clt);
        }

        // POST api/<OrderController>
        [HttpPost("Add")]
        public async Task<IActionResult> AddOrders(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("There is an error");
            }

            await _order.Post(order);
            return Ok(order);

        }


        // DELETE api/<OrderController>/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();

           await _order.Delete(id);

            return Ok();

        }


        // PUT api/<OrderController>/5
        [HttpPut("Edit")]
        public async Task<IActionResult> Update(string id, Order order)
        {

            await _order.Put(order);

            return Ok(order);
        }

    }
}
