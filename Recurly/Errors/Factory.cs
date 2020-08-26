/**
 * This file is automatically created by Recurly's OpenAPI generation process
 * and thus any edits you make by hand will be lost. If you wish to make a
 * change to this file, please create a Github issue explaining the changes you
 * need and we will usher them to the appropriate places.
 */
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using RestSharp;

namespace Recurly.Errors
{

    [ExcludeFromCodeCoverage]
    public static class Factory
    {
        public static RecurlyError Create(IRestResponse resp, string message, Recurly.Resources.ErrorMayHaveTransaction nestedError)
        {
            switch ((int)resp.StatusCode)
            {
                case 500:
                    return new InternalServer(message)
                    {
                        Error = nestedError
                    };
                case 502:
                    return new BadGateway(message)
                    {
                        Error = nestedError
                    };
                case 503:
                    return new ServiceUnavailable(message)
                    {
                        Error = nestedError
                    };
                case 504:
                    return new Timeout(message)
                    {
                        Error = nestedError
                    };
                case 304:
                    return new NotModified(message)
                    {
                        Error = nestedError
                    };
                case 400:
                    return new BadRequest(message)
                    {
                        Error = nestedError
                    };
                case 401:
                    return new Unauthorized(message)
                    {
                        Error = nestedError
                    };
                case 402:
                    return new PaymentRequired(message)
                    {
                        Error = nestedError
                    };
                case 403:
                    return new Forbidden(message)
                    {
                        Error = nestedError
                    };
                case 404:
                    return new NotFound(message)
                    {
                        Error = nestedError
                    };
                case 406:
                    return new NotAcceptable(message)
                    {
                        Error = nestedError
                    };
                case 412:
                    return new PreconditionFailed(message)
                    {
                        Error = nestedError
                    };
                case 422:
                    return new UnprocessableEntity(message)
                    {
                        Error = nestedError
                    };
                case 429:
                    return new TooManyRequests(message)
                    {
                        Error = nestedError
                    };
                default:
                    return new RecurlyError(resp.ErrorMessage);
            }
        }

        public static ApiError Create(Recurly.Resources.ErrorMayHaveTransaction err)
        {
            switch (err.Type)
            {
                case "bad_request":
                    return new BadRequest(err.Message)
                    {
                        Error = err
                    };
                case "internal_server_error":
                    return new InternalServer(err.Message)
                    {
                        Error = err
                    };
                case "immutable_subscription":
                    return new ImmutableSubscription(err.Message)
                    {
                        Error = err
                    };
                case "invalid_api_key":
                    return new InvalidApiKey(err.Message)
                    {
                        Error = err
                    };
                case "invalid_api_version":
                    return new InvalidApiVersion(err.Message)
                    {
                        Error = err
                    };
                case "invalid_content_type":
                    return new InvalidContentType(err.Message)
                    {
                        Error = err
                    };
                case "invalid_permissions":
                    return new InvalidPermissions(err.Message)
                    {
                        Error = err
                    };
                case "invalid_token":
                    return new InvalidToken(err.Message)
                    {
                        Error = err
                    };
                case "not_found":
                    return new NotFound(err.Message)
                    {
                        Error = err
                    };
                case "simultaneous_request":
                    return new SimultaneousRequest(err.Message)
                    {
                        Error = err
                    };
                case "transaction":
                    return new Transaction(err.Message)
                    {
                        Error = err
                    };
                case "unauthorized":
                    return new Unauthorized(err.Message)
                    {
                        Error = err
                    };
                case "unavailable_in_api_version":
                    return new UnavailableInApiVersion(err.Message)
                    {
                        Error = err
                    };
                case "unknown_api_version":
                    return new UnknownApiVersion(err.Message)
                    {
                        Error = err
                    };
                case "validation":
                    return new Validation(err.Message)
                    {
                        Error = err
                    };
                case "missing_feature":
                    return new MissingFeature(err.Message)
                    {
                        Error = err
                    };
                case "rate_limited":
                    return new RateLimited(err.Message)
                    {
                        Error = err
                    };
                default:
                    // Explode if we are in strict mode
                    if (Utils.StrictMode)
                    {
                        throw new ArgumentException($"{err.Type} has no valid exception class");
                    }
                    // Fall back to generic API error if we are in production
                    else
                    {
                        return new ApiError(err.Message)
                        {
                            Error = err
                        };
                    }
            }
        }
    }
}
