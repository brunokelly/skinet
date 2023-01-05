using Microsoft.AspNetCore.Mvc;
using Skinet.Application.Common;
using Skinet.Domain.SeedOfWork;
using System.Net;
using static Skinet.Domain.SeedOfWork.NotificationModel;

namespace Skinet.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        private readonly INotification _notification;
        protected BaseController(INotification notification) => _notification = notification;

        private bool IsValidOperation() => !_notification.HasNotification;
        protected new IActionResult Response(BaseResponse response)
        {
            if (IsValidOperation())
            {
                if (response == null)
                    return NoContent();

                return Ok(response);
            }
            else
            {
                if (response == null)
                    response = new Response();

                response.Success = false;
                response.Error = _notification.NotificationModel;

                switch (_notification?.NotificationModel?.NotificationType)
                {
                    case ENotificationType.BusinessRules:
                        return Conflict(response);
                    case ENotificationType.NotFound:
                        return NotFound(response);
                    case ENotificationType.BadRequestError:
                        return BadRequest(response);
                    case ENotificationType.Forbidden:
                        return Forbid();
                    default:
                        return StatusCode((int)HttpStatusCode.InternalServerError, response);
                }
            }
        }

        protected new IActionResult Response(object response = null)
        {
            if (IsValidOperation())
            {
                if (response == null)
                    return NoContent();

                return Ok(new
                {
                    success = true,
                    data = response
                });
            }

            return BadRequest(new
            {
                success = false,
                error = response
            });
        }

        protected new IActionResult Response(int? id = null, object? response = null)
        {
            if (IsValidOperation())
            {
                if (id == null)
                    return Ok(new
                    {
                        success = true,
                        data = response
                    });



                return CreatedAtAction("Get", new { id },
                    new
                    {
                        success = true,
                        data = response ?? new object()
                    });
            }



            return BadRequest(new
            {
                success = false,
                error = _notification.NotificationModel
            });
        }
    }
}