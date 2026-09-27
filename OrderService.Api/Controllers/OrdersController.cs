using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderService.Application.Orders.CreateOrder;
using OrderService.Infrastructure.Persistence;
using FluentValidation;
namespace OrderService.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly CreateOrderService _createOrderService;
        private readonly OrderDbContext _dbContext;
        private readonly IValidator<CreateOrderRequest> _validator;
        public OrdersController(CreateOrderService createOrderService, OrderDbContext dbContext, IValidator<CreateOrderRequest> validator)
        {
            _createOrderService = createOrderService;
            _dbContext = dbContext;
            _validator = validator;
        }
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .GroupBy(x => x.PropertyName)
                    .ToDictionary(
                        x => x.Key,
                        x => x.Select(e => e.ErrorMessage).ToArray());

                return BadRequest(new ValidationProblemDetails(errors));
            }

            var order = _createOrderService.Create(request);

            _dbContext.Orders.Add(order);

            await _dbContext.SaveChangesAsync();

            return Created(
                $"/api/orders/{order.Id}",
                new
                {
                    order.Id,
                    order.CustomerId,
                    order.Status,
                    order.TotalAmount
                });
        }
    }
    }
